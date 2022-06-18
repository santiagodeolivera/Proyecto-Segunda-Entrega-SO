using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoSO.Lib;

namespace ProyectoSO
{
    public partial class Simulador : Form
    {
        private readonly Scheduler sch;
        private Timer timer = new Timer();

        public Simulador(Scheduler sch)
        {
            InitializeComponent();
            this.sch = sch;
            this.actualizarListasProcesos();

            timer.Interval = 250;
            timer.Stop();
            timer.Tick += (sender, e) =>
            {
                this.sch.Actualizar(10);
                this.actualizarListasProcesos();
            };
        }
        private void btnAddProcesses_Click(object sender, EventArgs e)
        {
            AñadirProceso añadirProceso = new AñadirProceso();
            añadirProceso.ShowDialog();
            if (añadirProceso.Lista == null)
            {
                return;
            }

            ISet<string> procesosNoInsertados = this.sch.InsertarProcesos(añadirProceso.Lista);
            this.actualizarListasProcesos();
            if (procesosNoInsertados.Count > 0)
            {
                MessageBox.Show("Los siguientes procesos no fueron insertados porque ya habían otros con el mismo" +
                    "nombre: " + string.Join(", ", procesosNoInsertados));
            }
        }

        private void actualizarListasProcesos()
        {
            Utils.CargarLista(
                listBox: this.listProcesosListos,
                lista: this.sch.ProcesosListos(),
                titulo: "Procesos listos",
                formato: "{0,-" + ProcesoPlantilla.LimiteCaracteresNombre + "} P{1:D2} {2,8}",
                propiedades: null,
                conversor: tupla =>
                {
                    string nombre = tupla.Item1;
                    ProcesoDatos proceso = tupla.Item2;
                    return new object[]
                    {
                        nombre, proceso.Prioridad, proceso.Kernel ? "(kernel)" : ""
                    };
                });

            IDictionary<byte, (string, ProcesoDatos)> procesosEnCPU = this.sch.ProcesosEnCPU();
            List<(byte, string)> procesosEnCPUFormateados = new List<(byte, string)>(sch.CantNucleos);
            for (byte i = 0; i < sch.CantNucleos; i++)
            {
                string texto;

                if (procesosEnCPU.TryGetValue(i, out var tupla))
                {
                    string nombre = tupla.Item1;
                    ProcesoDatos proceso = tupla.Item2;
                    texto = string.Format(
                        "{0,-" + ProcesoPlantilla.LimiteCaracteresNombre + "} P{1:D2} {2,8}",
                        nombre, proceso.Prioridad, proceso.Kernel ? "(kernel)" : "");
                } else
                {
                    texto = new string('-', (int)ProcesoPlantilla.LimiteCaracteresNombre + 12);
                }

                procesosEnCPUFormateados.Add((i, texto));
            }
            Utils.CargarLista(
                listBox: this.listProcesosEjec,
                lista: procesosEnCPUFormateados,
                titulo: "Procesos en CPU",
                formato: "{0,3} => {1}",
                propiedades: null,
                conversor: tupla => new object[] { tupla.Item1, tupla.Item2 });

            this.listProcesosBloq.Items.Clear();
            Utils.CargarLista(
                listBox: this.listProcesosBloq,
                lista: this.sch.ProcesosBloqueados(),
                titulo: "Procesos bloqueados",
                formato: "{0,-" + ProcesoPlantilla.LimiteCaracteresNombre + "} P{1:D2} {2,8}",
                propiedades: null,
                conversor: tupla =>
                {
                    string nombre = tupla.Item1;
                    ProcesoDatos proceso = tupla.Item2;
                    return new object[]
                    {
                        nombre, proceso.Prioridad, proceso.Kernel ? "(kernel)" : ""
                    };
                });
        }

        private void btnIniciarDetener_Click(object sender, EventArgs e)
        {
            if (this.timer.Enabled)
            {
                this.timer.Stop();
                this.btnIniciarDetener.BackColor = Color.FromName("Control");
            } else
            {
                this.timer.Start();
                this.btnIniciarDetener.BackColor = Color.Black;
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            IEnumerable<(string, ProcesoDatos)> procesos = this.sch.TablaProcesos().Select(pair =>
            {
                string nombre = pair.Key;
                ProcesoDatos proceso = pair.Value.Item1;
                return (nombre, proceso);
            });

            Config config = new Config(procesos.ToList());

            config.ShowDialog();

            Dictionary<string, ProcesoModDatos> modificaciones = config.Modificaciones;
            if (modificaciones == null)
            {
                return;
            }

            foreach (KeyValuePair<string, ProcesoModDatos> modificacion in modificaciones)
            {
                string nombre = modificacion.Key;
                ProcesoModDatos modDatos = modificacion.Value;
                this.sch.ModificarProceso(nombre, modDatos);
            }
            this.actualizarListasProcesos();
        }
    }
}

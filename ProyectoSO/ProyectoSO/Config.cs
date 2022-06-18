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
    public partial class Config : Form
    {

        private readonly List<(string, ProcesoDatos)> procesos;

        private readonly Dictionary<string, ProcesoModDatos> modificaciones = new Dictionary<string, ProcesoModDatos>();
        public Dictionary<string, ProcesoModDatos> Modificaciones = null;

        private int _index = 0;

        private int Index
        {
            get => _index;
            set
            {
                _index = value;
                if (value < 0)
                {
                    this.pnlForm.Enabled = false;
                    this.txtNombre.Clear();
                }
                else
                {
                    this.pnlForm.Enabled = true;
                    (string, ProcesoDatos) proceso = this.procesos[value];
                    this.txtNombre.Text = proceso.Item1;
                    this.numPrioridad.Value = proceso.Item2.Prioridad;
                    this.checkBloqueado.Checked = proceso.Item2.Bloqueado;
                }
            }
        }

        public Config(List<(string, ProcesoDatos)> procesos)
        {
            InitializeComponent();
            this.procesos = procesos;
            this.ActualizarListBox();
            this.Index = -1;
        }

        private void listProcesos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Index = this.listProcesos.SelectedIndex - 2;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            if (modificaciones.ContainsKey(nombre))
            {
                modificaciones.Remove(nombre);
            }

            byte prioridad;
            {
                decimal prioridadDec = this.numPrioridad.Value;
                if (Utils.ChequearInput(
                    prioridadDec <= 0,
                    "La prioridad de un proceso debe ser positiva."))
                {
                    return;
                }

                if (Utils.ChequearInput(
                    prioridadDec > 99,
                    "La prioridad debe ser un número entre 1 y 99."))
                {
                    return;
                }

                prioridad = (byte)prioridadDec;
                if (Utils.ChequearInput(
                    prioridad != prioridadDec,
                    "Este simulador no permite que el tiempo de ejecucion de " +
                            "un proceso no puede ser un número decimal."))
                {
                    return;
                }
            }

            ProcesoModDatos modDatos = new ProcesoModDatos(prioridad, this.checkBloqueado.Checked);
            this.modificaciones.Add(nombre, modDatos);

            ProcesoDatos anterior = this.procesos[this.Index].Item2;
            this.procesos.RemoveAt(this.Index);
            this.procesos.Insert(this.Index, (nombre, anterior.Modificar(modDatos)));

            this.ActualizarListBox();
        }

        private void ActualizarListBox()
        {
            Utils.CargarLista(
                listBox: this.listProcesos,
                lista: this.procesos,
                titulo: "Procesos",
                formato: "{0,-" + ProcesoPlantilla.LimiteCaracteresNombre + "} | {1,-9} | {2,-9} | {3,-11} | {4,-19}",
                propiedades: new string[] { "Nombre", "Prioridad", "Kernel", "Bloqueado", "Tiempo de ejecucion" },
                conversor: tupla =>
                {
                    string nombre = tupla.Item1;
                    ProcesoDatos proceso = tupla.Item2;
                    return new object[]
                    {
                        nombre,
                        proceso.Prioridad,
                        proceso.Kernel ? "(kernel)" : "",
                        proceso.Bloqueado ? "(bloqueado)" : "",
                        proceso.TiempoRestante + " \u00B5s"
                    };
                });
        }

        private void Config_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!modificaciones.Any())
            {
                return;
            }

            DialogResult res = MessageBox.Show("¿Realizar los cambios especificados?", "", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes)
            {
                this.Modificaciones = this.modificaciones;
            } else if (res != DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

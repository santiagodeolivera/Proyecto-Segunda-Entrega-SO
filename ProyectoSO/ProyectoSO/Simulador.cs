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

        public Simulador(Scheduler sch)
        {
            InitializeComponent();
            this.sch = sch;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void procesosBloqueadosList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Simulador_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

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
            this.listProcesosListos.Items.Clear();
            this.listProcesosEjec.Items.Clear();
            this.listProcesosBloq.Items.Clear();

            IList<(string, ProcesoDatos)> procesosListos = this.sch.ProcesosListos();
            this.listProcesosListos.Items.Add("Procesos listos:");
            foreach ((string nombre, ProcesoDatos proceso) in procesosListos)
            {
                string elemento = string.Format(
                    "{0,-" + ProcesoPlantilla.LimiteCaracteresNombre + "} P{1:D2} {2,8}",
                    nombre, proceso.Prioridad, proceso.Kernel ? "(kernel)" : "");
                this.listProcesosListos.Items.Add(elemento);
            }
        }
    }
}

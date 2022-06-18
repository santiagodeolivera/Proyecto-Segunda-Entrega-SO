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
    public partial class AñadirProceso : Form
    {
        private readonly LinkedList<ProcesoPlantilla> lista = new LinkedList<ProcesoPlantilla>();

        public IEnumerable<ProcesoPlantilla> Lista = null;

        public AñadirProceso()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCargarProcesos_Click(object sender, EventArgs e)
        {
            this.Lista = this.lista;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            uint tiempoEjec;
            {
                decimal tiempoEjecDec = this.numTiempoEjec.Value;
                if (tiempoEjecDec <= 0)
                {
                    MessageBox.Show(
                        "El tiempo de ejecucion de un proceso debe ser positivo.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                tiempoEjec = (uint)tiempoEjecDec;
                if (tiempoEjec != tiempoEjecDec)
                {
                    MessageBox.Show(
                        "El tiempo de ejecucion de un proceso no puede ser un número decimal.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }

            byte prioridad;
            {
                decimal prioridadDec = this.numPrioridadProceso.Value;
                if (prioridadDec <= 0)
                {
                    MessageBox.Show(
                        "La prioridad de un proceso debe ser positiva.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (prioridadDec > 99)
                {
                    MessageBox.Show(
                        "La prioridad debe ser un número entre 1 y 99.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                prioridad = (byte)prioridadDec;
                if (prioridad != prioridadDec)
                {
                    MessageBox.Show(
                        "Este simulador no permite que el tiempo de ejecucion de " + 
                            "un proceso no puede ser un número decimal.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

            }

            string nombre = this.txtNombreProceso.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length == 0)
            {
                MessageBox.Show(
                        "El nombre del proceso es requerido.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nombre.Length > ProcesoPlantilla.LimiteCaracteresNombre)
            {
                MessageBox.Show(
                        "El nombre del proceso no puede tener más de "
                            + ProcesoPlantilla.LimiteCaracteresNombre + " caracteres.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool kernel = this.checkKernel.Checked;

            if (this.lista.Any(plantilla => plantilla.Nombre.Equals(nombre)))
            {
                MessageBox.Show(
                        "Ya hay un proceso con el nombre especificado.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.lista.AddLast(new ProcesoPlantilla(nombre, prioridad, kernel, tiempoEjec));

            this.ActualizarListBox();
            this.LimpiarFormulario();
        }

        /// <summary>
        /// Actualiza el listBox para mostrar el contenido actual de this.lista
        /// </summary>
        private void ActualizarListBox()
        {
            // Limpiar el contenido actual
            this.listBox1.Items.Clear();

            // Mostrar cada plantilla por separado
            this.listBox1.Items.Add(
                string.Format(
                    "Kernel    {0,-" + ProcesoPlantilla.LimiteCaracteresNombre + "}    Prioridad    Tiempo de ejecucion",
                    "nombre"));
            foreach (ProcesoPlantilla plantilla in this.lista)
            {
                string elemento = string.Format(
                    "{0,8}  {1,-" + ProcesoPlantilla.LimiteCaracteresNombre + "}    {2,-9:D2}    {3,5} ms",
                    plantilla.Kernel ? "(kernel)" : "",
                    plantilla.Nombre,
                    plantilla.Prioridad,
                    plantilla.TiempoRestante);

                this.listBox1.Items.Add(elemento);
            }
        }

        private void LimpiarFormulario()
        {
            this.numTiempoEjec.Value = 0;
            this.numPrioridadProceso.Value = 0;
            this.txtNombreProceso.Clear();
            this.checkKernel.Checked = false;
        }

        private void btnBorrarTabla_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Quieres borrar todos los elementos de la tabla?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                this.lista.Clear();
                this.ActualizarListBox();
            }
        }
    }
}

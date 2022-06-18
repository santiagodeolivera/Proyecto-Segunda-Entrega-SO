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
            this.txtNombreProceso.MaxLength = (int)ProcesoPlantilla.LimiteCaracteresNombre;
            this.ActualizarListBox();
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
                if (Utils.ChequearInput(
                    tiempoEjecDec <= 0,
                    "El tiempo de ejecucion de un proceso debe ser positivo."))
                {
                    return;
                }

                tiempoEjec = (uint)tiempoEjecDec;
                if (Utils.ChequearInput(
                    tiempoEjec != tiempoEjecDec,
                    "El tiempo de ejecucion de un proceso no puede ser un número decimal."))
                {
                    return;
                }
            }

            byte prioridad;
            {
                decimal prioridadDec = this.numPrioridadProceso.Value;
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

            string nombre = this.txtNombreProceso.Text.Trim();
            if (Utils.ChequearInput(
                string.IsNullOrWhiteSpace(nombre) || nombre.Length == 0,
                "El nombre del proceso es requerido."))
            {
                return;
            }

            if (Utils.ChequearInput(
                nombre.Length > ProcesoPlantilla.LimiteCaracteresNombre,
                "El nombre del proceso no puede tener más de "
                            + ProcesoPlantilla.LimiteCaracteresNombre + " caracteres."))
            {
                return;
            }

            bool kernel = this.checkKernel.Checked;

            if (Utils.ChequearInput(
                this.lista.Any(plantilla => plantilla.Nombre.Equals(nombre)),
                "Ya hay un proceso con el nombre especificado."))
            {
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
            Utils.CargarLista(
                listBox: this.listBox1,
                lista: this.lista,
                titulo: "Procesos a añadir",
                formato: "{0,-8}  {1,-" + ProcesoPlantilla.LimiteCaracteresNombre + "}    {2,-9}    {3,-19}",
                propiedades: new string[]{ "Kernel", "Nombre", "Prioridad", "Tiempo de ejecucion" },
                conversor: plantilla => new object[]
                {
                    plantilla.Kernel ? "(kernel)" : "",
                    plantilla.Nombre,
                    plantilla.Prioridad,
                    plantilla.TiempoRestante
                });
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

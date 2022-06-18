using System.Windows.Forms;

namespace ProyectoSO
{
    public partial class PrincipalForm : Form
    {
        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void LimpiarBtn_Click(object sender, System.EventArgs e)
        {
            Control focused = this.ActiveControl;
            this.limpiarBtn.Focus();

            this.cantNucleosNum.Value = 0;
            this.quantumNum.Value = 0;

            focused.Focus();
        }

        private void IniciarBtn_Click(object sender, System.EventArgs e)
        {
            byte cantNucleos;
            {
                decimal cantNucleosDec = this.cantNucleosNum.Value;
                if (Utils.ChequearInput(
                    cantNucleosDec <= 0 || cantNucleosDec > decimal.MaxValue,
                    "La cantidad de núcleos debe ser entre 1 y 255."))
                {
                    return;
                }

                cantNucleos = (byte)cantNucleosDec;
                if (Utils.ChequearInput(
                    cantNucleos != cantNucleosDec,
                    "La cantidad de núcleos no puede ser un número decimal."))
                {
                    return;
                }
            }

            uint quantum;
            {
                decimal quantumDec = this.quantumNum.Value;
                if (Utils.ChequearInput(
                    quantumDec <= 0,
                    "El quantum debe ser una cantidad positiva."))
                {
                    return;
                }

                if (Utils.ChequearInput(
                    quantumDec > uint.MaxValue,
                    "El quantum dado es demasiado grande para el programa."))
                {
                    return;
                }

                quantum = (uint)quantumDec;
                if (Utils.ChequearInput(
                    quantum != quantumDec,
                    "El quantum no puede ser un número decimal."))
                {
                    return;
                }
            }

            Simulador simulador = new Simulador(new Lib.Scheduler(cantNucleos, quantum));
            simulador.ShowDialog();
        }
    }
}
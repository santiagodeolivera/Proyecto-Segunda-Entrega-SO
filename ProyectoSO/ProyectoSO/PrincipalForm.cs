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
                if (cantNucleosDec <= 0 || cantNucleosDec > decimal.MaxValue)
                {
                    MessageBox.Show(
                        "La cantidad de núcleos debe ser entre 1 y 255.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                cantNucleos = (byte)cantNucleosDec;
                if (cantNucleos != cantNucleosDec)
                {
                    MessageBox.Show(
                        "La cantidad de núcleos no puede ser un número decimal.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }

            uint quantum;
            {
                decimal quantumDec = this.quantumNum.Value;
                if (quantumDec <= 0)
                {
                    MessageBox.Show(
                        "El quantum debe ser una cantidad positiva.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (quantumDec > uint.MaxValue)
                {
                    MessageBox.Show(
                        "El quantum dado es demasiado grande para el programa.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                quantum = (uint)quantumDec;
                if (quantum != quantumDec)
                {
                    MessageBox.Show(
                        "El quantum no puede ser un número decimal.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

            }

            MessageBox.Show("Iniciando simulador... :P");
        }
    }
}
using System.Windows.Forms;

namespace ProyectoSO
{
    partial class PrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cantNucleosLabel = new System.Windows.Forms.Label();
            this.quantumLabel = new System.Windows.Forms.Label();
            this.cantNucleosNum = new System.Windows.Forms.NumericUpDown();
            this.quantumNum = new System.Windows.Forms.NumericUpDown();
            this.iniciarBtn = new System.Windows.Forms.Button();
            this.limpiarBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cantNucleosNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantumNum)).BeginInit();
            this.SuspendLayout();
            // 
            // cantNucleosLabel
            // 
            this.cantNucleosLabel.AutoSize = true;
            this.cantNucleosLabel.Font = new System.Drawing.Font("Consolas", 12F);
            this.cantNucleosLabel.Location = new System.Drawing.Point(35, 30);
            this.cantNucleosLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cantNucleosLabel.Name = "cantNucleosLabel";
            this.cantNucleosLabel.Size = new System.Drawing.Size(241, 23);
            this.cantNucleosLabel.TabIndex = 0;
            this.cantNucleosLabel.Text = "Cantidad de núcleos: ";
            // 
            // quantumLabel
            // 
            this.quantumLabel.AutoSize = true;
            this.quantumLabel.Font = new System.Drawing.Font("Consolas", 12F);
            this.quantumLabel.Location = new System.Drawing.Point(35, 82);
            this.quantumLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.quantumLabel.Name = "quantumLabel";
            this.quantumLabel.Size = new System.Drawing.Size(285, 23);
            this.quantumLabel.TabIndex = 1;
            this.quantumLabel.Text = "Quantum (microsegundos): ";
            // 
            // cantNucleosNum
            // 
            this.cantNucleosNum.Font = new System.Drawing.Font("Consolas", 12F);
            this.cantNucleosNum.Location = new System.Drawing.Point(284, 28);
            this.cantNucleosNum.Margin = new System.Windows.Forms.Padding(4);
            this.cantNucleosNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cantNucleosNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantNucleosNum.Name = "cantNucleosNum";
            this.cantNucleosNum.Size = new System.Drawing.Size(92, 31);
            this.cantNucleosNum.TabIndex = 0;
            this.cantNucleosNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // quantumNum
            // 
            this.quantumNum.Font = new System.Drawing.Font("Consolas", 12F);
            this.quantumNum.Location = new System.Drawing.Point(328, 80);
            this.quantumNum.Margin = new System.Windows.Forms.Padding(4);
            this.quantumNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.quantumNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantumNum.Name = "quantumNum";
            this.quantumNum.Size = new System.Drawing.Size(147, 31);
            this.quantumNum.TabIndex = 1;
            this.quantumNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iniciarBtn
            // 
            this.iniciarBtn.Font = new System.Drawing.Font("Consolas", 12F);
            this.iniciarBtn.Location = new System.Drawing.Point(39, 149);
            this.iniciarBtn.Margin = new System.Windows.Forms.Padding(4);
            this.iniciarBtn.Name = "iniciarBtn";
            this.iniciarBtn.Size = new System.Drawing.Size(147, 63);
            this.iniciarBtn.TabIndex = 2;
            this.iniciarBtn.Text = "Iniciar";
            this.iniciarBtn.UseVisualStyleBackColor = true;
            this.iniciarBtn.Click += new System.EventHandler(this.IniciarBtn_Click);
            // 
            // limpiarBtn
            // 
            this.limpiarBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.limpiarBtn.Font = new System.Drawing.Font("Consolas", 12F);
            this.limpiarBtn.Location = new System.Drawing.Point(313, 149);
            this.limpiarBtn.Margin = new System.Windows.Forms.Padding(4);
            this.limpiarBtn.Name = "limpiarBtn";
            this.limpiarBtn.Size = new System.Drawing.Size(147, 63);
            this.limpiarBtn.TabIndex = 3;
            this.limpiarBtn.Text = "Limpiar";
            this.limpiarBtn.UseVisualStyleBackColor = true;
            this.limpiarBtn.Click += new System.EventHandler(this.LimpiarBtn_Click);
            // 
            // PrincipalForm
            // 
            this.AcceptButton = this.iniciarBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.limpiarBtn;
            this.ClientSize = new System.Drawing.Size(506, 235);
            this.Controls.Add(this.limpiarBtn);
            this.Controls.Add(this.iniciarBtn);
            this.Controls.Add(this.quantumNum);
            this.Controls.Add(this.cantNucleosNum);
            this.Controls.Add(this.quantumLabel);
            this.Controls.Add(this.cantNucleosLabel);
            this.Font = new System.Drawing.Font("Consolas", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "PrincipalForm";
            this.Text = "Simulador de Round Robin";
            ((System.ComponentModel.ISupportInitialize)(this.cantNucleosNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantumNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label cantNucleosLabel;
        private Label quantumLabel;
        private NumericUpDown cantNucleosNum;
        private NumericUpDown quantumNum;
        private Button iniciarBtn;
        private Button limpiarBtn;
    }
}
namespace ProyectoSO
{
    partial class Form1
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
            this.CantNucleosLabel = new System.Windows.Forms.Label();
            this.QuantumLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CantNucleosLabel
            // 
            this.CantNucleosLabel.AutoSize = true;
            this.CantNucleosLabel.Font = new System.Drawing.Font("Consolas", 12F);
            this.CantNucleosLabel.Location = new System.Drawing.Point(35, 29);
            this.CantNucleosLabel.Name = "CantNucleosLabel";
            this.CantNucleosLabel.Size = new System.Drawing.Size(241, 23);
            this.CantNucleosLabel.TabIndex = 0;
            this.CantNucleosLabel.Text = "Cantidad de núcleos: ";
            // 
            // QuantumLabel
            // 
            this.QuantumLabel.AutoSize = true;
            this.QuantumLabel.Font = new System.Drawing.Font("Consolas", 12F);
            this.QuantumLabel.Location = new System.Drawing.Point(35, 80);
            this.QuantumLabel.Name = "QuantumLabel";
            this.QuantumLabel.Size = new System.Drawing.Size(285, 23);
            this.QuantumLabel.TabIndex = 1;
            this.QuantumLabel.Text = "Quantum (microsegundos): ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 425);
            this.Controls.Add(this.QuantumLabel);
            this.Controls.Add(this.CantNucleosLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label CantNucleosLabel;
        private Label QuantumLabel;
    }
}
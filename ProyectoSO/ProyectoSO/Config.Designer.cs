namespace ProyectoSO
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numPrioridad = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.checkBloqueado = new System.Windows.Forms.CheckBox();
            this.listProcesos = new System.Windows.Forms.ListBox();
            this.pnlForm = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numPrioridad)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(622, 47);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(167, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(619, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Proceso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prioridad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bloqueado";
            // 
            // numPrioridad
            // 
            this.numPrioridad.Location = new System.Drawing.Point(20, 59);
            this.numPrioridad.Margin = new System.Windows.Forms.Padding(4);
            this.numPrioridad.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numPrioridad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPrioridad.Name = "numPrioridad";
            this.numPrioridad.Size = new System.Drawing.Size(168, 22);
            this.numPrioridad.TabIndex = 9;
            this.numPrioridad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::ProyectoSO.Properties.Resources.icons8_done_48;
            this.btnAceptar.Location = new System.Drawing.Point(20, 156);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(64, 59);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::ProyectoSO.Properties.Resources.icons8_close_48;
            this.btnCancelar.Location = new System.Drawing.Point(124, 156);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(64, 59);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // checkBloqueado
            // 
            this.checkBloqueado.AutoSize = true;
            this.checkBloqueado.Location = new System.Drawing.Point(94, 126);
            this.checkBloqueado.Margin = new System.Windows.Forms.Padding(4);
            this.checkBloqueado.Name = "checkBloqueado";
            this.checkBloqueado.Size = new System.Drawing.Size(18, 17);
            this.checkBloqueado.TabIndex = 16;
            this.checkBloqueado.UseVisualStyleBackColor = true;
            // 
            // listProcesos
            // 
            this.listProcesos.Font = new System.Drawing.Font("Consolas", 8F);
            this.listProcesos.FormattingEnabled = true;
            this.listProcesos.ItemHeight = 15;
            this.listProcesos.Items.AddRange(new object[] {
            ""});
            this.listProcesos.Location = new System.Drawing.Point(12, 12);
            this.listProcesos.Name = "listProcesos";
            this.listProcesos.Size = new System.Drawing.Size(581, 484);
            this.listProcesos.TabIndex = 17;
            this.listProcesos.SelectedIndexChanged += new System.EventHandler(this.listProcesos_SelectedIndexChanged);
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.btnAceptar);
            this.pnlForm.Controls.Add(this.btnCancelar);
            this.pnlForm.Controls.Add(this.label2);
            this.pnlForm.Controls.Add(this.numPrioridad);
            this.pnlForm.Controls.Add(this.checkBloqueado);
            this.pnlForm.Controls.Add(this.label3);
            this.pnlForm.Location = new System.Drawing.Point(599, 88);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(212, 237);
            this.pnlForm.TabIndex = 18;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 513);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.listProcesos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Config";
            this.Text = "Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Config_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numPrioridad)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPrioridad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkBloqueado;
        private System.Windows.Forms.ListBox listProcesos;
        private System.Windows.Forms.Panel pnlForm;
    }
}
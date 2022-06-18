namespace ProyectoSO
{
    partial class AñadirProceso
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
            this.checkKernel = new System.Windows.Forms.CheckBox();
            this.numPrioridadProceso = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreProceso = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnBorrarTabla = new System.Windows.Forms.Button();
            this.btnCargarProcesos = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.numTiempoEjec = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPrioridadProceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTiempoEjec)).BeginInit();
            this.SuspendLayout();
            // 
            // checkKernel
            // 
            this.checkKernel.AutoSize = true;
            this.checkKernel.Location = new System.Drawing.Point(710, 188);
            this.checkKernel.Margin = new System.Windows.Forms.Padding(4);
            this.checkKernel.Name = "checkKernel";
            this.checkKernel.Size = new System.Drawing.Size(18, 17);
            this.checkKernel.TabIndex = 2;
            this.checkKernel.UseVisualStyleBackColor = true;
            // 
            // numPrioridadProceso
            // 
            this.numPrioridadProceso.Location = new System.Drawing.Point(636, 113);
            this.numPrioridadProceso.Margin = new System.Windows.Forms.Padding(4);
            this.numPrioridadProceso.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numPrioridadProceso.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPrioridadProceso.Name = "numPrioridadProceso";
            this.numPrioridadProceso.Size = new System.Drawing.Size(168, 22);
            this.numPrioridadProceso.TabIndex = 1;
            this.numPrioridadProceso.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(696, 168);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Kernel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(633, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Prioridad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(633, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Proceso";
            // 
            // txtNombreProceso
            // 
            this.txtNombreProceso.Location = new System.Drawing.Point(636, 54);
            this.txtNombreProceso.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreProceso.MaxLength = 20;
            this.txtNombreProceso.Name = "txtNombreProceso";
            this.txtNombreProceso.Size = new System.Drawing.Size(167, 22);
            this.txtNombreProceso.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::ProyectoSO.Properties.Resources.icons8_done_48;
            this.btnAceptar.Location = new System.Drawing.Point(636, 311);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(64, 59);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnBorrarTabla
            // 
            this.btnBorrarTabla.Image = global::ProyectoSO.Properties.Resources.icons8_close_48;
            this.btnBorrarTabla.Location = new System.Drawing.Point(739, 311);
            this.btnBorrarTabla.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorrarTabla.Name = "btnBorrarTabla";
            this.btnBorrarTabla.Size = new System.Drawing.Size(64, 59);
            this.btnBorrarTabla.TabIndex = 5;
            this.btnBorrarTabla.UseVisualStyleBackColor = true;
            this.btnBorrarTabla.Click += new System.EventHandler(this.btnBorrarTabla_Click);
            // 
            // btnCargarProcesos
            // 
            this.btnCargarProcesos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCargarProcesos.FlatAppearance.BorderSize = 5;
            this.btnCargarProcesos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnCargarProcesos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCargarProcesos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCargarProcesos.Location = new System.Drawing.Point(205, 368);
            this.btnCargarProcesos.Margin = new System.Windows.Forms.Padding(4);
            this.btnCargarProcesos.Name = "btnCargarProcesos";
            this.btnCargarProcesos.Size = new System.Drawing.Size(189, 32);
            this.btnCargarProcesos.TabIndex = 6;
            this.btnCargarProcesos.Text = "Cargar Procesos";
            this.btnCargarProcesos.UseVisualStyleBackColor = true;
            this.btnCargarProcesos.Click += new System.EventHandler(this.btnCargarProcesos_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Consolas", 8F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            ""});
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(595, 349);
            this.listBox1.TabIndex = 27;
            this.listBox1.TabStop = false;
            // 
            // numTiempoEjec
            // 
            this.numTiempoEjec.Location = new System.Drawing.Point(636, 250);
            this.numTiempoEjec.Margin = new System.Windows.Forms.Padding(4);
            this.numTiempoEjec.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTiempoEjec.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTiempoEjec.Name = "numTiempoEjec";
            this.numTiempoEjec.Size = new System.Drawing.Size(168, 22);
            this.numTiempoEjec.TabIndex = 3;
            this.numTiempoEjec.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(633, 230);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Tiempo total de ejecucion (microsegundos)";
            // 
            // AñadirProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 418);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numTiempoEjec);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnCargarProcesos);
            this.Controls.Add(this.checkKernel);
            this.Controls.Add(this.btnBorrarTabla);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.numPrioridadProceso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreProceso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AñadirProceso";
            this.Text = "AñadirProceso";
            ((System.ComponentModel.ISupportInitialize)(this.numPrioridadProceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTiempoEjec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkKernel;
        private System.Windows.Forms.NumericUpDown numPrioridadProceso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreProceso;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnBorrarTabla;
        private System.Windows.Forms.Button btnCargarProcesos;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.NumericUpDown numTiempoEjec;
        private System.Windows.Forms.Label label4;
    }
}
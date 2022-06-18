namespace ProyectoSO
{
    partial class Simulador
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddProcesses = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listProcesosListos = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listProcesosEjec = new System.Windows.Forms.ListBox();
            this.listProcesosBloq = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = global::ProyectoSO.Properties.Resources.icons8_play_or_pause_button_48;
            this.button1.Location = new System.Drawing.Point(154, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 43);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnAddProcesses
            // 
            this.btnAddProcesses.Image = global::ProyectoSO.Properties.Resources.icons8_plus_48;
            this.btnAddProcesses.Location = new System.Drawing.Point(226, 252);
            this.btnAddProcesses.Name = "btnAddProcesses";
            this.btnAddProcesses.Size = new System.Drawing.Size(47, 43);
            this.btnAddProcesses.TabIndex = 4;
            this.btnAddProcesses.UseVisualStyleBackColor = true;
            this.btnAddProcesses.Click += new System.EventHandler(this.btnAddProcesses_Click);
            // 
            // button3
            // 
            this.button3.Image = global::ProyectoSO.Properties.Resources.icons8_configuration_24;
            this.button3.Location = new System.Drawing.Point(295, 254);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 41);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // listProcesosListos
            // 
            this.listProcesosListos.FormattingEnabled = true;
            this.listProcesosListos.ItemHeight = 16;
            this.listProcesosListos.Items.AddRange(new object[] {
            ""});
            this.listProcesosListos.Location = new System.Drawing.Point(3, 3);
            this.listProcesosListos.Name = "listProcesosListos";
            this.listProcesosListos.Size = new System.Drawing.Size(179, 228);
            this.listProcesosListos.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.listProcesosBloq, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.listProcesosEjec, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listProcesosListos, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(557, 234);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // listProcesosEjec
            // 
            this.listProcesosEjec.FormattingEnabled = true;
            this.listProcesosEjec.ItemHeight = 16;
            this.listProcesosEjec.Items.AddRange(new object[] {
            ""});
            this.listProcesosEjec.Location = new System.Drawing.Point(188, 3);
            this.listProcesosEjec.Name = "listProcesosEjec";
            this.listProcesosEjec.Size = new System.Drawing.Size(179, 228);
            this.listProcesosEjec.TabIndex = 7;
            // 
            // listProcesosBloq
            // 
            this.listProcesosBloq.FormattingEnabled = true;
            this.listProcesosBloq.ItemHeight = 16;
            this.listProcesosBloq.Items.AddRange(new object[] {
            ""});
            this.listProcesosBloq.Location = new System.Drawing.Point(373, 3);
            this.listProcesosBloq.Name = "listProcesosBloq";
            this.listProcesosBloq.Size = new System.Drawing.Size(179, 228);
            this.listProcesosBloq.TabIndex = 8;
            // 
            // Simulador
            // 
            this.ClientSize = new System.Drawing.Size(571, 391);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAddProcesses);
            this.Controls.Add(this.button1);
            this.Name = "Simulador";
            this.Load += new System.EventHandler(this.Simulador_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button config;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddProcesses;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listProcesosListos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listProcesosBloq;
        private System.Windows.Forms.ListBox listProcesosEjec;
    }
}
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
            this.btnIniciarDetener = new System.Windows.Forms.Button();
            this.btnAddProcesses = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.listProcesosListos = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listProcesosBloq = new System.Windows.Forms.ListBox();
            this.listProcesosEjec = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIniciarDetener
            // 
            this.btnIniciarDetener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarDetener.Image = global::ProyectoSO.Properties.Resources.icons8_play_or_pause_button_48;
            this.btnIniciarDetener.Location = new System.Drawing.Point(240, 252);
            this.btnIniciarDetener.Name = "btnIniciarDetener";
            this.btnIniciarDetener.Size = new System.Drawing.Size(48, 43);
            this.btnIniciarDetener.TabIndex = 0;
            this.btnIniciarDetener.UseVisualStyleBackColor = true;
            this.btnIniciarDetener.Click += new System.EventHandler(this.btnIniciarDetener_Click);
            // 
            // btnAddProcesses
            // 
            this.btnAddProcesses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProcesses.Image = global::ProyectoSO.Properties.Resources.icons8_plus_48;
            this.btnAddProcesses.Location = new System.Drawing.Point(312, 252);
            this.btnAddProcesses.Name = "btnAddProcesses";
            this.btnAddProcesses.Size = new System.Drawing.Size(47, 43);
            this.btnAddProcesses.TabIndex = 1;
            this.btnAddProcesses.UseVisualStyleBackColor = true;
            this.btnAddProcesses.Click += new System.EventHandler(this.btnAddProcesses_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Image = global::ProyectoSO.Properties.Resources.icons8_configuration_24;
            this.btnConfig.Location = new System.Drawing.Point(381, 254);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(47, 41);
            this.btnConfig.TabIndex = 2;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // listProcesosListos
            // 
            this.listProcesosListos.Font = new System.Drawing.Font("Consolas", 8F);
            this.listProcesosListos.FormattingEnabled = true;
            this.listProcesosListos.ItemHeight = 15;
            this.listProcesosListos.Items.AddRange(new object[] {
            ""});
            this.listProcesosListos.Location = new System.Drawing.Point(3, 3);
            this.listProcesosListos.Name = "listProcesosListos";
            this.listProcesosListos.Size = new System.Drawing.Size(216, 214);
            this.listProcesosListos.TabIndex = 6;
            this.listProcesosListos.TabStop = false;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(668, 234);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // listProcesosBloq
            // 
            this.listProcesosBloq.Font = new System.Drawing.Font("Consolas", 8F);
            this.listProcesosBloq.FormattingEnabled = true;
            this.listProcesosBloq.ItemHeight = 15;
            this.listProcesosBloq.Items.AddRange(new object[] {
            ""});
            this.listProcesosBloq.Location = new System.Drawing.Point(447, 3);
            this.listProcesosBloq.Name = "listProcesosBloq";
            this.listProcesosBloq.Size = new System.Drawing.Size(218, 214);
            this.listProcesosBloq.TabIndex = 8;
            this.listProcesosBloq.TabStop = false;
            // 
            // listProcesosEjec
            // 
            this.listProcesosEjec.Font = new System.Drawing.Font("Consolas", 8F);
            this.listProcesosEjec.FormattingEnabled = true;
            this.listProcesosEjec.ItemHeight = 15;
            this.listProcesosEjec.Items.AddRange(new object[] {
            ""});
            this.listProcesosEjec.Location = new System.Drawing.Point(225, 3);
            this.listProcesosEjec.Name = "listProcesosEjec";
            this.listProcesosEjec.Size = new System.Drawing.Size(216, 214);
            this.listProcesosEjec.TabIndex = 7;
            this.listProcesosEjec.TabStop = false;
            // 
            // Simulador
            // 
            this.ClientSize = new System.Drawing.Size(682, 308);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnAddProcesses);
            this.Controls.Add(this.btnIniciarDetener);
            this.Name = "Simulador";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarDetener;
        private System.Windows.Forms.Button btnAddProcesses;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.ListBox listProcesosListos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listProcesosBloq;
        private System.Windows.Forms.ListBox listProcesosEjec;
    }
}
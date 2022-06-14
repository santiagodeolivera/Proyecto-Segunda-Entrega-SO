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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ColaProcesos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.colaEJEc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.procBloc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColaProcesos});
            this.dataGridView2.Location = new System.Drawing.Point(12, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(161, 207);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // ColaProcesos
            // 
            this.ColaProcesos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColaProcesos.HeaderText = "Cola Procesos Listos";
            this.ColaProcesos.Name = "ColaProcesos";
            this.ColaProcesos.Width = 119;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colaEJEc});
            this.dataGridView3.Location = new System.Drawing.Point(191, 12);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(151, 207);
            this.dataGridView3.TabIndex = 1;
            // 
            // colaEJEc
            // 
            this.colaEJEc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colaEJEc.HeaderText = "Cola Procesos En ejecucion";
            this.colaEJEc.Name = "colaEJEc";
            this.colaEJEc.Width = 109;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.procBloc});
            this.dataGridView4.Location = new System.Drawing.Point(363, 12);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(151, 207);
            this.dataGridView4.TabIndex = 2;
            this.dataGridView4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellContentClick);
            // 
            // procBloc
            // 
            this.procBloc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.procBloc.HeaderText = "Cola Procesos Bloqueados";
            this.procBloc.Name = "procBloc";
            this.procBloc.Width = 145;
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
            // button2
            // 
            this.button2.Image = global::ProyectoSO.Properties.Resources.icons8_plus_48;
            this.button2.Location = new System.Drawing.Point(226, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 43);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // Simulador
            // 
            this.ClientSize = new System.Drawing.Size(571, 391);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Name = "Simulador";
            this.Load += new System.EventHandler(this.Simulador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColaProcesosListos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColaProcesosEnEjecucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColaDeProcesosBloqueados;
        private System.Windows.Forms.Button config;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColaProcesos;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colaEJEc;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn procBloc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
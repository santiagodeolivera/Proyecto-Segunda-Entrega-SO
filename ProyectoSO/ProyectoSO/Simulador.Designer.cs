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
            this.procesosListosList = new System.Windows.Forms.ListBox();
            this.procesosListosLabel = new System.Windows.Forms.Label();
            this.procesosCpuList = new System.Windows.Forms.ListBox();
            this.procesosCpuLabel = new System.Windows.Forms.Label();
            this.procesosBloqueadosLabel = new System.Windows.Forms.Label();
            this.procesosBloqueadosList = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // procesosListosList
            // 
            this.procesosListosList.Font = new System.Drawing.Font("Consolas", 10F);
            this.procesosListosList.FormattingEnabled = true;
            this.procesosListosList.ItemHeight = 20;
            this.procesosListosList.Location = new System.Drawing.Point(19, 30);
            this.procesosListosList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.procesosListosList.Name = "procesosListosList";
            this.procesosListosList.Size = new System.Drawing.Size(150, 244);
            this.procesosListosList.TabIndex = 0;
            // 
            // procesosListosLabel
            // 
            this.procesosListosLabel.AutoSize = true;
            this.procesosListosLabel.Location = new System.Drawing.Point(15, 3);
            this.procesosListosLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.procesosListosLabel.Name = "procesosListosLabel";
            this.procesosListosLabel.Size = new System.Drawing.Size(263, 23);
            this.procesosListosLabel.TabIndex = 1;
            this.procesosListosLabel.Text = "Cola de procesos listos";
            // 
            // procesosCpuList
            // 
            this.procesosCpuList.Font = new System.Drawing.Font("Consolas", 10F);
            this.procesosCpuList.FormattingEnabled = true;
            this.procesosCpuList.ItemHeight = 20;
            this.procesosCpuList.Location = new System.Drawing.Point(365, 46);
            this.procesosCpuList.Margin = new System.Windows.Forms.Padding(4);
            this.procesosCpuList.Name = "procesosCpuList";
            this.procesosCpuList.Size = new System.Drawing.Size(139, 124);
            this.procesosCpuList.TabIndex = 2;
            // 
            // procesosCpuLabel
            // 
            this.procesosCpuLabel.AutoSize = true;
            this.procesosCpuLabel.Location = new System.Drawing.Point(329, 3);
            this.procesosCpuLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.procesosCpuLabel.Name = "procesosCpuLabel";
            this.procesosCpuLabel.Size = new System.Drawing.Size(175, 23);
            this.procesosCpuLabel.TabIndex = 3;
            this.procesosCpuLabel.Text = "Procesos en CPU";
            // 
            // procesosBloqueadosLabel
            // 
            this.procesosBloqueadosLabel.AutoSize = true;
            this.procesosBloqueadosLabel.Location = new System.Drawing.Point(248, 234);
            this.procesosBloqueadosLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.procesosBloqueadosLabel.Name = "procesosBloqueadosLabel";
            this.procesosBloqueadosLabel.Size = new System.Drawing.Size(219, 23);
            this.procesosBloqueadosLabel.TabIndex = 4;
            this.procesosBloqueadosLabel.Text = "Procesos bloqueados";
            // 
            // procesosBloqueadosList
            // 
            this.procesosBloqueadosList.Font = new System.Drawing.Font("Consolas", 10F);
            this.procesosBloqueadosList.FormattingEnabled = true;
            this.procesosBloqueadosList.ItemHeight = 20;
            this.procesosBloqueadosList.Location = new System.Drawing.Point(252, 275);
            this.procesosBloqueadosList.Margin = new System.Windows.Forms.Padding(4);
            this.procesosBloqueadosList.Name = "procesosBloqueadosList";
            this.procesosBloqueadosList.Size = new System.Drawing.Size(150, 164);
            this.procesosBloqueadosList.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1158, 449);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.procesosListosLabel);
            this.panel1.Controls.Add(this.procesosCpuLabel);
            this.panel1.Controls.Add(this.procesosListosList);
            this.panel1.Controls.Add(this.procesosBloqueadosLabel);
            this.panel1.Controls.Add(this.procesosBloqueadosList);
            this.panel1.Controls.Add(this.procesosCpuList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 443);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(582, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 443);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(871, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(284, 443);
            this.panel3.TabIndex = 2;
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 473);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Consolas", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Simulador";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox procesosListosList;
        private System.Windows.Forms.Label procesosListosLabel;
        private System.Windows.Forms.ListBox procesosCpuList;
        private System.Windows.Forms.Label procesosCpuLabel;
        private System.Windows.Forms.Label procesosBloqueadosLabel;
        private System.Windows.Forms.ListBox procesosBloqueadosList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
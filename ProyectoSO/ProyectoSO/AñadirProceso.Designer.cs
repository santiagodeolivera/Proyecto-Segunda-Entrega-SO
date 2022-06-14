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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ConfigProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigPrioridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigKernel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(523, 148);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(477, 92);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(126, 20);
            this.numericUpDown1.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(512, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Kernel";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Prioridad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Proceso";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(477, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(126, 20);
            this.textBox1.TabIndex = 18;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConfigProcess,
            this.ConfigPrioridad,
            this.ConfigKernel});
            this.dataGridView1.Location = new System.Drawing.Point(33, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(416, 243);
            this.dataGridView1.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Image = global::ProyectoSO.Properties.Resources.icons8_done_48;
            this.button1.Location = new System.Drawing.Point(475, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 48);
            this.button1.TabIndex = 23;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = global::ProyectoSO.Properties.Resources.icons8_close_48;
            this.button2.Location = new System.Drawing.Point(553, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 48);
            this.button2.TabIndex = 24;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ConfigProcess
            // 
            this.ConfigProcess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ConfigProcess.HeaderText = "Procesos";
            this.ConfigProcess.Name = "ConfigProcess";
            // 
            // ConfigPrioridad
            // 
            this.ConfigPrioridad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ConfigPrioridad.HeaderText = "Prioridad";
            this.ConfigPrioridad.Name = "ConfigPrioridad";
            // 
            // ConfigKernel
            // 
            this.ConfigKernel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ConfigKernel.HeaderText = "Kernel";
            this.ConfigKernel.Name = "ConfigKernel";
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.BorderSize = 5;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(224, 314);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 26);
            this.button3.TabIndex = 26;
            this.button3.Text = "Cargar Procesos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AñadirProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 389);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AñadirProceso";
            this.Text = "AñadirProceso";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigPrioridad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigKernel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSO
{
    public partial class Simulador : Form
    {
        public Simulador()
        {
            InitializeComponent();
            {
                Point location = this.StartStopBtn.Location;
                this.StartStopBtn.Location = new Point(location.X, (this.botonesPanel.Height - this.StartStopBtn.Height) / 2);
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "You clicked the button!";
        }

        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            label1.Text = "Closing in";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Closing in";
        }
    }
}

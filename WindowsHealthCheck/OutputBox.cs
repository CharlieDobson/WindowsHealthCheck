﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsHealthCheck
{
    public partial class OutputBox : Form
    {
        public OutputBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetText(string text)
        {
            textBox1.Text = text;
        }
    }
}

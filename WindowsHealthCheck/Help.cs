using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsHealthCheck
{
    public partial class Help : Form
    {
        public Help(Color Background, Color Text)
        {
            InitializeComponent();

            this.BackColor = Background;
            this.ForeColor = Text;
            //groupBox1.ForeColor = Text;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            okBtn.BackColor = Color.LightGray;
        }
    }
}

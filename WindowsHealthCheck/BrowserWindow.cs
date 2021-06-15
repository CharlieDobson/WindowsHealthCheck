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
    public partial class BrowserWindow : Form
    {
        public BrowserWindow(string WindowTitle, Uri Url, Color Background)
        {
            InitializeComponent();

            this.Text = WindowTitle;
            webBrowser1.Url = Url;
            this.BackColor = Background;
        }

        private void BrowserWindow_Load(object sender, EventArgs e)
        {

        }
    }
}

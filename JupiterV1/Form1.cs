using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JupiterV1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point lastPoint;
        private void button2_Click(object sender, EventArgs e)
        {
            Jupiter main = new Jupiter();
            if (textBox1.Text == "BnYexATHuE") 
            { 
                this.Hide(); main.Show(); 
            }
            else
            {
                textBox1.Text = "Key Incorrect";
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://linkvertise.com/459238/jupiter-key-system/1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/cwmFG4j85p");
        }
    }
}

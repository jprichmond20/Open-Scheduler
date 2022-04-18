using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schedule2
{
    public partial class Form1 : Form
    {
        public Director user;
        int counter = 0;
        public Form1(Director user)
        {
            this.user = user;
            InitializeComponent();
            

           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            

            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                counter++;
                progressBar1.Value = counter;
            }
            else
            {
                timer1.Enabled = false;
                var frm = new ScheduleView(user);
                this.Hide();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Close(); };
                frm.Show();
            }
            

        }
    }
}

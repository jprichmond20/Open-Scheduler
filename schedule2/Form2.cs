using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schedule2
{
    public partial class Form2 : Form
    {
        public Director user;
        public Form2(Director user)
        {
            InitializeComponent();
            this.user = user;

         }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 2;
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Schedule Successfully Updated!");
                var frm = new ScheduleView(user);
                this.Hide();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Close(); };
                frm.Show();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}

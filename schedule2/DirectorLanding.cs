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
    public partial class DirectorLanding : Form
    {
        public User user;
        public DirectorLanding()
        {
            //this.user = user;
            //User user
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void class12_Click(object sender, EventArgs e)
        {

        }

        private void class11_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new ScheduleView();
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void class13_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new RegScheduler(user);
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }
    }
}

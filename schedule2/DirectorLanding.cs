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
    //Only accessible by director users
    public partial class DirectorLanding : Form
    // This form is the directors landing page
    {
        public Director user;
        public DirectorLanding(Director user)
        {
            this.user = user;
            InitializeComponent();
        }

        
        private void class11_Click(object sender, EventArgs e)
        //Button to allow user to view the current schedule
        {
            this.Hide();
            var frm = new ScheduleView(user);
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void class13_Click(object sender, EventArgs e)
        //Allow director to open up the schedule creator to set new hours of operation
        // or modify the current hours of operation
        {

            this.Hide();
            var frm = new DirScheduler((Director)user);
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void class12_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            var frm = new RunForm(user);
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
            */
            Program.db.director_settings.multiple_majors = checkBox1.Checked;
            Program.db.director_settings.mix_ages = checkBox2.Checked;
            Program.db.director_settings.multiple_shifts = checkBox3.Checked;
            Database.UserListSchedule userSchedule = Program.db.createSchedule();
            Program.db.saveSchedule(userSchedule);
            var frm = new ScheduleView(user);
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void class14_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new SignIn();
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void DirectorLanding_Load(object sender, EventArgs e)
        {

        }
        
    }
}

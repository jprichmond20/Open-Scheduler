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
    public partial class RunForm : Form
    {
        public Director user;
        public RunForm(Director user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void class12_Click(object sender, EventArgs e)
        {
            Database.UserListSchedule userSchedule = Program.db.createSchedule();
            Program.db.saveSchedule(userSchedule);
            var frm = new ScheduleView();
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void class11_Click(object sender, EventArgs e)
        {
            var frm = new DirectorLanding(user);
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void class12_Click_1(object sender, EventArgs e)
        {
            var frm = new SignIn();
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }
    }
}

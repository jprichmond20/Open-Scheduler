using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        List<Consultant> short_list = new List<Consultant>();
        public Director user;
        public string short_names;
        public DirectorLanding(Director user)
        {
            List<Consultant> consultant_list = Program.db.getAllConsultants();
            File.WriteAllText("short_list.txt", "");
            foreach (Consultant c in consultant_list)
            {
                if (c.numberOfShifts/2 < int.Parse(c.hoursPer))
                {
                    short_list.Add(c);
                }
            }
            foreach (Consultant c in short_list)
            {
                File.AppendAllText("short_list.txt", c.getFirstandLast() + "\n");
            }
            this.user = user;
            string[] list_settings = File.ReadAllLines("dir_settings.txt");
            
                if (list_settings[0] == "True")
                {
                    Program.db.director_settings.multiple_majors = true;
                }
                else
                {
                    Program.db.director_settings.multiple_majors = false;
                }
                if (list_settings[1] == "True")
                {
                    Program.db.director_settings.mix_ages = true;
                }
                else
                {
                    Program.db.director_settings.mix_ages = false;
                }
                if (list_settings[2] == "True")
                {
                    Program.db.director_settings.multiple_shifts = true;
                }
                else
                {
                    Program.db.director_settings.multiple_shifts = false;
                }

                Program.db.director_settings.num_consultants_max = int.Parse(list_settings[3]);
                Program.db.director_settings.num_consultants_min = int.Parse(list_settings[4]);
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
            Program.db.director_settings.num_consultants_max = (int)numericUpDown1.Value;
            Program.db.director_settings.num_consultants_min = ((int)numericUpDown1.Value)-2;
            File.WriteAllText("dir_settings.txt", "");
            File.AppendAllText("dir_settings.txt", Program.db.director_settings.multiple_majors.ToString() + "\n");
            File.AppendAllText("dir_settings.txt", Program.db.director_settings.mix_ages.ToString() + "\n");
            File.AppendAllText("dir_settings.txt", Program.db.director_settings.multiple_shifts.ToString() + "\n"); 
            File.AppendAllText("dir_settings.txt", Program.db.director_settings.num_consultants_max.ToString() + "\n");
            File.AppendAllText("dir_settings.txt", Program.db.director_settings.num_consultants_min.ToString());
            Database.UserListSchedule userSchedule = Program.db.createSchedule();
            Program.db.saveSchedule(userSchedule);
            var frm = new Form2(user);
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void class14_Click(object sender, EventArgs e)
        {
            Program.db.CsvExport();
        }

        private void DirectorLanding_Load(object sender, EventArgs e)
        {
            if (Program.db.director_settings.multiple_majors)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            if (Program.db.director_settings.mix_ages)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
            if (Program.db.director_settings.multiple_shifts)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
            numericUpDown1.Value = Program.db.director_settings.num_consultants_max;
        }

        private void class15_Click(object sender, EventArgs e)
        {
            short_names = "Consultants without desired number of shifts: \n";
            foreach (Consultant c in short_list)
            {
                short_names += c.getFirstandLast() + "\n";
                
            }
            MessageBox.Show(short_names);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void class16_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new SignIn();
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }
    }
}

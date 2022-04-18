﻿using System;
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
            File.AppendAllText("dir_settings.txt", Program.db.director_settings.num_consultants_min.ToString() + "\n");
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

        private void class15_Click(object sender, EventArgs e)
        {
            short_names = "Consultants without desired number of shifts: \n";
            foreach (Consultant c in short_list)
            {
                short_names += c.getFirstandLast() + "\n";
                
            }
            MessageBox.Show(short_names);
        }
    }
}

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

    public partial class DirScheduler : Form
    // This form allows a director to set or change the writing center schedule
    // director will have button to allow them to import past shcedules
    {
        public Director user;
        String[] times = new String[] {"12:00am", "12:30am", "1:00am", "1:30am", "2:00am", "2:30am", "3:00am",
            "3:30am", "4:00am", "4:30am", "5:00am","5:30am","6:00am","6:30am","7:00am", "7:30am", "8:00am", "8:30am", "9:00am", "9:30am",
            "10:00am", "10:30am", "11:00am", "11:30am", "12:00pm", "12:30pm", "1:00pm", "1:30pm", "2:00pm", "2:30pm",
            "3:00pm", "3:30pm", "4:00pm","4:30pm", "5:00pm", "5:30pm", "6:00pm", "6:30pm", "7:00pm", "7:30pm", "8:00pm",
            "8:30pm", "9:00pm", "9:30pm", "10:00pm", "10:30pm", "11:00pm", "11:30pm"};
        public DirScheduler(Director user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void DirScheduler_Load(object sender, EventArgs e)
        {
            // Intialize event handler for when the user selection changes
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
            // Tell it not to create columns automatically
            dataGridView1.AutoGenerateColumns = false;
            // intialize column and row headers
            dataGridView1.TopLeftHeaderCell.Value = "Time";
            dataGridView1.Columns.Add("Monday", "Mon");
            dataGridView1.Columns.Add("Tuesday", "Tues");
            dataGridView1.Columns.Add("Wednesday", "Wed");
            dataGridView1.Columns.Add("Thursday", "Thurs");
            dataGridView1.Columns.Add("Friday", "Fri");
            dataGridView1.Columns.Add("Saturday", "Sat");
            dataGridView1.Columns.Add("Sunday", "Sun");
            // Populate the data grid with "data" (just nothing)
            for (int i = 0; i < times.Length; i++)
            {
                dataGridView1.Rows.Add(new object[] {"", "", "", "", "", "", "" });
                dataGridView1.Rows[i].HeaderCell.Value = times[i];
            }
            dataGridView1.FirstDisplayedCell.Selected = false;
            // Set the columns to autosize and set the default backcolor 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView1.RowHeadersWidth = 100;
            dataGridView1.DefaultCellStyle.BackColor = Color.Gainsboro;
            //MessageBox.Show(dataGridView1.Rows.Count.ToString());
            // Read in the current schedule from the director
            DataGridViewCellStyle sched = new DataGridViewCellStyle();
            sched.BackColor = Color.Gold;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (i > 0) {
                        // Columns are the associated to the times
                        if (user.days[i-1][j] == " ")
                        {
                            dataGridView1[i, j].Style.BackColor = sched.BackColor;
                        }
                        else
                        {
                            dataGridView1[i,j].Style.BackColor = Color.Gainsboro;
                        }
                            }
                }
            }

            
        }

      
        private void dataGridView1_SelectionChanged(Object sender, EventArgs e)
        // this function is where the magic happens.When a user selects a cell
        // the cell color is updated to the opposite of its current state
        // i.e. if its red (available) it becomes gainsboro (unavailable) 
        {
            DataGridViewCellStyle unsel = new DataGridViewCellStyle();
            DataGridViewCellStyle sel = new DataGridViewCellStyle();
            unsel.BackColor = Color.Gainsboro;
            sel.BackColor = Color.Crimson;

            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                if (Convert.ToString(dataGridView1.SelectedCells[i].Value) == "")
                {
                    if (dataGridView1.SelectedCells[i].Style.BackColor != sel.BackColor)
                    {
                        dataGridView1.SelectedCells[i].Style.BackColor = sel.BackColor;
                        dataGridView1.ClearSelection();
                    }
                    else
                    {
                        dataGridView1.SelectedCells[i].Style.BackColor = unsel.BackColor;
                        dataGridView1.ClearSelection();
                    }
                }
            }
        }
        /*private void button1_Click(object sender, EventArgs e)
        // This function is called when the user clicks the "submit" button
        {
            user.PopulateSched(dataGridView1);
            MessageBox.Show("Schedule Successfully Updated!");
            var frm = new ScheduleView();
            schedule2.ScheduleView.CurrentSched.UpdateCurrentSchedule(user.days);
            Program.db.setMasterAvailibility(user);
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }
*/
        private void scheduleConsultants()
        // I still dont know wtf this is tbh 
        {
            int numShifts;
            int consecShifts;

        }

        /*private void button3_Click(object sender, EventArgs e)
        // this function resets the data grid when the user clicks reset
        // This will NOT repopulate with the writing center schedule
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.Gainsboro;
                }
            }
        
        }
        */

        /*private void button2_Click(object sender, EventArgs e)
        // this function resets the data grid when the user clicks clear
        // This will repopulate with the writing center schedule
        {
            DataGridViewCellStyle sched = new DataGridViewCellStyle();
            sched.BackColor = Color.Gold;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Rows.Count; j++)
                {
                    if (i > 0)
                    {
                        // Columns are the associated to the times
                        if (user.days[i-1][j] == " ")
                        {
                            dataGridView1[i, j].Style.BackColor = sched.BackColor;
                        }
                        else
                        {
                            dataGridView1[i, j].Style.BackColor = Color.Gainsboro;
                        }
                    }
                }
            }
        }
        */

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void class13_Click(object sender, EventArgs e)
        {
            string msg = "Do you want to run the scheduler?";
            string title = "Run Scheduler";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(msg, title, buttons);
            string[] list_settings = File.ReadAllLines("dir_settings.txt");
            if (result == DialogResult.Yes)
            {
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
                
                user.PopulateSched(dataGridView1);
                var frm2 = new Form2(user);
                frm2.Location = this.Location;
                frm2.StartPosition = FormStartPosition.Manual;
                frm2.FormClosing += delegate { this.Close(); };
                frm2.Show();
                
                var frm = new ScheduleView(user);
                
                schedule2.ScheduleView.CurrentSched.UpdateCurrentSchedule(user.days);
                Program.db.setMasterAvailibility(user);
                Database.UserListSchedule userSchedule = Program.db.createSchedule();
                Program.db.saveSchedule(userSchedule);
                this.Hide();
          
                
                /*this.Hide();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Close(); };
                frm.Show();*/
            }
            else {
                user.PopulateSched(dataGridView1);
                MessageBox.Show("Schedule Successfully Updated!");
                var frm = new ScheduleView(user);
                schedule2.ScheduleView.CurrentSched.UpdateCurrentSchedule(user.days);
                Program.db.setMasterAvailibility(user);
                this.Hide();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Close(); };
                frm.Show();
            }
            
        }

        private void class11_Click(object sender, EventArgs e)
        {
            DataGridViewCellStyle sched = new DataGridViewCellStyle();
            sched.BackColor = Color.Gold;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (i > 0)
                    {
                        // Columns are the associated to the times
                        if (user.days[i - 1][j] == " ")
                        {
                            dataGridView1[i, j].Style.BackColor = sched.BackColor;
                        }
                        else
                        {
                            dataGridView1[i, j].Style.BackColor = Color.Gainsboro;
                        }
                    }
                }
            }
        }

        private void class12_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.Gainsboro;
                }
            }
        }

        private void class14_Click(object sender, EventArgs e)
        {
            var frm = new DirectorLanding(user);
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void class15_Click(object sender, EventArgs e)
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

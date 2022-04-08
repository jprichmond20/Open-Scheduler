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
    public partial class ScheduleView : Form
    // this is our main Schedule View for both Consultants and Directors
    {
        public static CurrentSchedule CurrentSched; // We initialize a currentSchedule object (for the schedule) 
        public User user;
        public Director director;
        public ScheduleView()
        {
            CurrentSched = new CurrentSchedule(Program.db.getMasterAvalibility());
            // We set the current schedule to that in our mast availability file
            InitializeComponent();
        }
        public ScheduleView(User user)
        {
            this.user = user;
            CurrentSched = new CurrentSchedule(Program.db.getMasterAvalibility());
            // We set the current schedule to that in our mast availability file
            InitializeComponent();
        }
        public ScheduleView(Director director)
        {
            this.director = director;
            CurrentSched = new CurrentSchedule(Program.db.getMasterAvalibility());
            // We set the current schedule to that in our mast availability file
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Initializes the date in the schedule
            // Column headers
            dataGridView1.Columns.Add("Time", "Time");
            dataGridView1.Columns.Add("Monday", "Mon");
            dataGridView1.Columns.Add("Tuesday", "Tues");
            dataGridView1.Columns.Add("Wednesday", "Wed");
            dataGridView1.Columns.Add("Thursday", "Thurs");
            dataGridView1.Columns.Add("Friday", "Fri");
            dataGridView1.Columns.Add("Saturday", "Sat");
            dataGridView1.Columns.Add("Sunday", "Sun");
            // Row headers (not technically headers by dataGridView standards though)
            String[] times = new String[] {"8:00am", "8:30am", "9:00am", "9:30am", "10:00am", "10:30am", "11:00am",
             "11:30am", "12:00pm", "12:30pm", "1:00pm", "1:30pm", "2:00pm", "2:30pm", "3:00pm", "3:30pm", "4:00pm",
             "4:30pm", "5:00pm", "5:30pm", "6:00pm", "6:30pm", "7:00pm", "7:30pm", "8:00pm", "8:30pm", "9:00pm", "9:30pm",
             "10:00pm", "10:30pm", "11:00pm"};

            // Try
            Database.UserListSchedule currentUserSchedule = Program.db.getUserSchedule();
            for (int i = 0; i < times.Length; i++)
            {

                dataGridView1.Rows.Add(new object[] {
                    times[i],
                    formatNamesAtTime(currentUserSchedule.monday[i]),
                    formatNamesAtTime(currentUserSchedule.tuesday[i]),
                    formatNamesAtTime(currentUserSchedule.wednesday[i]),
                    formatNamesAtTime(currentUserSchedule.thursday[i]),
                    formatNamesAtTime(currentUserSchedule.friday[i]),
                    formatNamesAtTime(currentUserSchedule.saturday[i]),
                    formatNamesAtTime(currentUserSchedule.sunday[i])
                });
            }
            // Except

            // currently the schedule stays blank, once the alghorithm is impemented this will change
            //for (int i = 0; i < times.Length; i++)
            //{
            //    dataGridView1.Rows.Add(new object[] { times[i], "", "", "", "", "", "", "" });
            //}

            // Set some settings for display
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                int colw = dataGridView1.Columns[i].Width;
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[i].Width = colw;
            }
            dataGridView1.DefaultCellStyle.BackColor = Color.Gainsboro;

            // fits dataGridView to data both in height and width
            int height = 0;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                height += row.Height;
            }
            height += dataGridView1.ColumnHeadersHeight;

            int width = 0;
            foreach(DataGridViewColumn col in dataGridView1.Columns)
            {
                width += col.Width;
            }
            dataGridView1.ClientSize = new Size(width + 2, height + 2);
            
            //Populate the schedule view with the current schedule
            // If the writing center is closed, it is represented by a black square
            DataGridViewCellStyle notOpen = new DataGridViewCellStyle();
            notOpen.BackColor = Color.Crimson;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                //MessageBox.Show("Columns " + dataGridView1.Columns.Count.ToString() + "\nCurrentSched " + CurrentSched.days.Count.ToString() + "\nRows " + dataGridView1.Rows.Count.ToString());
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (i > 0)
                    {
                        // Columns are the associated to the times
                        if (CurrentSched.days[i-1][j] == "NULL")
                        {
                            dataGridView1[i, j].Style.BackColor = notOpen.BackColor;
                        }
                    }
                }
            }
        }

        private string formatNamesAtTime(List<User> scheduled)
        {
            string formattedOutput = "";
            foreach(User consult in scheduled)
            {
                if (consult != null)
                { 
                    formattedOutput += consult.getFirstandLast() + "\n";
                }
            }
            return formattedOutput;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(Object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void class11_Click(object sender, EventArgs e)
        {
            if (director != null)
            {
                this.Hide();
                var frm = new DirectorLanding(director);
                this.Hide();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Close(); };
                frm.Show();
            }
            else
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

        private void class12_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new SignIn();
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void class12_Click_1(object sender, EventArgs e)
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

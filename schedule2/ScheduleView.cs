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
        private int openInd;
        private int closeInd;
        public Database.UserListSchedule currentUserSchedule;
        String[] times = new String[] {"12:00am", "12:30am", "1:00am", "1:30am", "2:00am", "2:30am", "3:00am",
            "3:30am", "4:00am", "4:30am", "5:00am","5:30am","6:00am","6:30am","7:00am", "7:30am", "8:00am", "8:30am", "9:00am", "9:30am",
            "10:00am", "10:30am", "11:00am", "11:30am", "12:00pm", "12:30pm", "1:00pm", "1:30pm", "2:00pm", "2:30pm",
            "3:00pm", "3:30pm", "4:00pm","4:30pm", "5:00pm", "5:30pm", "6:00pm", "6:30pm", "7:00pm", "7:30pm", "8:00pm",
            "8:30pm", "9:00pm", "9:30pm", "10:00pm", "10:30pm", "11:00pm", "11:30pm"};
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
            
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            


            // Initializes the date in the schedule
            // Column headers
            dataGridView1.TopLeftHeaderCell.Value = "Time";
            dataGridView1.Columns.Add("Monday", "Monday");
            dataGridView1.Columns.Add("Tuesday", "Tuesday");
            dataGridView1.Columns.Add("Wednesday", "Wednesday");
            dataGridView1.Columns.Add("Thursday", "Thursday");
            dataGridView1.Columns.Add("Friday", "Friday");
            dataGridView1.Columns.Add("Saturday", "Saturday");
            dataGridView1.Columns.Add("Sunday", "Sunday");
            // Row headers (not technically headers by dataGridView standards though)

            // Try
            currentUserSchedule = Program.db.getUserSchedule();
            String[] maxOpenAndClose = getOpenAndCloseSchedule();
            for (int i = 0; i < maxOpenAndClose.Length; i++)
            {
                dataGridView1.Rows.Add(new object[] {
                    formatNamesAtTime(currentUserSchedule.monday[i+openInd]),
                    formatNamesAtTime(currentUserSchedule.tuesday[i+openInd]),
                    formatNamesAtTime(currentUserSchedule.wednesday[i+openInd]),
                    formatNamesAtTime(currentUserSchedule.thursday[i+openInd]),
                    formatNamesAtTime(currentUserSchedule.friday[i+openInd]),
                    formatNamesAtTime(currentUserSchedule.saturday[i+openInd]),
                    formatNamesAtTime(currentUserSchedule.sunday[i+openInd])
                });
                dataGridView1.Rows[i].HeaderCell.Value = maxOpenAndClose[i];
                
            }
            // Except

            // currently the schedule stays blank, once the alghorithm is impemented this will change
            //for (int i = 0; i < times.Length; i++)
            //{
            //    dataGridView1.Rows.Add(new object[] { times[i], "", "", "", "", "", "", "" });
            //}

            // Set some settings for display
            dataGridView1.RowHeadersWidth = 100; 
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

            //int width = 0;
            //foreach(DataGridViewColumn col in dataGridView1.Columns)
            //{
            //    width += col.Width;
            //}
            dataGridView1.Height = this.Height-100;
            //dataGridView1.Width = this.Width;
            //dataGridView1.Height = height;

            //dataGridView1.Width = dataGridView1.Columns.Cast<DataGridViewColumn>().Sum(x => x.Width) + (dataGridView1.RowHeadersVisible ? dataGridView1.RowHeadersWidth : 0) + 50;
            
            
            //Populate the schedule view with the current schedule
            // If the writing center is closed, it is represented by a black square
            DataGridViewCellStyle notOpen = new DataGridViewCellStyle();
            notOpen.BackColor = Color.Crimson;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                //MessageBox.Show("Columns " + dataGridView1.Columns.Count.ToString() + "\nCurrentSched " + CurrentSched.days.Count.ToString() + "\nRows " + dataGridView1.Rows.Count.ToString());
                for (int j = 0; j < times.Count(); j++)
                {
                        if (j >= openInd && j <= closeInd)
                        {
                            // Columns are the associated to the times
                            if (CurrentSched.days[i][j] == "NULL")
                            {
                                dataGridView1[i, j-openInd].Style.BackColor = notOpen.BackColor;
                            }
                        }
                }
            }

            if (director != null)
            {
               dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Gainsboro;
            }
            else
            {
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            }

            dataGridView1.FirstDisplayedCell.Selected = false;
        }

        public string[] getOpenAndCloseSchedule()
        {
            List<String[]> openAndCloseHours = new List<String[]>();
            Boolean isOpen = false;
            Boolean isClosed = false;
            String openTime = null;
            String closeTime = null;
            foreach (String[] day in CurrentSched.days)
            {
                openAndCloseHours.Add(getOpenAndCloseDay(day));
            }
            openTime = openAndCloseHours.First()[0];
            closeTime = openAndCloseHours.First()[1];


            
            foreach(String[] day in openAndCloseHours)
            {
                String[] biggestOpen = openTime.Split(':');
                String[] biggestClose = closeTime.Split(':');
                String[] currOpen = day[0].Split(':');
                String[] currClose = day[1].Split(':');
                if((biggestOpen[1].Substring(2) == "am" && currOpen[1].Substring(2) == "am") || (biggestOpen[1].Substring(2) == "pm" && currOpen[1].Substring(2) == "pm"))
                {
                    if (Int32.Parse(biggestOpen[0]) < Int32.Parse(currOpen[0])){
                        if (Int32.Parse(biggestOpen[1].Substring(0, 2)) < Int32.Parse(currOpen[1].Substring(0, 2))){
                            openTime = day[0];
                        }
                    }
                }
                if(biggestOpen[1].Substring(2) == "pm" && currOpen[1].Substring(2) == "am" && (currOpen[0] != "0" && currOpen[1] != "00am"))
                {
                    openTime = day[0];
                }

                if ((biggestClose[1].Substring(2) == "am" && currClose[1].Substring(2) == "am") || (biggestClose[1].Substring(2) == "pm" && currClose[1].Substring(2) == "pm"))
                {
                    if (Int32.Parse(biggestClose[0]) < Int32.Parse(currOpen[0]))
                    {
                        if (Int32.Parse(biggestClose[1].Substring(0, 2)) < Int32.Parse(currClose[1].Substring(0, 2)))
                        {
                            closeTime = day[1];
                        }
                    }
                }
                if (biggestClose[1].Substring(2) == "pm" && currClose[1].Substring(2) == "am" && (currClose[0] != "0" && currClose[1] != "00am"))
                {
                    closeTime = day[1];
                }
                if (biggestClose[1].Substring(2) == "am" && currClose[1].Substring(2) == "pm")
                {
                    if(biggestClose[0] == "0" && biggestClose[1] == "00am")
                    {
                        closeTime = day[1];
                    }
                }
            }


            int openIndex = times.ToList().IndexOf(openTime);
            int closeIndex = times.ToList().IndexOf(closeTime);
            openInd = openIndex;
            closeInd = closeIndex;
            isOpen = false;
            isClosed = false;


            List<String> newHours = new List<string>();
            for (int j = 0; j < times.Length; j++)
            {
                if (!isClosed) {
                    if (!isOpen)
                    {
                        if (j == openIndex)
                        {
                            isOpen = true;
                        }
                    }
                    if (isOpen)
                    {
                        newHours.Add(times[j]);
                        if (j == closeIndex)
                        {
                            isClosed = true;
                        }
                    }
                }
            }
            String[] maxOpenAndClose = new string[newHours.Count];
            for(int k = 0; k < maxOpenAndClose.Length; k++)
            {
                maxOpenAndClose[k] = newHours.ElementAt(k);
            }
            
            return maxOpenAndClose;
        }

        private String[] getOpenAndCloseDay(String[] day)
        {
            String[] openAndCloseDay = new string[] { "", "" };
            Boolean hasOpen = false;
            Boolean hasClosed = false;
            

            for(int i = 0; i < day.Length; i++)
            {
                if(day[i] != "NULL" && !hasOpen)
                {
                    openAndCloseDay[0] = times[i];
                    hasOpen = true;
                }
                    if (day[day.Length - (i+1)] != "NULL" && !hasClosed)
                    {
                        openAndCloseDay[1] = times[day.Length - (i+1)];
                        hasClosed = true;
                    }
                
                
            }

            if (!hasClosed)
            {
                openAndCloseDay[1] = "0:00am";
            }
            if (!hasOpen)
            {
                openAndCloseDay[0] = "0:00am";
            }

            return openAndCloseDay;
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
            if (director != null)
            {
                int colInd = e.ColumnIndex;
                int rowInd = e.RowIndex;
                List<User> consultants = new List<User>();
                List<List<User>> day = new List<List<User>>();
                switch (colInd)
                {
                    case 0:
                        day = currentUserSchedule.monday;
                        break;
                    case 1:
                        day = currentUserSchedule.tuesday;
                        break;
                    case 2:
                        day = currentUserSchedule.wednesday;
                        break;
                    case 3:
                        day = currentUserSchedule.thursday;
                        break;
                    case 4:
                        day = currentUserSchedule.friday;
                        break;
                    case 5:
                        day = currentUserSchedule.saturday;
                        break;
                    case 6:
                        day = currentUserSchedule.sunday;
                        break;
                }
                consultants = day[rowInd];


                //EditScheduleView editCell = new EditScheduleView(dataGridView1.CurrentCell, consultants);
                //editCell.Show();
                //editCell.Location = this.Location;



                var frm = new editDataGridCell(dataGridView1.CurrentCell, consultants);
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.Show();
            }
        }

        private void dataGridView1_SelectionChanged(Object sender, EventArgs e)
        {
            //dataGridView1.ClearSelection();
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

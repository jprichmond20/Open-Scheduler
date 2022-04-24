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
    public partial class RegScheduler : Form
    // this for allows a consultant to se their availability to work at the writing center
    {
        public Consultant user;
        String[] times = new String[] {"12:00am", "12:30am", "1:00am", "1:30am", "2:00am", "2:30am", "3:00am",
            "3:30am", "4:00am", "4:30am", "5:00am","5:30am","6:00am","6:30am","7:00am", "7:30am", "8:00am", "8:30am", "9:00am", "9:30am",
            "10:00am", "10:30am", "11:00am", "11:30am", "12:00pm", "12:30pm", "1:00pm", "1:30pm", "2:00pm", "2:30pm",
            "3:00pm", "3:30pm", "4:00pm","4:30pm", "5:00pm", "5:30pm", "6:00pm", "6:30pm", "7:00pm", "7:30pm", "8:00pm",
            "8:30pm", "9:00pm", "9:30pm", "10:00pm", "10:30pm", "11:00pm", "11:30pm"};
        public int openInd;
        public int closeInd;
        public CurrentSchedule masterSchedule;

        public RegScheduler(Consultant user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void RegScheduler_Load(object sender, EventArgs e)
        {
            masterSchedule = new CurrentSchedule(Program.db.getMasterAvalibility());
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
            String[] maxOpenAndClose = getOpenAndCloseSchedule();

            for(int i = 0; i < maxOpenAndClose.Length; i++)
            {
                dataGridView1.Rows.Add(new object[] {"", "", "", "", "", "", "" });
                dataGridView1.Rows[i].HeaderCell.Value = maxOpenAndClose[i];
            }


            
            
            DataGridViewCellStyle sched = new DataGridViewCellStyle();
            sched.BackColor = Color.Black;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (j >= openInd && j <= closeInd)
                    {
                        // Columns are the associated to the times
                        if (masterSchedule.days[i][j] == "NULL")
                        {
                            dataGridView1[i, j-openInd].Style.BackColor = sched.BackColor;
                        }
                    }
                }
            }


            // Set the columns to autosize and set the default backcolor 
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.DefaultCellStyle.BackColor = Color.Gainsboro;

            //Once we have the direcotr schedule saving correctly it will be brought into here
            // So the users know the hours of the writing center


            //dataGridView1.FirstDisplayedCell.Selected = false;

        }

        public string[] getOpenAndCloseSchedule()
        {
            List<String[]> openAndCloseHours = new List<String[]>();
            Boolean isOpen = false;
            Boolean isClosed = false;
            String openTime = null;
            String closeTime = null;
            foreach (String[] day in masterSchedule.days)
            {
                openAndCloseHours.Add(getOpenAndCloseDay(day));
            }
            openTime = openAndCloseHours.First()[0];
            closeTime = openAndCloseHours.First()[1];



            foreach (String[] day in openAndCloseHours)
            {
                String[] biggestOpen = openTime.Split(':');
                String[] biggestClose = closeTime.Split(':');
                String[] currOpen = day[0].Split(':');
                String[] currClose = day[1].Split(':');
                if ((biggestOpen[1].Substring(2) == "am" && currOpen[1].Substring(2) == "am") || (biggestOpen[1].Substring(2) == "pm" && currOpen[1].Substring(2) == "pm"))
                {
                    if (Int32.Parse(biggestOpen[0]) < Int32.Parse(currOpen[0]))
                    {
                        if (Int32.Parse(biggestOpen[1].Substring(0, 2)) < Int32.Parse(currOpen[1].Substring(0, 2)))
                        {
                            openTime = day[0];
                        }
                        if (biggestOpen[0] == "0" && biggestOpen[1] == "00am")
                        {
                            openTime = day[0];
                        }
                    }
                }
                if (biggestOpen[1].Substring(2) == "pm" && currOpen[1].Substring(2) == "am" && (currOpen[0] != "0" && currOpen[1] != "00am"))
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
                    if (biggestClose[0] == "0" && biggestClose[1] == "00am")
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
                if (!isClosed)
                {
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
            for (int k = 0; k < maxOpenAndClose.Length; k++)
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


            for (int i = 0; i < day.Length; i++)
            {
                if (day[i] != "NULL" && !hasOpen)
                {
                    openAndCloseDay[0] = times[i];
                    hasOpen = true;
                }
                if (day[day.Length - (i + 1)] != "NULL" && !hasClosed)
                {
                    openAndCloseDay[1] = times[day.Length - (i + 1)];
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
            foreach (User consult in scheduled)
            {
                if (consult != null)
                {
                    formattedOutput += consult.getFirstandLast() + "\n";
                }
            }
            return formattedOutput;
        }

        private void dataGridView1_SelectionChanged(Object sender, EventArgs e)
        // this function is where the magic happens. When a user selects a cell
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
        private void button1_Click(object sender, EventArgs e)
        // This function is called when the user clicks the "submit" button
        {
            user.PopulateSched(dataGridView1);
            MessageBox.Show("Registration Successful");
            user.RegisterUser();
            var frm = new ScheduleView();
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }
        private void scheduleConsultants()
        // not sure wtf this is tbh
        {
            int numShifts;
            int consecShifts;

        }

       

        private void button2_Click(object sender, EventArgs e)
        // this function resets the data grid when the user clicks clear
        // This will repopulate with the writing center schedule when we have it
        {
            

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.Gainsboro;
                }
            }
        
        }

        private void class12_Click(object sender, EventArgs e)
        // This function is called when the user clicks the "submit" button
        {
            user.PopulateSched(dataGridView1);
            MessageBox.Show("Registration Successful");
            user.RegisterUser();
            var frm = new ScheduleView();
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void class11_Click(object sender, EventArgs e)
        // this function resets the data grid when the user clicks clear
        // This will repopulate with the writing center schedule when we have it
        {
            //clear

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.Gainsboro;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

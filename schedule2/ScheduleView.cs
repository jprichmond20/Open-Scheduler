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
    {
        public List<CurrentSchedule> CurrentSchedule { get; set; }

        public ScheduleView()
        {
            CurrentSchedule = GetCurrentSchedule();
            InitializeComponent();
        }

        private List<CurrentSchedule> GetCurrentSchedule()
        {
            var list = new List<CurrentSchedule>();
            list.Add(new CurrentSchedule()
            {
                Time = "8:00am",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "8:30am",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "9:00am",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "9:30am",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "10:00am",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "10:30am",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "11:00am",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "11:30am",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "12:00pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "12:30pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "1:00pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "1:30pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "2:00pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "2:30pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "3:00pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "3:30pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "4:00pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "4:30pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "5:00pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "5:30pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "6:00pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "6:30pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "7:00pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "7:30pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "8:00pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "8:30pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "9:00pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "9:30pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "10:00pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "10:30pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });
            list.Add(new CurrentSchedule()
            {
                Time = "11:00pm",
                Monday = "NULL",
                Tuesday = "NULL",
                Wednesday = "NULL",
                Thursday = "NULL",
                Friday = "NULL",
                Saturday = "NULL",
                Sunday = "NULL"
            });

            return list;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var CurrentSchedule = this.CurrentSchedule;

            dataGridView1.DataSource = CurrentSchedule;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

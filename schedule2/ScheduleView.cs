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
        public CurrentSchedule CurrentSched;
        public ScheduleView(List<string[]> days)
        {
            CurrentSched = new CurrentSchedule(days);
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            dataGridView1.Columns.Add("Time", "Time");
            dataGridView1.Columns.Add("Monday", "Mon");
            dataGridView1.Columns.Add("Tuesday", "Tues");
            dataGridView1.Columns.Add("Wednesday", "Wed");
            dataGridView1.Columns.Add("Thursday", "Thurs");
            dataGridView1.Columns.Add("Friday", "Fri");
            dataGridView1.Columns.Add("Saturday", "Sat");
            dataGridView1.Columns.Add("Sunday", "Sun");
            String[] times = new String[] {"8:00am", "8:30am", "9:00am", "9:30am", "10:00am", "10:30am", "11:00am",
             "11:30am", "12:00pm", "12:30pm", "1:00pm", "1:30pm", "2:00pm", "2:30pm", "3:00pm", "3:30pm", "4:00pm",
             "4:30pm", "5:00pm", "5:30pm", "6:00pm", "6:30pm", "7:00pm", "7:30pm", "8:00pm", "8:30pm", "9:00pm", "9:30pm",
             "10:00pm", "10:30pm", "11:00pm"};
            for (int i = 0; i < times.Length; i++)
            {
                dataGridView1.Rows.Add(new object[] { times[i], "", "", "", "", "", "", "" });
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.DefaultCellStyle.BackColor = Color.Gainsboro;

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


            DataGridViewCellStyle notOpen = new DataGridViewCellStyle();
            notOpen.BackColor = Color.Black;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    if (i > 0)
                    {
                        // Columns are the associated to the times
                        if (CurrentSched.days[i][j] == "NULL")
                        {
                            dataGridView1[j, i].Style.BackColor = notOpen.BackColor;
                        }
                    }
                }
            }
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

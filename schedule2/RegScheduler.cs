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
    {
        public User user;
        public RegScheduler(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void RegScheduler_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
            dataGridView1.AutoGenerateColumns = false;
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
            for(int i = 0; i < times.Length; i++)
            {
                dataGridView1.Rows.Add(new object[] { times[i], "", "", "", "", "", "", "" });
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.DefaultCellStyle.BackColor = Color.Gainsboro;
            
     
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(Object sender, EventArgs e)
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
        {
            user.PopulateSched(dataGridView1);
            MessageBox.Show("Registration Successful");
            user.RegisterUser();
            var frm = new Form2();
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }
    }
}

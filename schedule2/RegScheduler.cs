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

        public RegScheduler()
        {
            InitializeComponent();
        }

        private void RegScheduler_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Time", "Time");
            dataGridView1.Columns.Add("Monday", "Mon");
            dataGridView1.Columns.Add("Tuesday", "Tues");
            dataGridView1.Columns.Add("Wednesday", "Wed");
            dataGridView1.Columns.Add("Thursday", "Thurs");
            dataGridView1.Columns.Add("Friday", "Fri");
            dataGridView1.Columns.Add("Saturday", "Sat");
            dataGridView1.Columns.Add("Sunday", "Sun");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
    public partial class editDataGridCell : Form
    {
        public DataGridViewCell cell;
        List<User> consultantsInCell;
        List<Consultant> short_list = new List<Consultant>();
        public editDataGridCell(DataGridViewCell currentCell, List<User> consultants)
        {
            consultantsInCell = consultants;
            cell = currentCell;
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void editDataGridCell_Load(object sender, EventArgs e)
        {
            String[] consultants = cell.Value.ToString().Split('\n');
            List<Consultant> consultantInfo = new List<Consultant>();
            foreach (String consultant in consultants)
            {
                listBox1.Items.Add(consultant);
                Object[] consult = Program.db.lookupAccounts[consultant];
                consultantsInCell.Add(Program.db.getUserById(consult[3].ToString()).user);
            }
        }

        private void class11_Click(object sender, EventArgs e)
        {

        }

        private void class12_Click(object sender, EventArgs e)
        {

        }
    }
}

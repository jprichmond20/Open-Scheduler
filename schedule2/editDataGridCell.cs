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
        public List<User> consultantsInCell;
        List<Consultant> short_list = new List<Consultant>();
        public editDataGridCell(DataGridViewCell currentCell)
        {
            consultantsInCell = new List<User>();
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
                if (consultant != "")
                {
                    listBox1.Items.Add(consultant);
                    Object[] consult = Program.db.lookupAccounts[consultant];
                    consultantsInCell.Add(Program.db.getUserById(consult[3].ToString()).user);

                }
            }
            String[] shortList = Program.db.get_short_list();
            foreach (String consultant in shortList)
            {
                listBox2.Items.Add(consultant);
            }
        }

        private void class11_Click(object sender, EventArgs e)
        {
            String message = "Are you sure you want to add \n" + listBox2.SelectedItem.ToString() + " to the consultants scheduled for this shift?";
            var confirmResult = MessageBox.Show(message, "Add Consultant", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(confirmResult == DialogResult.Yes)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                consultantsInCell.Add(Program.db.lookupByFirstAndLast(listBox2.SelectedItem.ToString()));
                listBox2.Items.Remove(listBox2.SelectedItem);
            }

            
        }

        private void listBox2_SelectionIndexChanged(object sender, EventArgs e)
        {

        }

        private void class12_Click(object sender, EventArgs e)
        {
            String removedConsultant = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(removedConsultant);
            List < User > tempConsultantsInCell = new List<User>();
            foreach (User consultant in consultantsInCell)
            {
                tempConsultantsInCell.Add(consultant);
                if (consultant.getFirstandLast().Equals(removedConsultant))
                {
                    tempConsultantsInCell.Remove(consultant);
                }
            }
            consultantsInCell = tempConsultantsInCell;
        }

        private void class14_Click(object sender, EventArgs e)
        {
            cell.Value = formatNamesAtTime(consultantsInCell);
            class14.DialogResult = DialogResult.OK;
            this.Close();
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

        private void class13_Click(object sender, EventArgs e)
        {
            String message = "Are you sure you want to replace " + listBox1.SelectedItem.ToString() + "\n  with " + listBox2.SelectedItem.ToString() +" for this shift?";
            var confirmResult = MessageBox.Show(message, "Replace Consultant", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                int toBeReplacedInd = listBox1.Items.IndexOf(listBox1.SelectedItem);
                consultantsInCell.Remove(Program.db.lookupByFirstAndLast(listBox1.SelectedItem.ToString()));
                listBox1.Items.Insert(toBeReplacedInd, listBox2.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
                consultantsInCell.Add(Program.db.lookupByFirstAndLast(listBox2.SelectedItem.ToString()));
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }
    }
}

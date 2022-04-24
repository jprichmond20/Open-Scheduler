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
    public partial class EditScheduleView : UserControl
    {
        public DataGridViewCell cell;
        public List<User> consultantList;
        public EditScheduleView(DataGridViewCell currentCell, List<User> consultants)
        {
            cell = currentCell;
            consultantList = consultants;
            InitializeComponent();
            //MessageBox.Show(currentCell.Value.ToString());

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EditScheduleView_Load(object sender, EventArgs e)
        {
            String[] consultants = cell.Value.ToString().Split(' ');
            List<Consultant> consultantInfo = new List<Consultant>(); 
            foreach(String consultant in consultants)
            {
                listBox1.Items.Add(consultant);
            }
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selectedConsultant = null;
            foreach(User consult in consultantList)
            {
                if (consult.getFirstandLast().Equals(listBox1.SelectedItem))
                {
                    selectedConsultant = consult;
                }
            }
            label1.Text = selectedConsultant.ToString();
        }
    }
}

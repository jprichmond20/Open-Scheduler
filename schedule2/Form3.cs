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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Submit button


            string username = textBox13.Text;
            string password = textBox11.Text;
            string major = textBox10.Text;
            string yearsWorked = textBox9.Text;
            string hoursPer = textBox3.Text;
            
            if (username == "") {
                label3.Text = "Please fill in all fields.";
            }
            else if (password == "")
            {
                label3.Text = "Please fill in all fields.";
            }
            else if (major == "")
            {
                label3.Text = "Please fill in all fields.";
            }
            else if (yearsWorked == "")
            {
                label3.Text = "Please fill in all fields.";
            }
            else if (hoursPer == "")
            {
                label3.Text = "Please fill in all fields.";
            }
            string[] userInfo = { major, yearsWorked, hoursPer };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Back button
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

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
        private Database db;
        public Form3()
        {
            InitializeComponent();
            db = new Database();
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

            string fName = textBox5.Text;
            string lName = textBox2.Text;
            string username = textBox13.Text;
            string password = textBox11.Text;
            string major = comboBox1.Text;
            string majMin2 = comboBox2.Text;
            string majMin3 = comboBox3.Text;
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
            string[] userInfo = { fName, lName, username, password, major, majMin2, majMin3, yearsWorked, hoursPer };
            db.RegisterUser(username, password, userInfo);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Back button
            this.Hide();
            var frm = new Form1();
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class SignIn : Form
    {
        private Database db;
        public SignIn()
        {
            //Databse will initialize a JSON file soon that contains user info
            InitializeComponent();
            db = new Database();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void class11_Click(object sender, EventArgs e)
        {
            //Sign-in button
            //Checks against username and password on file
            if (db.AuthenticateUser(newTextBox2.Text, newTextBox1.Text))
            {
                label3.Text = "";
                var frm = new ScheduleView();
                this.Hide();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Close(); };
                frm.Show();
            }
            else
            {
                //Catch-all error
                label3.Text = "Login has failed! Try another password?";
            }
        }

        private void class12_Click(object sender, EventArgs e)
        {
            //Open form to register new user
            label3.Text = "";
            this.Hide();
            var frm = new RegForm();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }
    }
}

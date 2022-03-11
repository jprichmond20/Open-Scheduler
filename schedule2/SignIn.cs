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
        //public Database db;
        public SignIn()
        {
            //Databse will initialize a JSON file soon that contains user info
            InitializeComponent();
            //db = new Database();
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
            //Database.SignInMessage message = Program.db.AuthenticateUser(newTextBox1.Text, newTextBox2.Text);
            //MessageBox.Show(message.error_messages[0]);

            if (Program.db.AuthenticateUser(newTextBox1.Texts, newTextBox2.Texts).success)
            {
                User user = Program.db.AuthenticateUser(newTextBox1.Texts, newTextBox2.Texts).user;
                var frm = new ScheduleView();
                label3.Text = "";
                if (user.IsDirector())
                {
                    var frm1 = new DirectorLanding(user);
                    this.Hide();
                    frm1.Location = this.Location;
                    frm1.StartPosition = FormStartPosition.Manual;
                    frm1.FormClosing += delegate { this.Close(); };
                    frm1.Show();
                }
                else
                {
                    var frm2 = new ScheduleView();
                    this.Hide();
                    frm2.Location = this.Location;
                    frm2.StartPosition = FormStartPosition.Manual;
                    frm2.FormClosing += delegate { this.Close(); };
                    frm2.Show();
                }
                
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

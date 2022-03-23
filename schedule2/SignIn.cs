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
            this.AcceptButton = class11;
            //db = new Database();
        }

        private void class11_Click(object sender, EventArgs e)
        {
            //Sign-in button
            //Checks against username and password on file
            // POTENTIAL FIX??
            //Database.SignInMessage signIn = Program.db.AuthenticateUser(newTextBox1.Texts, newTextBox2.Texts);
            //if (SignIn.success)
            //{
            //    User user = SignIn.user;
            //}
            if (Program.db.AuthenticateUser(newTextBox2.Texts, newTextBox1.Texts).success)
            {
                // Creates our user if the sign in is successful 
                User user = Program.db.AuthenticateUser(newTextBox2.Texts, newTextBox1.Texts).user;
                
                label3.Text = ""; // Resets the output message 

                if (user.IsDirector()) // Checks to see if the user is a director,
                // if they are, they are taken to the director landing page 
                {
                    var frm1 = new DirectorLanding(new Director(user));
                    this.Hide();
                    frm1.Location = this.Location;
                    frm1.StartPosition = FormStartPosition.Manual;
                    frm1.FormClosing += delegate { this.Close(); };
                    frm1.Show();
                }
                else
                // If they arent a director, take them to the current schedule
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
                //Catch-all error for failed login
                label3.Text = "Login has failed! Try another password?";
            }
        }

        private void class12_Click(object sender, EventArgs e)
        {
            //Opens form to register new user
            label3.Text = "";
            this.Hide();
            var frm = new RegForm();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }
    }
}

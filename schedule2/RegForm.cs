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
    public partial class RegForm : Form
    // this is the Consultant registration form 
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void class12_Click(object sender, EventArgs e)
        //This function is called when the user clicks the Submit button
        // it Stores all user info and creates a new user 
        {
            // Gets first, last, username, password, majors, minors, years worked and hours per week
            string fName = newTextBox6.Texts;
            string lName = newTextBox5.Texts;
            string username = newTextBox4.Texts;
            string password = newTextBox3.Texts;
            string major = checkedListBox1.CheckedItems.Cast<string>().Aggregate(string.Empty, (current, item) => current + item.ToString() + ",");
            string minor = checkedListBox2.CheckedItems.Cast<string>().Aggregate(string.Empty, (current, item) => current + item.ToString() + ",");
            string yearsWorked = newTextBox1.Texts;
            string hoursPer = newTextBox2.Texts;


            // Input validation to make sure user inputs all information
            // ALTERNATIVE:
            //if(username == "" || password == "" || major == "" || yearsWorked == "" || hoursPer == "")
            //{
            //    label3.Text = "Please fill in all fields.";
            //}
            if (username == "")
            {
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
            //
            // Gathers user data, generates a user ID then creates a new consulatant
            // Then it launches the scheudler so they can input their availability
            string userID = Guid.NewGuid().ToString();
            string[] userInfo = { fName, lName, username, password, major, minor, yearsWorked, hoursPer, userID };
            Consultant newUser = new Consultant(userInfo);
            this.Hide();
            var frm = new RegScheduler(newUser);
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }

        private void class11_Click(object sender, EventArgs e)
        // When clicked this button takes the user back to the sign in form 
        {
            this.Hide();
            var frm = new SignIn();
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }
    }
}

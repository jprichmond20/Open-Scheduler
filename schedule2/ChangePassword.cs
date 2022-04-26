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
    public partial class ChangePassword : Form
    {
        User curr_user;
        public ChangePassword(User user)
        {
            curr_user = user;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void class14_Click(object sender, EventArgs e)
        {
            string new_password = this.NewPassword.Texts;
            string new_password_again = this.NewPasswordAgain.Texts;
            if(Program.db.changePassword(curr_user, new_password, new_password_again).success)
            {
                this.ErrorMessage.Text = "Password Successfully Changed!";
            }
            else
            {
                this.ErrorMessage.Text = "Passwords must match!";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            var frm = new SignIn();
            this.Hide();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
        }
    }
}

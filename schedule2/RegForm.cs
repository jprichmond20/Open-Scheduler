﻿using System;
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
    {
        private Database db;
        public RegForm()
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
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

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

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void class12_Click(object sender, EventArgs e)
        {
            //Submit button

            string fName = textBox5.Text;
            string lName = textBox2.Text;
            string username = textBox13.Text;
            string password = textBox11.Text;
            string major = checkedListBox1.CheckedItems.Cast<string>().Aggregate(string.Empty, (current, item) => current + item.ToString() + ",");
            string minor = checkedListBox2.CheckedItems.Cast<string>().Aggregate(string.Empty, (current, item) => current + item.ToString() + ",");


            string yearsWorked = textBox9.Text;
            string hoursPer = textBox3.Text;



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
        {
            //Back button
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

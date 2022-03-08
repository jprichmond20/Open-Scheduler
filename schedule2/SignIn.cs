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
    public partial class SignIn : Form
    {
        private Database db;
        public SignIn()
        {
            InitializeComponent();
            db = new Database();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Sign-In Button
        private void button1_Click(object sender, EventArgs e)
        {
            //Need to distinguish between types of users to determine landing page
            //Talk with Kacik about Form4
            if(db.AuthenticateUser(textBox1.Text, textBox2.Text))
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
                label3.Text = "Login has failed! Try another password?";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            this.Hide();
            var frm = new RegForm();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Close(); };
            frm.Show();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

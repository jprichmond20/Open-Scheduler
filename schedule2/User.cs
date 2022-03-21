﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schedule2
{
    public class User
    // This is the User parent class which has the information and basic methods
    // that both the consultant and the director use 
    {
        //
        //All the users demographic info
        //
        public List<string[]> days;
        public string[] major;
        public string maj;
        public string[] minor;
        public string min;
        public string yearsWorked;
        public string hoursPer;
        public string first;
        public string last;
        public string username;
        public string password;
        public string userID;
        public bool director;
        public string[] demographicInfo;
        public int numberOfShifts = 0;

        public void PopulateSched(DataGridView schedule)
        // This function will populate the Users internal schedule with
        // whatever schedule is passed to it
        // This function is for when the director changes the schedule or
        // a consultant changes or sets their availability
        {
            //
            //User availability stored
            //
            DataGridViewCellStyle sel = new DataGridViewCellStyle();
            sel.BackColor = Color.Crimson;
            for (int i = 0; i < schedule.Rows.Count; i++)
            {
                for(int j = 1; j < schedule.Columns.Count; j++)
                {
                    if(schedule.Rows[i].Cells[j].Style.BackColor == sel.BackColor)
                    {
                        days[j - 1][i] = " ";
                    }
                    else
                    {
                        days[j - 1][i] = "NULL";
                    }
                }
            }
            for (int k = 0; k < 6; k++)
            {
                MessageBox.Show(string.Join(",", days[k]));
            }

        }
        
        public void RegisterUser()
        //Function to register the user
        //It stores their information (username, password, demographic info)
        //in the database in a json file
        {
            //Database db = new Database();
            Program.db.RegisterUser(username, password, this);
            // could be
            // Program.db.RegisterUser(this)?
        }
        
        public Boolean IsDirector()
        // Function returns a bool value as to whether user is a director or not
        // True = director
        {
            return director;
        }

    }
    public class Director : User
    // this is the director subclass that has the user as a parent class

    {
        public Director()
        // Director constructor, calls the initialize function below
        {
            Initialize();
        }
        public Director(User user)
        {
            this.director = user.director;
            this.first = user.first;
            this.last = user.last;
            this.username = user.username;
            this.password = user.password;
            this.maj = user.maj;
            this.min = user.min;
            this.major = null;
            this.minor = null;
            this.yearsWorked = user.yearsWorked;
            this.hoursPer = user.hoursPer;
            this.userID = user.userID;
            this.demographicInfo = user.demographicInfo;
            try
            {
                schedule2.Database.Schedule masterSched = Program.db.getMasterAvalibility();
                days = new List<string[]> { masterSched.monday, masterSched.tuesday, masterSched.wednesday, masterSched.thursday, masterSched.friday, masterSched.saturday, masterSched.sunday };
            }
            catch (Exception e)
            {
                string[] day = new string[31];
                for (int i = 0; i < 31; i++)
                {
                    day[i] = "";
                }
                days = new List<string[]> { day, day, day, day, day, day, day };
            }
        }
        private void Initialize()
        // this function initializes our director when they are first created
        // they are assigned a user ID, given director permissions and then
        // they get the master availability schedule (if there is one otherwise they get a blank schedule)
        // There may be more added later
        {
            this.userID = Guid.NewGuid().ToString();
            director = true;

            try
            {
                schedule2.Database.Schedule masterSched = Program.db.getMasterAvalibility();
                days = new List<string[]> { masterSched.monday, masterSched.tuesday, masterSched.wednesday, masterSched.thursday, masterSched.friday, masterSched.saturday, masterSched.sunday };
            }
            catch(Exception e)
            {
                string[] day = new string[31];
                for (int i = 0; i < 31; i++)
                {
                    day[i] = "";
                }
                days = new List<string[]> { day, day, day, day, day, day, day};
            }
            }
        public void update2CurrentSched(List<string[]> currSched)
        // this director method takes a current schedule and updates the
        // directors internal schedule to match (this is for schedule changes) 
        {
            for (int i = 0; i < currSched.Count(); i++)
            {
                days[i] = currSched[i];
            }
        }
    }
    public class Consultant : User
    // This consultant class is a subclass of user used to represent our consultants
    {
        
        public Consultant(string[] demographicInfo)
        // Consultant calls the private initialize function
        {
            Initialize(demographicInfo);
        }
        private void Initialize(string[] demographicInfo)
        // Here is the initialization of the consulant. They do not get directors permissions
        // Then all of their information is assigned to their various fields and a blank schedule is generated
        // the schedule will be filled with their current availability once theu put it in
        {
            director = false;
            first = demographicInfo[0];
            last = demographicInfo[1];
            username = demographicInfo[2];
            password = demographicInfo[3];
            maj = demographicInfo[4];
            min = demographicInfo[5];
            major = maj.Split(',');
            minor = min.Split(',');
            yearsWorked = demographicInfo[6];
            hoursPer = demographicInfo[7];
            userID = demographicInfo[8];
            this.demographicInfo = demographicInfo;

            string[] day = new string[31];
            for (int i = 0; i < 31; i++)
            {
                day[i] = "";
            }
            days = new List<string[]> { day, day, day, day, day, day, day };
        }
        
}
}

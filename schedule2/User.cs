using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schedule2
{
    public class User
    {
        protected string[] monday = new string[31];
        protected string[] tuesday = new string[31];
        protected string[] wednesday = new string[31];
        protected string[] thursday = new string[31];
        protected string[] friday = new string[31];
        protected string[] saturday = new string[31];
        protected string[] sunday = new string[31];
        public List<string[]> days;
        protected string[] major;
        protected string maj;
        protected string[] minor;
        protected string min;
        protected string yearsWorked;
        protected string hoursPer;
        protected string first;
        protected string last;
        protected string username;
        protected string password;
        protected string userID;
        protected string[] demographicInfo;


        //public User(string[] demographicInfo)
        //{
        //    first = demographicInfo[0];
        //    last = demographicInfo[1];
        //    username = demographicInfo[2];
        //    password = demographicInfo[3];
        //}

        public void PopulateSched(DataGridView schedule)
        {
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
        {
        Database db = new Database();
        db.RegisterUser(username, password, demographicInfo);
        }
        
        //private void Initialize(string[] demographicInfo)
        //{
        //    first = demographicInfo[0];
        //    last = demographicInfo[1];
        //    username = demographicInfo[2];
        //    password = demographicInfo[3];
        //    maj = demographicInfo[4];
        //    min = demographicInfo[5];
        //    major = maj.Split(',');
        //    minor = min.Split(',');
        //    yearsWorked = demographicInfo[6];
        //    hoursPer = demographicInfo[7];
        //    userID = demographicInfo[8];
        //    this.demographicInfo = demographicInfo;

        //    for (int i = 0; i < 31; i++)
        //    {
        //        monday[i] = "";
        //        tuesday[i] = "";
        //        wednesday[i] = "";
        //        thursday[i] = "";
        //        friday[i] = "";
        //        saturday[i] = "";
        //        sunday[i] = "";
        //    }
        //    days = new List<string[]>{ monday, tuesday, wednesday, thursday, friday, saturday, sunday };
        //}

        //public void RegisterUser()
        //{
        //    Database db = new Database();
        //    db.RegisterUser(username, password, demographicInfo);
        //}

    }
    public class Director : User
    {
        public Director(string[] demographicInfo)
        {
            Initialize(demographicInfo);
        }
        private void Initialize(string[] demographicInfo)
        {
            this.demographicInfo = demographicInfo;

            for (int i = 0; i < 31; i++)
            {
                monday[i] = "";
                tuesday[i] = "";
                wednesday[i] = "";
                thursday[i] = "";
                friday[i] = "";
                saturday[i] = "";
                sunday[i] = "";
            }
            days = new List<string[]> { monday, tuesday, wednesday, thursday, friday, saturday, sunday };
        }
    }
    public class Consultant : User
    {
        public Consultant(string[] demographicInfo)
        {
            Initialize(demographicInfo);
        }
        private void Initialize(string[] demographicInfo)
        {
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

            for (int i = 0; i < 31; i++)
            {
                monday[i] = "";
                tuesday[i] = "";
                wednesday[i] = "";
                thursday[i] = "";
                friday[i] = "";
                saturday[i] = "";
                sunday[i] = "";
            }
            days = new List<string[]> { monday, tuesday, wednesday, thursday, friday, saturday, sunday };
        }
        
}
}

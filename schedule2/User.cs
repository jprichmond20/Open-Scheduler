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
        string[] monday = new string[31];
        string[] tuesday = new string[31];
        string[] wednesday = new string[31];
        string[] thursday = new string[31];
        string[] friday = new string[31];
        string[] saturday = new string[31];
        string[] sunday = new string[31];
        List<string[]> days;
        string major;
        string majMin2;
        string majMin3;
        string yearsWorked;
        string hoursPer;
        string first;
        string last;
        string username;
        string password;
        string userID;


        public User(string[] demographicInfo)
        {
            Database db = new Database();
            Initialize(demographicInfo);
            db.RegisterUser(username, password, demographicInfo);
        }

        public void PopulateSched(DataGridView schedule)
        {
            DataGridViewCellStyle sel = new DataGridViewCellStyle();
            sel.BackColor = Color.Crimson;
            for (int i = 0; i < schedule.Rows.Count; i++)
            {
                for(int j = 1; j < schedule.Columns.Count; j++)
                {
                    //MessageBox.Show(schedule.Rows[i].Cells[j].Style.BackColor.ToString());
                    //MessageBox.Show(sel.BackColor.ToString());
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

            //for (int i = 0; i < schedule.Columns.Count; i++)
            //{
            //    if (schedule.Columns[i].HeaderText != "Time")
            //    {
            //        for (int j = 0; j < schedule.Rows.Count; j++)
            //        {
            //            DataGridViewCellStyle unsel = new DataGridViewCellStyle();
            //            DataGridViewCellStyle sel = new DataGridViewCellStyle();
            //            unsel.BackColor = Color.Gainsboro;
            //            sel.BackColor = Color.Crimson;
            //            if (i == 1)
            //            {
                         
            //            }
            //        }
            //    }
            //}
        

        private void Initialize(string[] demographicInfo)
        {
            first = demographicInfo[0];
            last = demographicInfo[1];
            username = demographicInfo[2];
            password = demographicInfo[3];
            major = demographicInfo[4];
            majMin2 = demographicInfo[5];
            majMin3 = demographicInfo[6];
            yearsWorked = demographicInfo[7];
            hoursPer = demographicInfo[8];
            userID = demographicInfo[9];
           
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
            days = new List<string[]>{ monday, tuesday, wednesday, thursday, friday, saturday, sunday };
        }

    }
}

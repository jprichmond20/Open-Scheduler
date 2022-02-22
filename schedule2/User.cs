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
            Initialize(demographicInfo);
        }

        public void PopulateSched(DataGridView schedule)
        {
            for(int i = 0; i < schedule.Rows.Count; i++)
            {
                for(int j = 1; j < schedule.Columns.Count; j++)
                {
                    MessageBox.Show(schedule.Columns[j].HeaderText);
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
        }

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
        }
    }
}

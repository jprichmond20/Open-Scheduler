using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule2
{
    public class CurrentSchedule
    {
        public List<string[]> days;

        public CurrentSchedule(schedule2.Database.Schedule currSched)
        {
            days[0] = currSched.monday;
            days[1] = currSched.tuesday;
            days[2] = currSched.wednesday;
            days[3] = currSched.thursday;
            days[4] = currSched.friday;
            days[5] = currSched.saturday;
            days[6] = currSched.sunday;
        }

        public void UpdateCurrentSchedule(List<string[]> updatedSched)
        {
            for(int i = 0; i < updatedSched.Count(); i++)
            {
                days[i] = updatedSched[i];
            }
        }
    }


 
}

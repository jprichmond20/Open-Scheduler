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
            
            days.Add(currSched.monday);
            days.Add(currSched.tuesday);
            days.Add(currSched.wednesday);
            days.Add(currSched.thursday);
            days.Add(currSched.friday);
            days.Add(currSched.saturday);
            days.Add(currSched.sunday);
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

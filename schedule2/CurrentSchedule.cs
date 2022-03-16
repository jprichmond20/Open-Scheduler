using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule2
{
    public class CurrentSchedule
    // This class is used to represent the current schedule
    {
        public List<string[]> days;

        public CurrentSchedule(schedule2.Database.Schedule currSched)
        {
            // We take a current scheulde from the database and populate our list with it
            
            days.Add(currSched.monday);
            days.Add(currSched.tuesday);
            days.Add(currSched.wednesday);
            days.Add(currSched.thursday);
            days.Add(currSched.friday);
            days.Add(currSched.saturday);
            days.Add(currSched.sunday);
        }

        public void UpdateCurrentSchedule(List<string[]> updatedSched)
        // When the current schedule changes we update it with this function
        {
            for (int i = 0; i < updatedSched.Count(); i++)
            {
                days[i] = updatedSched[i];
            }
        }
    }


 
}

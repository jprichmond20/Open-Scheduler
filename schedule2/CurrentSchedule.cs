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

        public CurrentSchedule(List<string[]> currSched)
        {
            for(int i = 0; i < currSched.Count(); i++)
            {
                days.Add(currSched[i]);
            }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            if (weekEnds == null) // Checking that array "weekEnds" is initialized for TestNoWeekEnd
            {
                return startDate.AddDays(dayCount - 1);
            }

            if (weekEnds.Length==0) //Checking that we have weekends
            {
                return startDate.AddDays(dayCount - 1);
            }

            int weekend_index = 0; 

            while (dayCount > 0)
            {
                if(weekend_index>=weekEnds.Length) //Checking that we still have weekends
                {
                    return startDate.AddDays(dayCount - 1);
                }
                if (weekEnds[weekend_index] != default(WeekEnd) && weekEnds[weekend_index].StartDate.DayOfYear >= startDate.DayOfYear) // Сhecking that the variable is initialized and the next weekend in the future or now
                {
                    if (dayCount > weekEnds[weekend_index].StartDate.DayOfYear - startDate.DayOfYear) // Checking that we need the next weekend
                    {
                        dayCount -= weekEnds[weekend_index].StartDate.DayOfYear - startDate.DayOfYear;
                        startDate = weekEnds[weekend_index].EndDate.AddDays(1);
                    }
                    else
                    {
                        startDate=startDate.AddDays(dayCount - 1);
                        dayCount = 0;
                    }
                }
                ++weekend_index;
            }

            return startDate;
        }
    }
}

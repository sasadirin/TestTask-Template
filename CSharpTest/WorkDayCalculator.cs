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
           
            
            if (dayCount <= 0)
            {
                return startDate;
            }
            if (weekEnds == null)
            {
                return startDate.AddDays(dayCount - 1);
            }

            int weekend_index = 0; // variable that store number of next weekend in array 
            while (dayCount > 0)
            {
                if (weekend_index >= weekEnds.Length) // if there are no weekends ,just adding dayCount
                {
                    startDate=startDate.AddDays(dayCount - 1);
                    dayCount = 0;
                }
                else // if we have weekends , just
                {
                    if (weekEnds[weekend_index] != default(WeekEnd) && weekEnds[weekend_index].StartDate.DayOfYear >= startDate.DayOfYear) // checking that variable is initialized and adecuate
                    {

                        if (dayCount > weekEnds[weekend_index].StartDate.DayOfYear - startDate.DayOfYear)
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
            }
            return startDate;
        }
    }
}

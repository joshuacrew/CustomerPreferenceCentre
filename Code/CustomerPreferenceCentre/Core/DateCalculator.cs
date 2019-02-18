using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPreferenceCentre.Core
{
    public class DateCalculator
    {
        public static List<DateTime> GenerateDates(string[] marketingPreferenceDays)
        {
            var dates = new List<DateTime>();
            var dateIn90Days = DateTime.Today.AddDays(90);

            for (var dt = DateTime.Today; dt < dateIn90Days; dt = dt.AddDays(1))
            {
                if (marketingPreferenceDays.ToList().Contains(dt.DayOfWeek.ToString()))
                {
                    dates.Add(dt);
                }
            }

            return dates;
        }

        public static List<DateTime> GenerateDates(int? marketingPreferenceDate)
        {
            var dates = new List<DateTime>();
            var dateIn90Days = DateTime.Today.AddDays(90);

            for (var dt = DateTime.Today; dt < dateIn90Days; dt = dt.AddDays(1))
            {
                if (dt.Day == marketingPreferenceDate)
                {
                    dates.Add(dt);
                }
            }

            return dates;
        }

        public static List<DateTime> GenerateDates()
        {
            var dates = new List<DateTime>();
            var dateIn90Days = DateTime.Today.AddDays(90);

            for (var dt = DateTime.Today; dt < dateIn90Days; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            return dates;
        }
    }
}

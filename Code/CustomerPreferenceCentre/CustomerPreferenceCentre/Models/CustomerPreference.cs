using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPreferenceCentre.Models
{
    public class CustomerPreference
    {
        public string CustomerName { get; set; }

        public MarketingPreference MarketingPreference { get; set; }
    }

    public class MarketingPreference
    {
        public bool Never { get; set; }
        public bool Everyday { get; set; }
        public DateTime Date { get; set; }
        public string[] Days { get; set; }
    }
}

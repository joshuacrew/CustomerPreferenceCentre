using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPreferenceCentre.Models.Response
{
    public class CustomerPreferenceResponse
    {
        public string CustomerName { get; set; }
        public List<DateTime> MarketingDates { get; set; }
    }
}

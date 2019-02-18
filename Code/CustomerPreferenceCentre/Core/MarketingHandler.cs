using System;
using System.Collections.Generic;
using System.Linq;
using CustomerPreferenceCentre.Models.Request;
using CustomerPreferenceCentre.Models.Response;

namespace CustomerPreferenceCentre.Core
{
    public class MarketingHandler
    {
        public static List<CustomerPreferenceResponse> BuildResponse(
            IEnumerable<CustomerPreference> customerPreferences)
        {
            return customerPreferences.Select(customerPreference =>
                new CustomerPreferenceResponse
                {
                    CustomerName = customerPreference.CustomerName,
                    MarketingDates = GetMarketingDates(customerPreference.MarketingPreference)
                }).ToList();
        }

        private static List<DateTime> GetMarketingDates(MarketingPreference marketingPreference)
        {
            if (marketingPreference.Everyday == true)
            {
                return DateCalculator.GenerateDates();
            }

            if (marketingPreference.Date != null)
            {
                return DateCalculator.GenerateDates(marketingPreference.Date);
            }

            if (marketingPreference.Days != null)
            {
                return DateCalculator.GenerateDates(marketingPreference.Days);
            }

            return new List<DateTime>();
        }
    }
}
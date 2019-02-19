﻿using CustomerPreferenceCentre.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerPreferenceCentre.Core
{
    public static class ReportGenerator
    {
        public static void GenerateReport(this List<CustomerPreferenceResponse> customerPreferenceResponse)
        {
            var report = BuildDictionaryOfDatesAndNames(customerPreferenceResponse);
        }

        public static Dictionary<DateTime, List<string>> BuildDictionaryOfDatesAndNames(List<CustomerPreferenceResponse> customerPreferenceResponse)
        {
            var report = new Dictionary<DateTime, List<string>>();
            foreach (var customer in customerPreferenceResponse)
            {
                foreach (var date in customer.MarketingDates)
                {
                    if (report.ContainsKey(date))
                    {
                        var value = report[date];
                        value.Add(customer.CustomerName);
                    }
                    else
                    {
                        report.Add(date, new List<string> {customer.CustomerName});
                    }
                }
            }

            return report;
        }
    }
}

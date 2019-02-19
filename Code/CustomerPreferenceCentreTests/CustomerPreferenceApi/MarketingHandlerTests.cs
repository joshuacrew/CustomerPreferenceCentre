using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerPreferenceCentre.Core;
using CustomerPreferenceCentre.Models.Request;
using CustomerPreferenceCentre.Models.Response;
using NUnit.Framework;
using Shouldly;

namespace CustomerPreferenceCentreTests.CustomerPreference
{
    class MarketingHandlerTests
    {
        private readonly string _nameDate4 = "a";
        private readonly string _nameDaySatSun = "b";
        private readonly string _nameEveryday = "c";
        private readonly string _nameNever = "d";

        [Test]
        public void shouldReturnCorrectDatesForEachMarketingPreferenceSelected()
        {
            var preferences = new List<CustomerPreferenceCentre.Models.Request.CustomerPreference>()
            {
                new CustomerPreferenceCentre.Models.Request.CustomerPreference
                {
                    CustomerName = _nameDate4,
                    MarketingPreference = new MarketingPreference
                    {
                        Date = 4
                    }
                },
                new CustomerPreferenceCentre.Models.Request.CustomerPreference
                {
                    CustomerName = _nameDaySatSun,
                    MarketingPreference = new MarketingPreference
                    {
                        Days = new[] {"Saturday, Sunday"}
                    }
                },
                new CustomerPreferenceCentre.Models.Request.CustomerPreference
                {
                    CustomerName = _nameEveryday,
                    MarketingPreference = new MarketingPreference
                    {
                        Everyday = true
                    }
                },
                new CustomerPreferenceCentre.Models.Request.CustomerPreference
                {
                    CustomerName = _nameNever,
                    MarketingPreference = new MarketingPreference
                    {
                        Never = true
                    }
                }
            };

            var response = MarketingHandler.BuildResponse(preferences);

            var customerDate4 = GetCustomerName(response, _nameDate4);
            var customerDaySatSun = GetCustomerName(response, _nameDaySatSun);
            var customerEveryday = GetCustomerName(response, _nameEveryday);
            var customerNever = GetCustomerName(response, _nameNever);

            customerDate4.MarketingDates.All(date => date.Day == 4).ShouldBeTrue();
            customerDaySatSun.MarketingDates.All(date => date.DayOfWeek.ToString() == "Saturday"
                                        || date.DayOfWeek.ToString() == "Sunday").ShouldBeTrue();
            customerEveryday.MarketingDates.Count.ShouldBe(90);
            customerNever.MarketingDates.ShouldBeEmpty();
        }

        private static CustomerPreferenceResponse GetCustomerName(List<CustomerPreferenceResponse> response, string name)
        {
            return response.FirstOrDefault(r => r.CustomerName == name);
        }
    }
}

using CustomerPreferenceCentre.Core;
using CustomerPreferenceCentre.Models.Response;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace CustomerPreferenceCentreTests.CustomerPreferenceApi
{
    class ReportGeneratorTests
    {
        [Test]
        public void ShouldContainAllDaysWithCorrespondingName()
        {
            var input = new List<CustomerPreferenceResponse>
            {
                new CustomerPreferenceResponse
                {
                    CustomerName = "a",
                    MarketingDates = new List<DateTime> {DateTime.Today, DateTime.Today.AddDays(1)}
                }
            };

            var dictionary = input.BuildDictionaryOfDatesAndNames();

            dictionary[DateTime.Today].ShouldBe(new List<string> { "a" });
            dictionary[DateTime.Today.AddDays(1)].ShouldBe(new List<string> { "a" });
        }

        [Test]
        public void ShouldContainMultipleNamesForSelectedDay()
        {
            var input = new List<CustomerPreferenceResponse>
            {
                new CustomerPreferenceResponse
                {
                    CustomerName = "a",
                    MarketingDates = new List<DateTime> {DateTime.Today}
                },
                new CustomerPreferenceResponse
                {
                    CustomerName = "b",
                    MarketingDates = new List<DateTime> {DateTime.Today}
                }
            };

            var dictionary = DictionaryBuilderExtension.BuildDictionaryOfDatesAndNames(input);

            dictionary[DateTime.Today].ShouldBe(new List<string> { "a", "b" });
        }
    }
}

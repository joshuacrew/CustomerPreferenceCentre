using CustomerPreferenceCentre.Controllers;
using NUnit.Framework;
using Shouldly;
using System;
using System.Linq;

namespace CustomerPreferenceCentreTests.CustomerPreference
{
    class GenerateDatesTests
    {
        [Test]
        public void ShouldReturnAllDatesWhen90DatesSelected()
        {
            var dates = CustomerPreferenceController.GenerateDates(90);

            dates.Count.ShouldBe(90);
            dates.First().ShouldBe(DateTime.Today);
        }

        [Test]
        public void ShouldReturnSelectedDatesWhenSpecificDayOfMonthSelected()
        {
            var dates = CustomerPreferenceController.GenerateDates((int?)2);

            dates.All(date => date.Day == 2).ShouldBeTrue();
        }

        [TestCase("Monday")]
        [TestCase("Wednesday")]
        public void ShouldReturnSelectedDaysWhenSpecifiedDaysOfWeekSelected(string day)
        {
            string[] days = { day };

            var dates = CustomerPreferenceController.GenerateDates(days);

            dates.All(date => date.DayOfWeek.ToString() == day).ShouldBeTrue();
        }
    }
}

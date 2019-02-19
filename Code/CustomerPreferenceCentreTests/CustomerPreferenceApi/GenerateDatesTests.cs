using System;
using System.Linq;
using CustomerPreferenceCentre.Core;
using NUnit.Framework;
using Shouldly;

namespace CustomerPreferenceCentreTests.CustomerPreference
{
    class GenerateDatesTests
    {
        [Test]
        public void ShouldReturnAllDatesWhen90DatesSelected()
        {
            var dates = DateCalculator.GenerateDates();

            dates.Count.ShouldBe(90);
            dates.First().ShouldBe(DateTime.Today);
        }

        [Test]
        public void ShouldReturnSelectedDatesWhenSpecificDayOfMonthSelected()
        {
            var dates = DateCalculator.GenerateDates(2);

            dates.All(date => date.Day == 2).ShouldBeTrue();
        }

        [TestCase("Monday")]
        [TestCase("Wednesday")]
        public void ShouldReturnSelectedDaysWhenSpecifiedDaysOfWeekSelected(string day)
        {
            string[] days = { day };

            var dates = DateCalculator.GenerateDates(days);

            dates.All(date => date.DayOfWeek.ToString() == day).ShouldBeTrue();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CustomerPreferenceCentre.Models;
using CustomerPreferenceCentre.Models.Request;
using CustomerPreferenceCentre.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPreferenceCentre.Controllers
{
    [Route("customer-preference")]
    public class CustomerPreferenceController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CustomerPreferenceResponse), 200)]
        public IActionResult Post([FromBody]List<CustomerPreference> customerPreferences)
        {
            if (ModelState.IsValid)
            {
                var customerPreferenceResponse = BuildResponse(customerPreferences);
                return Ok(customerPreferenceResponse);
            }
        
            return BadRequest(ModelState);
        }

        private static List<CustomerPreferenceResponse> BuildResponse(
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
            if (marketingPreference.Never == true)
            {
                return new List<DateTime>();
            }

            if (marketingPreference.Everyday == true)
            {
                return GenerateDates(90);
            }

            if (marketingPreference.Date != null)
            {
                return GenerateDates(marketingPreference.Date);
            }

            if (marketingPreference.Days != null)
            {
                return GenerateDates(marketingPreference.Days);
            }

            
            return new List<DateTime>();
        }

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

        public static List<DateTime> GenerateDates(int numberOfDays)
        {
            var dates = new List<DateTime>();
            var dateIn90Days = DateTime.Today.AddDays(numberOfDays);

            for (var dt = DateTime.Today; dt < dateIn90Days; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            return dates;
        }
    }
}

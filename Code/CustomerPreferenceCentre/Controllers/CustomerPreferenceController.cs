using System;
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

            }
            return new List<DateTime>();
        }

        private static List<DateTime> GenerateDates(int numberOfDays)
        {
            var dates = new List<DateTime>();
            var dateIn90Days = DateTime.Now.AddDays(numberOfDays);

            for (var dt = DateTime.Now; dt <= dateIn90Days; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            return dates;
        }
    }
}

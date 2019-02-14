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
                    MarketingDates = new List<DateTime>{ DateTime.Now }
                }).ToList();
        }
    }
}

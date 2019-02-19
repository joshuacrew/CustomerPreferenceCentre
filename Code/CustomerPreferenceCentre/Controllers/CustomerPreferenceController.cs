using System.Collections;
using System.Collections.Generic;
using CustomerPreferenceCentre.Core;
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
                var customerPreferenceResponse = MarketingHandler.BuildResponse(customerPreferences);
                customerPreferenceResponse.GenerateReport();
                return Ok(customerPreferenceResponse);
            }
        
            return BadRequest(ModelState);
        }
    }
}

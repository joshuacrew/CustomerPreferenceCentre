using System.Collections.Generic;
using CustomerPreferenceCentre.Core;
using CustomerPreferenceCentre.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPreferenceCentre.Controllers
{
    [Route("customer-preference")]
    public class CustomerPreferenceController : ControllerBase
    {
        private readonly IReport _report;

        public CustomerPreferenceController(IReport report)
        {
            _report = report;
        }

        [HttpPost]
        public IActionResult Post([FromBody]List<CustomerPreference> customerPreferences)
        {
            if (ModelState.IsValid)
            {
                var customerPreferenceResponse = MarketingHandler.BuildResponse(customerPreferences);
                var dictionary = customerPreferenceResponse.BuildDictionaryOfDatesAndNames();
                _report.CreateReport(dictionary);
                return Ok();
            }
        
            return BadRequest(ModelState);
        }
    }
}

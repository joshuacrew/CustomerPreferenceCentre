using CustomerPreferenceCentre.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPreferenceCentre.Controllers
{
    [Route("customer-preference")]
    public class CustomerPreferenceController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody]CustomerPreference customerPreferences)
        {
            return Ok();
        }
    }
}

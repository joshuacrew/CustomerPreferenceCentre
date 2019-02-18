using CustomerPreferenceCentre.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPreferenceCentre.Controllers
{
    [Route("service-health")]
    [ApiController]
    public class ServiceHealthController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}

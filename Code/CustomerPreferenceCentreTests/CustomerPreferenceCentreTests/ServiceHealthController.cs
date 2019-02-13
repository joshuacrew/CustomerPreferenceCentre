using NUnit.Framework;
using Shouldly;
using System.Net;
using System.Net.Http;

namespace CustomerPreferenceCentreTests
{
    public class ServiceHealthController
    {
        [Test]
        public void ShouldBeOk()
        {
            var result = new HttpClient().GetAsync(Urls.ServiceHealthUrl).Result;

            result.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}

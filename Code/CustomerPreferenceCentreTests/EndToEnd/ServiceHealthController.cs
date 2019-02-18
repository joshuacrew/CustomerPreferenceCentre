using System.Net;
using System.Net.Http;
using CustomerPreferenceCentreTests.Infrastructure;
using NUnit.Framework;
using Shouldly;

namespace CustomerPreferenceCentreTests.EndToEnd
{
    public class ServiceHealthController
    {
        [Test]
        public void ShouldReturnOk()
        {
            var testServer = IntegrationTestInfrastructure.BuildTestServer();

            using (var client = testServer.CreateClient())
            {
                var result = client.GetAsync(Urls.ServiceHealthUrl).Result;

                result.StatusCode.ShouldBe(HttpStatusCode.OK);
            }
        }
    }
}

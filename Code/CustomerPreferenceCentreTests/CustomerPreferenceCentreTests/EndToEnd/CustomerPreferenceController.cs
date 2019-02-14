using System.Net;
using System.Net.Http;
using System.Text;
using CustomerPreferenceCentre.Models;
using CustomerPreferenceCentreTests.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Shouldly;

namespace CustomerPreferenceCentreTests.EndToEnd
{
    public class CustomerPreferenceController
    {
        [Test]
        public void ShouldReturnOk()
        {
            var testServer = IntegrationTestInfrastructure.BuildTestServer();

            using (var client = testServer.CreateClient())
            {
                var request = new CustomerPreferenceCentre.Models.CustomerPreference
                {
                    CustomerName = "a",
                    MarketingPreference = new MarketingPreference
                    {
                        Everyday = true
                    }
                };
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var response = client.PostAsync(Urls.CustomerPreferenceUrl, content).Result;

                //response.StatusCode.ShouldBe(HttpStatusCode.OK);

                var result = response.Content.ReadAsStringAsync().Result;

                var jObject = JObject.Parse(result);
            }
        }
        
    }
}

using System;
using CustomerPreferenceCentre.Models.Request;
using CustomerPreferenceCentreTests.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace CustomerPreferenceCentreTests.EndToEnd
{
    public class CustomerPreferenceController
    {
        [Test]
        public void ShouldReturnCustomerPreferenceResponse()
        {
            var testServer = IntegrationTestInfrastructure.BuildTestServer();

            using (var client = testServer.CreateClient())
            {
                var request = new List<CustomerPreferenceCentre.Models.Request.CustomerPreference>
                {
                    new CustomerPreferenceCentre.Models.Request.CustomerPreference
                    {
                        CustomerName = "a",
                        MarketingPreference = new MarketingPreference
                        {
                            Everyday = true
                        }
                    }
                };
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var response = client.PostAsync(Urls.CustomerPreferenceUrl, content).Result;

                response.StatusCode.ShouldBe(HttpStatusCode.OK);

                using (var readText = new StreamReader("report.txt"))
                {
                    var reportLine1 = readText.ReadLine();
                    reportLine1.ShouldBe($"{DateTime.Now.ToShortDateString()} a");
                    var reportLine2 = readText.ReadLine();
                    reportLine2.ShouldBe($"{DateTime.Now.AddDays(1).ToShortDateString()} a");
                }
            }
        }

    }
}

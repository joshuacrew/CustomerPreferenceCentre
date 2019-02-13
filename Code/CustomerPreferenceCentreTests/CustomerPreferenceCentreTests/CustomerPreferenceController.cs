using CustomerPreferenceCentre.Models;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace CustomerPreferenceCentreTests
{
    public class CustomerPreferenceController
    {
        [Test]
        public void ShouldReturnHelloWorld()
        {
            var content = new StringContent(new CustomerPreference().ToString(), Encoding.UTF8, "application/json");

            var result = new HttpClient().PostAsync(Urls.CustomerPreferenceUrl, content).Result;

            result.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}

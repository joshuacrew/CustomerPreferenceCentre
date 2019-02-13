using System.Net.Http;
using NUnit.Framework;
using Shouldly;

namespace CustomerPreferenceCentreTests
{
    public class CustomerPreferenceController
    {
        [Test]
        public void ShouldReturnHelloWorld()
        {
            var result = new HttpClient().GetAsync(Urls.CustomerPreferenceUrl).Result;

            result.Content.ReadAsStringAsync().Result.ShouldContain("Hello World");
        }
    }
}

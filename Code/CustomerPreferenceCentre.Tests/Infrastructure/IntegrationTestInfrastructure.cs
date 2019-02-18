using CustomerPreferenceCentre;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace CustomerPreferenceCentreTests.Infrastructure
{
    class IntegrationTestInfrastructure
    {
        public static TestServer BuildTestServer()
        {
            return new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
        }
    }
}
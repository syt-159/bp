using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Microsoft.ApplicationInsights;

namespace BPCalculator.Tests
{
    public class StartupTests
    {
        [Fact]
        public void ConfigurationService_WithoutConnectionString()
        {
            var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["APPLICATIONINSIGHTS_CONNECTION_STRING"] = ""
            }).Build();

            var services = new ServiceCollection();
            var startup = new Startup(configuration);

            startup.ConfigureServices(services);

            Assert.DoesNotContain(services, desc => desc.ServiceType == typeof(TelemetryClient));
        }

        [Fact]
        public void ConfigurationService_WithConnectString()
        {
            var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["APPLICATIONINSIGHTS_CONNECTION_STRING"] = "InstrumentationKey=00000000-0000-0000-0000-000000000001"
            }).Build();

            var services = new ServiceCollection();
            var startup = new Startup(configuration);

            startup.ConfigureServices(services);

            Assert.Contains(services, desc => desc.ServiceType == typeof(TelemetryClient));
        }
    }
}
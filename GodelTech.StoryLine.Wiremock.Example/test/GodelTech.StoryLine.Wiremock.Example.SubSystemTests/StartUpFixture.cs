using System.Reflection;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace GodelTech.StoryLine.Wiremock.Example.SubSystemTests
{
    public sealed class StartUpFixture
    {
        public StartUpFixture(IMessageSink logger)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            Rest.Config.AddServiceEndpont("GodelTech.StoryLine.Wiremock.Example", config["ServiceAddress"]);
            Rest.Config.SetAssemblies(typeof(StartUpFixture).GetTypeInfo().Assembly);

            Config.SetBaseAddress(config["WireMockAddress"]);
        }
    }
}

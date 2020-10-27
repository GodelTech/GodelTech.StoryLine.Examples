using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace GodelTech.StoryLine.Rest.Example.SubSystemTests
{
    public sealed class StartUpFixture
    {
        public StartUpFixture(IMessageSink logger)
        {
            var configuration = GetConfiguration(logger);
            Config.AddServiceEndpont("GodelTech.StoryLine.Rest.Example", configuration["ServiceAddress"]);
            Config.SetAssemblies(typeof(StartUpFixture).GetTypeInfo().Assembly);
        }

        private static IConfiguration GetConfiguration(IMessageSink logger)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty;

            logger.OnMessage(new DiagnosticMessage($"Running tests with ASPNETCORE_ENVIRONMENT={env}"));

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

            return builder.Build();
        }
    }
}

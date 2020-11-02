using System;

namespace GodelTech.StoryLine.Wiremock.Example.Services
{
    public class HttpClientConfiguration : IHttpClientConfiguration
    {
        public string BaseAddress { get; set; }

        public TimeSpan Timeout { get; set; }
    }
}

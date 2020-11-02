using System;

namespace GodelTech.StoryLine.Wiremock.Example.Services
{
    public interface IHttpClientConfiguration
    {
        string BaseAddress { get; }

        TimeSpan Timeout { get; }
    }
}

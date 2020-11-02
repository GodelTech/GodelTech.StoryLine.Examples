namespace GodelTech.StoryLine.Wiremock.Example.Services
{
    public interface IHttpClientConfigurationService
    {
        IHttpClientConfiguration Get(string serviceName);
    }
}

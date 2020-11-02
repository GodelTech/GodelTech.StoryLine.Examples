namespace GodelTech.StoryLine.Wiremock.Example.Services
{
    public interface IServiceClientFactory
    {
        IServiceClient Create(string serviceName);
    }
}

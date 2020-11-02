namespace GodelTech.StoryLine.Wiremock.Example.Services
{
    public interface IServiceClient
    {
        TResult Get<TResult>(string url);

        TResult Post<TContent, TResult>(string url, TContent content);
    }
}

using Xunit;

namespace GodelTech.StoryLine.Wiremock.Example.SubSystemTests
{
    [CollectionDefinition(nameof(StartUpFixture))]
    public sealed class StartUpFixtureCollection : ICollectionFixture<StartUpFixture>
    {
    }
}

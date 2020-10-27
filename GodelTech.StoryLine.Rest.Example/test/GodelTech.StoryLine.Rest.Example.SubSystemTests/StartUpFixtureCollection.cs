using Xunit;

namespace GodelTech.StoryLine.Rest.Example.SubSystemTests
{
    [CollectionDefinition(nameof(StartUpFixture))]
    public sealed class StartUpFixtureCollection : ICollectionFixture<StartUpFixture>
    {
    }
}

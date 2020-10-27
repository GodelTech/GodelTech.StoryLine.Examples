using GodelTech.StoryLine.Rest.Example.SubSystemTests.Actions.Users;
using Xunit;

namespace GodelTech.StoryLine.Rest.Example.SubSystemTests.v1.Resources.Users
{
    public sealed class PostTests : ApiTestBase
    {
        [Fact]
        public void When_NewUser_ShouldCreateSuccessfully()
        {
            Scenario.New()
                .When()
                .Performs<CreateUser>()
                .Run();
        }
    }
}

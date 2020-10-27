using System.Net;
using GodelTech.StoryLine.Rest.Actions;
using GodelTech.StoryLine.Rest.Example.SubSystemTests.Actions.Users;
using GodelTech.StoryLine.Rest.Example.SubSystemTests.Actions.Users.Contract;
using GodelTech.StoryLine.Rest.Expectations;
using Xunit;

namespace GodelTech.StoryLine.Rest.Example.SubSystemTests.v1.Resources.Users
{
    public sealed class DeleteTests : ApiTestBase
    {
        [Fact]
        public void When_ValidRequestIsSent_ShouldDeleteCorrectly()
        {
            var actor = new Actor();

            Scenario.New()
                .Given(actor)
                .HasPerformed<CreateUser>()
                .When(actor)
                .Performs<HttpRequest, UserDocument>((res, doc) => res
                    .Method("DELETE")
                    .Url($"v1/users/{doc.Id}"))
                .Then(actor)
                .Expects<HttpResponse>(res => res
                    .Status(HttpStatusCode.NoContent))
                .Run();
        }
    }
}

using System.Net;
using GodelTech.StoryLine.Rest.Actions;
using GodelTech.StoryLine.Rest.Example.SubSystemTests.Actions.Users;
using GodelTech.StoryLine.Rest.Example.SubSystemTests.Actions.Users.Contract;
using GodelTech.StoryLine.Rest.Expectations;
using Xunit;

namespace GodelTech.StoryLine.Rest.Example.SubSystemTests.v1.Resources.Users
{
    public sealed class GetTests : ApiTestBase
    {
        [Fact]
        public void Get_WhenValidRequestIsSent_ShouldReturnUser()
        {
            var actor = new Actor();

            Scenario.New()
                .Given(actor)
                .HasPerformed<CreateUser>()
                .When(actor)
                .Performs<HttpRequest, UserDocument>((req, doc) => req
                    .Method("GET")
                    .Url($"v1/users/{doc.Id}"))
                .Then()
                .Expects<HttpResponse>(res => res
                    .Status(HttpStatusCode.OK)
                    .ReasonPhrase("OK")
                    .Header("Content-Type", "application/json; charset=utf-8"))
                .Run();
        }
    }
}

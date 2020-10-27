using System.Net;
using GodelTech.StoryLine.Rest.Actions;
using GodelTech.StoryLine.Rest.Actions.Extensions;
using GodelTech.StoryLine.Rest.Example.SubSystemTests.Actions.Users;
using GodelTech.StoryLine.Rest.Example.SubSystemTests.Actions.Users.Contract;
using GodelTech.StoryLine.Rest.Expectations;
using GodelTech.StoryLine.Rest.Expectations.Extensions;
using Xunit;

namespace GodelTech.StoryLine.Rest.Example.SubSystemTests.v1.Resources.Users
{
    public sealed class PutTests : ApiTestBase
    {
        [Fact]
        public void When_ValidRequestIsSent_ShouldUpdateCorrectly()
        {
            var actor = new Actor();
            var updateUser = CreateValidUpdateUserRequest();

            Scenario.New()
                .Given(actor)
                .HasPerformed<CreateUser>()
                .When(actor)
                .Performs<HttpRequest, UserDocument>((req, doc) => req
                    .Method("PUT")
                    .Url($"v1/users/{doc.Id}")
                    .Header("Content-Type", "application/json")
                    .JsonObjectBody(updateUser))
                .Then(actor)
                .Expects<HttpResponse>(res => res
                    .Status(HttpStatusCode.OK)
                    .JsonBody()
                    .MatchesObject(CreateValidUpdateUserRequest(), "createdOn", "updatedOn", "id"))
                .Run();
        }

        private static UpdateUserRequest CreateValidUpdateUserRequest()
        {
            return new UpdateUserRequest
            {
                FirstName = "Jane",
                LastName = "Doe",
                Age = "25"
            };
        }
    }
}

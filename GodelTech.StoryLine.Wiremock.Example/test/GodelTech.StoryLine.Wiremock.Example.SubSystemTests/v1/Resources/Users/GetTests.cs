using System.Net;
using GodelTech.StoryLine.Rest.Actions;
using GodelTech.StoryLine.Rest.Expectations;
using GodelTech.StoryLine.Rest.Expectations.Extensions;
using GodelTech.StoryLine.Wiremock.Example.SubSystemTests.Actions.Users;
using GodelTech.StoryLine.Wiremock.Example.SubSystemTests.Actions.Users.Contract;
using Xunit;

namespace GodelTech.StoryLine.Wiremock.Example.SubSystemTests.v1.Resources.Users
{
    public sealed class GetTests : ApiTestBase
    {
        private readonly User _request;

        public GetTests()
        {
            _request = new User()
            {
                Id = 20,
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };
        }

        [Fact]
        public void Get_WhenValidRequestIsSent_ShouldReturnUser()
        {
            Scenario.New()
                .Given()
                .HasPerformed<CreateUser>()
                .When()
                .Performs<HttpRequest>(req => req
                    .Method("GET")
                    .Url($"v1/users/{_request.Id}"))
                .Then()
                .Expects<HttpResponse>(res => res
                    .Status(HttpStatusCode.OK)
                    .ReasonPhrase("OK")
                    .Header("Content-Type", "application/json; charset=utf-8")
                    .JsonBody()
                    .MatchesObject(_request))
                .Run();
        }
    }
}

using System.Net;
using GodelTech.StoryLine.Rest.Actions;
using GodelTech.StoryLine.Rest.Actions.Extensions;
using GodelTech.StoryLine.Rest.Expectations;
using GodelTech.StoryLine.Rest.Expectations.Extensions;
using GodelTech.StoryLine.Wiremock.Actions;
using GodelTech.StoryLine.Wiremock.Builders;
using GodelTech.StoryLine.Wiremock.Example.SubSystemTests.Actions.Users.Contract;
using GodelTech.StoryLine.Wiremock.Example.SubSystemTests.Helpers;
using Xunit;

namespace GodelTech.StoryLine.Wiremock.Example.SubSystemTests.v1.Resources.Users
{
    public sealed class PostTests : ApiTestBase
    {
        private readonly User _request;
        private readonly User _response;

        public PostTests()
        {
            _request = new User
            {
                FirstName = "Diamond",
                LastName = "Dragon",
                Age = 23
            };

            _response = new User
            {
                Id = 122,
                FirstName = "Diamond",
                LastName = "Dragon",
                Age = 23
            };
        }

        [Fact]
        public void When_NewUser_ShouldBeCreatedSuccessfully()
        {
            Scenario.New()
                .Given()
                .HasPerformed<MockHttpRequest>(x => x
                    .Request(req => req
                        .Method("POST")
                        .UrlPath(UrlHelper.ToUserServiceUrl("/users"))
                        .Body()
                        .EqualToJsonObjectBody(_request, false))
                    .Response(res => res
                        .Status(HttpStatusCode.OK)
                        .JsonObjectBody(_response)))
                .When()
                    .Performs<HttpRequest>(req => req
                    .Method("POST")
                    .Header("Content-Type", "application/json")
                    .Url("/v1/users")
                    .JsonObjectBody(_request))
                .Then()
                .Expects<HttpResponse>(res => res
                    .Status(HttpStatusCode.Created)
                    .ReasonPhrase("Created")
                    .JsonBody()
                    .MatchesObject(_response))
                .Run();
        }
    }
}

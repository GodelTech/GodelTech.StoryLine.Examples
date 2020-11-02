using System.Net;
using GodelTech.StoryLine.Rest.Actions;
using GodelTech.StoryLine.Rest.Expectations;
using GodelTech.StoryLine.Rest.Expectations.Extensions;
using GodelTech.StoryLine.Wiremock.Actions;
using GodelTech.StoryLine.Wiremock.Builders;
using GodelTech.StoryLine.Wiremock.Example.SubSystemTests.Actions.Users.Contract;
using GodelTech.StoryLine.Wiremock.Example.SubSystemTests.Helpers;
using Xunit;

namespace GodelTech.StoryLine.Wiremock.Example.SubSystemTests.v1.Resources.Users
{
    public sealed class GetAllTests : ApiTestBase
    {
        private readonly UserCollection _users;

        public GetAllTests()
        {
            _users = new UserCollection
            {
                Items = new[]
                {
                    new User
                    {
                        FirstName = "Diamond",
                        LastName = "Dragon",
                        Age = 33
                    },
                    new User
                    {
                        FirstName = "Silver",
                        LastName = "Eagle",
                        Age = 44
                    }
                }
            };
        }

        [Fact]
        public void GetAll_WhenValidRequestIsSent_ShouldReturnJsonWithResult()
        {
            Scenario.New()
                .Given()
                .HasPerformed<MockHttpRequest>(x => x
                    .Request(req => req
                        .Method("GET")
                        .UrlPath(UrlHelper.ToUserServiceUrl("/users")))
                    .Response(res => res
                        .Status(HttpStatusCode.OK)
                        .JsonObjectBody(_users)))
                    .When()
                    .Performs<HttpRequest>(req => req
                        .Url("/v1/users"))
                    .Then()
                    .Expects<HttpResponse>(res => res
                        .Status(HttpStatusCode.OK)
                        .JsonBody()
                        .MatchesObject(_users))
                    .Run();
        }
    }
}

using System.Net;
using GodelTech.StoryLine.Rest.Actions;
using GodelTech.StoryLine.Rest.Expectations;
using Xunit;

namespace GodelTech.StoryLine.Rest.Example.SubSystemTests.v1.Resources.Users
{
    public sealed class GetAllTests : ApiTestBase
    {
        [Fact]
        public void GetAll_WhenValidRequestIsSent_ShouldReturnJsonWithResult()
        {
            Scenario.New()
                .When()
                .Performs<HttpRequest>(req => req
                    .Method("GET")
                    .Url($"v1/users"))
                .Then()
                .Expects<HttpResponse>(res => res
                    .Status(HttpStatusCode.OK)
                    .ReasonPhrase("OK")
                    .Header("Content-Type", "application/json; charset=utf-8"))
                .Run();
        }
    }
}

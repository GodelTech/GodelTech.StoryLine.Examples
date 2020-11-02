using System;
using System.Net;
using GodelTech.StoryLine.Contracts;
using GodelTech.StoryLine.Rest.Actions.Extensions;
using GodelTech.StoryLine.Wiremock.Actions;
using GodelTech.StoryLine.Wiremock.Builders;
using GodelTech.StoryLine.Wiremock.Example.SubSystemTests.Actions.Users.Contract;
using GodelTech.StoryLine.Wiremock.Example.SubSystemTests.Helpers;

namespace GodelTech.StoryLine.Wiremock.Example.SubSystemTests.Actions.Users
{
    public sealed class CreateUserAction : IAction
    {
        private readonly User _createUserRequest;

        public CreateUserAction(User createUserRequest)
        {
            _createUserRequest = createUserRequest ?? throw new ArgumentNullException(nameof(User));
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            Scenario.New()
                .When(actor)
                .Performs<MockHttpRequest>(x => x
                    .Request(req => req
                        .Method("GET")
                        .UrlPath(UrlHelper.ToUserServiceUrl($"/users/{_createUserRequest.Id}")))
                    .Response(res => res
                        .Status(HttpStatusCode.OK)
                        .JsonObjectBody(_createUserRequest)))
                .Run();
        }
    }
}

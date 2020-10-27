using System;
using System.Net;
using GodelTech.StoryLine.Contracts;
using GodelTech.StoryLine.Rest.Actions;
using GodelTech.StoryLine.Rest.Actions.Extensions;
using GodelTech.StoryLine.Rest.Example.SubSystemTests.Actions.Users.Contract;
using GodelTech.StoryLine.Rest.Expectations;
using GodelTech.StoryLine.Rest.Extensions;
using GodelTech.StoryLine.Rest.Services.Http;
using GodelTech.StoryLine.Utils.Actions;
using GodelTech.StoryLine.Utils.Services;

namespace GodelTech.StoryLine.Rest.Example.SubSystemTests.Actions.Users
{
    public sealed class CreateUserAction : IAction
    {
        private readonly CreateUserRequest _createUserRequest;

        public CreateUserAction(CreateUserRequest createUserRequest)
        {
            _createUserRequest = createUserRequest ?? throw new ArgumentNullException(nameof(CreateUserRequest));
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            Scenario.New()
                .When(actor)
                .Performs<HttpRequest>(req => req
                    .Method("POST")
                    .Header("Content-Type", "application/json")
                    .Url($"v1/users")
                    .JsonObjectBody(_createUserRequest))
                .Performs<Transform, IResponse>((x, r) => x
                    .From(r.GetText())
                    .To<UserDocument>()
                    .Using<JsonConverter>())
                .Then(actor)
                .Expects<HttpResponse>(res => res
                    .Status(HttpStatusCode.Created)
                    .ReasonPhrase("Created"))
                .Run();
        }
    }
}

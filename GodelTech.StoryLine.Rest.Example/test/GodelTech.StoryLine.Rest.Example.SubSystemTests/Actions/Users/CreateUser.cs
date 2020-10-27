using GodelTech.StoryLine.Contracts;
using GodelTech.StoryLine.Rest.Example.SubSystemTests.Actions.Users.Contract;

namespace GodelTech.StoryLine.Rest.Example.SubSystemTests.Actions.Users
{
    public sealed class CreateUser : IActionBuilder
    {
        private readonly CreateUserRequest _user;

        public CreateUser()
        {
            _user = CreateDefault();
        }

        public IAction Build()
        {
            return new CreateUserAction(_user);
        }

        private static CreateUserRequest CreateDefault()
        {
            return new CreateUserRequest
            {
                FirstName = "John",
                LastName = "Doe",
                Age = "30"
            };
        }
    }
}

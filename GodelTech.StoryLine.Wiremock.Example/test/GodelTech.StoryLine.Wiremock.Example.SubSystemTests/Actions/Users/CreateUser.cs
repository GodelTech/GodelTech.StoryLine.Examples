using GodelTech.StoryLine.Contracts;
using GodelTech.StoryLine.Wiremock.Example.SubSystemTests.Actions.Users.Contract;

namespace GodelTech.StoryLine.Wiremock.Example.SubSystemTests.Actions.Users
{
    public sealed class CreateUser : IActionBuilder
    {
        private readonly User _userRequest;

        public CreateUser()
        {
            _userRequest = CreateDefault();
        }

        public IAction Build()
        {
            return new CreateUserAction(_userRequest);
        }

        private static User CreateDefault()
        {
            return new User
            {
                Id = 20,
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };
        }
    }
}

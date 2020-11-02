using System;
using GodelTech.StoryLine.Wiremock.Example.Contracts;

namespace GodelTech.StoryLine.Wiremock.Example.Services
{
    public class UserResource : IUserResource
    {
        private const string UsersService = "users";
        public const int MaxTake = 25;

        private readonly IServiceClientFactory _clientFactory;

        public UserResource(IServiceClientFactory clientFactory)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        public User GetUser(long id)
        {
            return _clientFactory.Create(UsersService).Get<User>($"users/{id}");
        }

        public User Create(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return _clientFactory.Create(UsersService).Post<User, User>("users", user);
        }

        public UserCollection GetAll(int skip, int take)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip));
            if (take <= 0)
                throw new ArgumentOutOfRangeException(nameof(take));
            if (take > MaxTake)
                throw new ArgumentOutOfRangeException(nameof(take));

            return _clientFactory.Create(UsersService).Get<UserCollection>($"users?skip={skip}&take={take}");
        }
    }
}

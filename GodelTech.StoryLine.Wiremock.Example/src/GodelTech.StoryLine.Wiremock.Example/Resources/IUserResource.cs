using System;
using GodelTech.StoryLine.Wiremock.Example.Contracts;

namespace GodelTech.StoryLine.Wiremock.Example.Services
{
    public interface IUserResource
    {
        User GetUser(long id);

        User Create(User user);

        UserCollection GetAll(int skip, int take);
    }
}

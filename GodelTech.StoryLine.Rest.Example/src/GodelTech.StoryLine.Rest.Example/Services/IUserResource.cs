using System;
using GodelTech.StoryLine.Rest.Example.Contracts;

namespace GodelTech.StoryLine.Rest.Example.Services
{
    public interface IUserResource
    {
        User Get(Guid id);

        User Create(User user);

        User Update(Guid id, User user);

        bool Exists(Guid id);

        void Delete(Guid id);

        UserCollection GetAll(int skip, int take);
    }
}

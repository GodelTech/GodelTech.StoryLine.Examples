using System;

namespace GodelTech.StoryLine.Rest.Example.SubSystemTests.Actions.Users.Contract
{
    public class UserDocument : CreateUserRequest
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}

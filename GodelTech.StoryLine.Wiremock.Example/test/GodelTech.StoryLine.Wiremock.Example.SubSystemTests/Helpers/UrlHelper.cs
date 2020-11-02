using System;

namespace GodelTech.StoryLine.Wiremock.Example.SubSystemTests.Helpers
{
    public static class UrlHelper
    {
        public static string ToUserServiceUrl(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(path));

            return "/userservice" + path;
        }
    }
}

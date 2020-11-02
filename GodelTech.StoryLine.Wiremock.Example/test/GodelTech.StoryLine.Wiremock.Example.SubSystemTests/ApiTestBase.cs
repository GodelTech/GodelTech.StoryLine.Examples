using System;
using Xunit;

namespace GodelTech.StoryLine.Wiremock.Example.SubSystemTests
{
    [Collection(nameof(StartUpFixture))]
    public abstract class ApiTestBase : IDisposable
    {
        protected ApiTestBase()
        {
            Config.ResetAll();
        }

        public virtual void Dispose()
        {
            Config.ResetAll();
        }
    }
}

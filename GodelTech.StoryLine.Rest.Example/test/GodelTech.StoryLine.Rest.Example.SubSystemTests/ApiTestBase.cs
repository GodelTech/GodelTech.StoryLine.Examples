using System;
using Xunit;

namespace GodelTech.StoryLine.Rest.Example.SubSystemTests
{
    [Collection(nameof(StartUpFixture))]
    public abstract class ApiTestBase : IDisposable
    {
        public virtual void Dispose()
        {
        }
    }
}

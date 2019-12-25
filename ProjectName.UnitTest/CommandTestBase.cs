using ProjectName.Infrastructure.Database;
using System;

namespace ProjectName.UnitTest
{
    public class CommandTestBase : IDisposable
    {
        public CommandTestBase()
        {
            Context = BlogDbTestContextFactory.Create();
        }

        public BlogContext Context { get; }

        public void Dispose()
        {
            BlogDbTestContextFactory.Destroy(Context);
        }
    }
}
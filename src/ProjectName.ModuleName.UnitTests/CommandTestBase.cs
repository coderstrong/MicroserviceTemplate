using ProjectName.ModuleName.Infrastructure.Database;
using System;

namespace ProjectName.ModuleName.UnitTest
{
    public class CommandTestBase : IDisposable
    {
        public CommandTestBase()
        {
            Context = BlogDbTestContextFactory.Create();
        }

        public ProjectNameModuleNameContext Context { get; }

        public void Dispose()
        {
            BlogDbTestContextFactory.Destroy(Context);
        }
    }
}
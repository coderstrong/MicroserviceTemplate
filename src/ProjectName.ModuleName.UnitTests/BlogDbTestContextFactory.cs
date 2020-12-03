using Microsoft.EntityFrameworkCore;
using ProjectName.ModuleName.Infrastructure.Database;
using ProjectName.ModuleName.Infrastructure.Utils;
using System;

namespace ProjectName.ModuleName.UnitTest
{
    public class BlogDbTestContextFactory
    {
        public static ProjectNameModuleNameContext Create()
        {
            var options = new DbContextOptionsBuilder<ProjectNameModuleNameContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ProjectNameModuleNameContext(options, new NoMediator());

            context.Database.EnsureCreated();

            SeedSampleData(context);

            return context;
        }

        public static void SeedSampleData(ProjectNameModuleNameContext context)
        {
            context.SaveChanges();
        }

        public static void Destroy(ProjectNameModuleNameContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
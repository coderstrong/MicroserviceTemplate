using Microsoft.EntityFrameworkCore;
using ProjectName.ModuleName.Infrastructure.Database;
using ProjectName.ModuleName.Infrastructure.Utils;
using System;

namespace ProjectName.ModuleName.UnitTest
{
    public class BlogDbTestContextFactory
    {
        public static BlogContext Create()
        {
            var options = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new BlogContext(options, new NoMediator());

            context.Database.EnsureCreated();

            SeedSampleData(context);

            return context;
        }

        public static void SeedSampleData(BlogContext context)
        {
            context.SaveChanges();
        }

        public static void Destroy(BlogContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
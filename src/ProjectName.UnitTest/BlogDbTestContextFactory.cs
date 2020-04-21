using Microsoft.EntityFrameworkCore;
using ProjectName.Infrastructure.Database;
using ProjectName.Infrastructure.Utils;
using System;

namespace ProjectName.UnitTest
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
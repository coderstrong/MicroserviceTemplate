using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProjectName.Infrastructure.Utils;

namespace ProjectName.Infrastructure.Database
{
    public class BlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();

            optionsBuilder.UseSqlServer("Server=.;Database=Employee;user id=sa;password=123456");

            return new BlogContext(optionsBuilder.Options, new NoMediator());
        }
    }
}

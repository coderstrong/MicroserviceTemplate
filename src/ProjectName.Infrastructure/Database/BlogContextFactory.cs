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

            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Database\\MSSQL11.MSSQLSERVER\\DATA\\ProjectName.mdf;Integrated Security=True;Connect Timeout=30");

            return new BlogContext(optionsBuilder.Options, new NoMediator());
        }
    }
}

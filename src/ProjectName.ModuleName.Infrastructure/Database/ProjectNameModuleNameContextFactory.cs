using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProjectName.ModuleName.Infrastructure.Utils;

namespace ProjectName.ModuleName.Infrastructure.Database
{
    public class ProjectNameModuleNameContextFactory : IDesignTimeDbContextFactory<ProjectNameModuleNameContext>
    {
        public ProjectNameModuleNameContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectNameModuleNameContext>();

            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Database\\MSSQL11.MSSQLSERVER\\DATA\\ProjectName.ModuleName.mdf;Integrated Security=True;Connect Timeout=30");

            return new ProjectNameModuleNameContext(optionsBuilder.Options, new NoMediator());
        }
    }
}

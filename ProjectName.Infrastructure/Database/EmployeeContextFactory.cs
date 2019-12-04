using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjectName.Infrastructure.Database
{
    public class EmployeeContextFactory : IDesignTimeDbContextFactory<EmployeeContext>
    {
        public EmployeeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();

            optionsBuilder.UseSqlServer("Server=.;Database=HRProfile;user id=sa;password=123456");

            return new EmployeeContext(optionsBuilder.Options);
        }
    }
}

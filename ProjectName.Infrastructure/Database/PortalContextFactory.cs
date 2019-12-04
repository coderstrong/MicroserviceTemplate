using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjectName.Infrastructure.Database
{
    public class PortalContextFactory : IDesignTimeDbContextFactory<PortalContext>
    {
        public PortalContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PortalContext>();

            optionsBuilder.UseSqlServer("Server=.;Database=HRReport;user id=sa;password=123456");

            return new PortalContext(optionsBuilder.Options);
        }
    }
}
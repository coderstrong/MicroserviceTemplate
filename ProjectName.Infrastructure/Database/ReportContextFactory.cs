using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjectName.Infrastructure.Database
{
    public class ReportContextFactory : IDesignTimeDbContextFactory<ReportContext>
    {
        public ReportContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReportContext>();

            optionsBuilder.UseSqlServer("Server=.;Database=HRReport;user id=sa;password=123456");

            return new ReportContext(optionsBuilder.Options);
        }
    }
}
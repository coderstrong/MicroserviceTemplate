using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjectName.Infrastructure.Database
{
    public class ProfileContextFactory : IDesignTimeDbContextFactory<ProfileContext>
    {
        public ProfileContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProfileContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=HRProfile;user id=sa;password=123456");

            return new ProfileContext(optionsBuilder.Options);
        }
    }
}
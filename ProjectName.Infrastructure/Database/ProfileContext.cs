using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    public class ProfileContext : DbContext, IContext, IDisposable
    {
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Contract> Contracts { get; set; }

        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<T> Repository<T>() where T : class
        {
            return Set<T>();
        }

        public DbQuery<T> RepositoryQuery<T>() where T : class
        {
            return Query<T>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public ProfileContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProfileContext>();
            return new ProfileContext(builder.Options);
        }
    }
}
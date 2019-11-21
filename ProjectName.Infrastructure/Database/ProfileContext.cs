using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace ProjectName.Infrastructure.Database
{
    public class ProfileContext : DbContext, IContext, IDisposable, IDesignTimeDbContextFactory<ProfileContext>
    {
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Contract> Contracts { get; set; }

        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(x => x.Code).IsUnique();

            modelBuilder.Entity<Contract>()
                .HasIndex(x => x.Id);
        }

        public T CreateDbContext<T>(IOptions<ConnectionStringsSetting> connOptions) where T : class
        {
            return CreateDbContext(new string[] { connOptions.Value.CoreConnection }) as T;
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
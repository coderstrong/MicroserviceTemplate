using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    public class ReportContext : DbContext, IContext, IDisposable
    {
        public virtual DbSet<Report> Reports { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public ReportContext(DbContextOptions<ReportContext> options) : base(options)
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

        public ReportContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ReportContext>();
            return new ReportContext(builder.Options);
        }
    }
}
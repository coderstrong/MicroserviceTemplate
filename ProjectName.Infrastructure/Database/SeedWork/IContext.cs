using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    public interface IContext : IDisposable
    {
        DbSet<T> Repository<T>() where T : class;

        DbQuery<T> RepositoryQuery<T>() where T : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
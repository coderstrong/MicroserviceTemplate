using System;
using Microsoft.EntityFrameworkCore;

namespace ProjectName.Domain.SeedWork
{
    public interface IContext : IDisposable
    {
        Guid OperationId();

        DbSet<T> Repository<T>() where T : Entity;
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.AggregatesModel.EmployeeAggregate;
using ProjectName.Domain.SeedWork;
using ProjectName.Infrastructure.Utils;

namespace ProjectName.Infrastructure.Database
{
    public class EmployeeContext : DbContext, IContext, IUnitOfWork, IDisposable
    {
        public const string DefaultSchema = "Employee";

        private readonly IMediator _mediator;
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<EmployeeType> EmployeesTypes { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public Guid OperationId()
        {
            return this.ContextId.InstanceId;
        }

        public DbSet<T> Repository<T>() where T : Entity
        {
            return Set<T>();
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch Domain Events collection.
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions.
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers.
            await _mediator.DispatchDomainEventsAsync<EmployeeContext>(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers)
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.AggregatesModel.EmployeeAggregate;
using ProjectName.Domain.SeedWork;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public Employee Add(Employee order)
        {
            return _context.Employees.Add(order).Entity;
        }

        public async Task<Employee> GetAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                await _context.Entry(employee).Collection(i => i.Projects).LoadAsync();
                await _context.Entry(employee).Reference(i => i.EmployeeType).LoadAsync();
                await _context.Entry(employee).Reference(i => i.Address).LoadAsync();
            }
            return employee;
        }

        public void Update(Employee order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }
    }
}

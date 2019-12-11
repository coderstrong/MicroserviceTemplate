using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.EmployeeAggregate
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee Add(Employee order);

        void Update(Employee order);

        Task<Employee> GetAsync(int employeeId);
    }
}

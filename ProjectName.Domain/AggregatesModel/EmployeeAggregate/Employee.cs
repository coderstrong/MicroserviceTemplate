using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.EmployeeAggregate
{
    public class Employee : Entity, IAggregateRoot
    {
        [MaxLength(200)]
        public string Code { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(30)]
        public string MiddleName { get; set; }

        [MaxLength(90)]
        public string FullName { get; set; }

        public Address Address { get; set; }

        public EmployeeTypes EmployeeTypes { get; set; }
    }
}

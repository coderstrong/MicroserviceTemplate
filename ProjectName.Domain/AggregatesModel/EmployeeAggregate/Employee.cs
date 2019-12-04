using System.ComponentModel.DataAnnotations;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.EmployeeAggregate
{
    public class Employee : Entity
    {
        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string FullName { get; set; }

        public int? TitleId { get; set; }

        public string Title { get; set; }
    }
}

namespace ProjectName.Domain.AggregatesModel.EmployeeAggregate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ProjectName.Domain.Exceptions;
    using ProjectName.Domain.SeedWork;

    public class EmployeeTypes : Enumeration
    {
        public static EmployeeTypes Internship = new EmployeeTypes(1, nameof(Internship).ToLowerInvariant());
        public static EmployeeTypes Fresher = new EmployeeTypes(1, nameof(Fresher).ToLowerInvariant());
        public static EmployeeTypes Junior = new EmployeeTypes(2, nameof(Junior).ToLowerInvariant());
        public static EmployeeTypes Senior = new EmployeeTypes(3, nameof(Senior).ToLowerInvariant());

        public EmployeeTypes(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<EmployeeTypes> List() =>
            new[] { Internship, Fresher, Junior, Senior };

        public static EmployeeTypes FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new EmployeeDomainException($"Possible values for EmployeeTypes: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static EmployeeTypes From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new EmployeeDomainException($"Possible values for EmployeeTypes: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}

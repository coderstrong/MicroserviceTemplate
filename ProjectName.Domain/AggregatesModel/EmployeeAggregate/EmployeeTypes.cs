namespace ProjectName.Domain.AggregatesModel.EmployeeAggregate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ProjectName.Domain.Exceptions;
    using ProjectName.Domain.SeedWork;

    public class EmployeeType : Enumeration
    {
        public static EmployeeType Internship = new EmployeeType(1, nameof(Internship).ToLowerInvariant());
        public static EmployeeType Fresher = new EmployeeType(1, nameof(Fresher).ToLowerInvariant());
        public static EmployeeType Junior = new EmployeeType(2, nameof(Junior).ToLowerInvariant());
        public static EmployeeType Senior = new EmployeeType(3, nameof(Senior).ToLowerInvariant());

        public EmployeeType(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<EmployeeType> List() =>
            new[] { Internship, Fresher, Junior, Senior };

        public static EmployeeType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new EmployeeDomainException($"Possible values for EmployeeTypes: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static EmployeeType From(int id)
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

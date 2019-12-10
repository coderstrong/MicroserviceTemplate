using System;

namespace ProjectName.Domain.Exceptions
{
    public class EmployeeDomainException : Exception
    {
        public EmployeeDomainException()
        { }

        public EmployeeDomainException(string message)
            : base(message)
        { }

        public EmployeeDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

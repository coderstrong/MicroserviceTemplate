using System;

namespace Stu.AspNetCore.Mvc
{
    public class ValidateException : Exception
    {
        public ValidateException()
        { }

        public ValidateException(string message)
            : base(message)
        { }

        public ValidateException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

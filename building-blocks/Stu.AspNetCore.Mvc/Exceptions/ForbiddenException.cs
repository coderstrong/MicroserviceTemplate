using System;
using Newtonsoft.Json;

namespace Stu.AspNetCore.Mvc
{
    [Serializable]
    public class ForbiddenException : Exception
    {
        public ForbiddenException()
        { }

        public ForbiddenException(ResultData<bool> obj)
            : base(JsonConvert.SerializeObject(obj))
        { }

        public ForbiddenException(string message)
           : base(message)
        { }

        public ForbiddenException(ResultData<bool> obj, Exception innerException)
            : base(JsonConvert.SerializeObject(obj), innerException)
        { }
    }
}

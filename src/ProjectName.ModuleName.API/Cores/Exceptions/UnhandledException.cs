using System;
using Newtonsoft.Json;

namespace Stu.AspNetCore.Mvc
{
    [Serializable]
    public class UnhandledException : Exception
    {
        public UnhandledException()
        { }

        public UnhandledException(ResultData<bool> obj)
            : base(JsonConvert.SerializeObject(obj))
        { }

        public UnhandledException(string message)
            : base(message)
        { }

        public UnhandledException(ResultData<bool> obj, Exception innerException)
            : base(JsonConvert.SerializeObject(obj), innerException)
        { }
    }
}

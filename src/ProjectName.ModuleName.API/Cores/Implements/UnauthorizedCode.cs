using Stu.AspNetCore.Mvc.Interfaces;

namespace Stu.AspNetCore.Mvc.Implements
{
    /// <summary>
    ///
    /// Value ErrorCode is One
    /// </summary>
    public class UnauthorizedCode : IErrorCode
    {
        private int _code = 1;

        public int Code
        {
            get
            {
                return _code;
            }
            set
            {
                Code = _code;
                this.Messages = "Unauthorized";
            }
        }

        public string Messages { get; set; }
    }
}

using Stu.AspNetCore.Mvc.Interfaces;

namespace Stu.AspNetCore.Mvc.Implements
{
    /// <summary>
    ///
    /// Value ErrorCode is One
    /// </summary>
    public class ForbiddenCode : IErrorCode
    {
        private int _code = 401;

        public int Code
        {
            get
            {
                return _code;
            }
            set
            {
                Code = _code;
                this.Messages = "Access denie.";
            }
        }

        public string Messages { get; set; }
    }
}

using Stu.AspNetCore.Mvc.Interfaces;

namespace Stu.AspNetCore.Mvc.Implements
{
    /// <summary>
    /// Value ErrorCode is Zero
    /// </summary>
    public class SuccessCode : IErrorCode
    {
        private int _code = 0;

        public int Code
        {
            get
            {
                return _code;
            }
            set
            {
                Code = _code;
                this.Messages = "Success";
            }
        }

        public string Messages { get; set; }
    }
}

using Stu.AspNetCore.Mvc.Interfaces;

namespace Stu.AspNetCore.Mvc.Implements
{
    /// <summary>
    /// 
    /// Value ErrorCode is One
    /// </summary>
    public class InputInvalidCode : IErrorCode
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
                this.Messages = "Input invalid";
            }
        }
        public string Messages { get; set; }
    }
}

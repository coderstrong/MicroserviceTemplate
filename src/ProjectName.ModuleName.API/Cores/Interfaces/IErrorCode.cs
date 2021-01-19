namespace Stu.AspNetCore.Mvc.Interfaces
{
    public interface IErrorCode
    {
        int Code { get; set; }

        string Messages { get; set; }
    }
}

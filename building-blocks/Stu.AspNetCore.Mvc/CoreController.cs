using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Stu.AspNetCore.Mvc
{
    [Route("api/[version]/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResultData<object>), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ResultData<object>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ResultData<object>), (int)HttpStatusCode.NoContent)]
    [Authorize]
    public class CoreController : ControllerBase
    {
        protected long UserId
        {
            get
            {
                return long.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            }
        }

        protected string UserName
        {
            get
            {
                return User?.FindFirst(ClaimTypes.Name)?.Value;
            }
        }

        protected string FullName
        {
            get
            {
                return User?.FindFirst("Fullname")?.Value;
            }
        }

        protected long BussinessId
        {
            get
            {
                return long.Parse(User?.FindFirst("BUId")?.Value);
            }
        }

        protected string OfficerNumber
        {
            get
            {
                return User?.FindFirst("Persnbr")?.Value;
            }
        }

        public virtual IActionResult AcbResult<T>(ResultData<T> result)
        {
            if (result == null)
            {
                return new NotFoundObjectResult(result);
            }

            //if (result.Data == null && result.ErrorCode == ErrorCode)
            //{
            //    return NoContent();
            //}

            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(result);

                case HttpStatusCode.NoContent:
                    return NoContent();

                case HttpStatusCode.BadRequest:
                    return BadRequest(result);

                case HttpStatusCode.NotFound:
                    return NotFound(result);

                default:
                    return new AcbObjectResult((int)result.StatusCode, result);
            }
        }

        protected class AcbObjectResult : ObjectResult
        {
            public AcbObjectResult(int statusCode, object value)
                : base(value)
            {
                StatusCode = statusCode;
            }
        }
    }
}

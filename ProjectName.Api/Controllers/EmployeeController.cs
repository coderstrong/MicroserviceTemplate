using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectName.Api.Application.Behaviors;
using ProjectName.Api.Application.Commands;
using ProjectName.Domain.AggregatesModel.EmployeeAggregate;

namespace ProjectName.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMediator _mediator;
        public EmployeeController(ILogger<EmployeeController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromServices] IEmployeeRepository _employee, [FromRoute] int id)
        {
            return Ok(_employee.GetAsync(id));
        }

        [HttpPost]
        [ProfileUnitOfWork]
        [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task PostAsync([FromBody] CreateEmployeeCommand value)
        {
            await _mediator.Send(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

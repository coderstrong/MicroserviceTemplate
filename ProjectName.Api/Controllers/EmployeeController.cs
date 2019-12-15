using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectName.Api.Application.ActionAttribute;
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
        private readonly IEmployeeRepository _employee;
        public EmployeeController(ILogger<EmployeeController> logger,
            IMediator mediator,
            IEmployeeRepository employee)
        {
            _logger = logger;
            _mediator = mediator;
            _employee = employee;
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
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var test = await _employee.GetAsync(id);
            return Ok(test);
        }

        [HttpPost]
        [EmployeeUnitOfWork(useTransaction: true)]
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

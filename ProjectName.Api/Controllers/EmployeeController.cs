using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectName.Api.Application.Behaviors;
using ProjectName.Domain.AggregatesModel.EmployeeAggregate;
using ProjectName.Domain.SeedWork;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryGeneric<EmployeeContext, Employee> _employee;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IRepositoryGeneric<EmployeeContext, Employee> employee, ILogger<EmployeeController> logger)
        {
            _employee = employee;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employee.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _employee.GetOneAsync(id));
        }

        [HttpPost]
        [ProfileUnitOfWork]
        public void Post([FromBody] Employee value)
        {
            _employee.Insert(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            //value.Id = id;
            //_employee.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employee.Delete(id);
        }
    }
}

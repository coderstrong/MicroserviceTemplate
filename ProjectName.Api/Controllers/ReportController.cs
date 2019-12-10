using Microsoft.AspNetCore.Mvc;
using ProjectName.Domain.SeedWork;
using ProjectName.Infrastructure.Database;
using System.Threading.Tasks;

namespace ProjectName.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IRepositoryGeneric<PortalContext, User> _report;

        public ReportController(IRepositoryGeneric<PortalContext, User> report)
        {
            _report = report;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _report.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _report.GetOneAsync(id));
        }

        [HttpPost]
        public void Post([FromBody] User value)
        {
            _report.Insert(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            //value.Id = id;
            //_report.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _report.Delete(id);
        }
    }
}

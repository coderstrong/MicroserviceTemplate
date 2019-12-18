using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectName.Api.Application.ActionAttribute;
using ProjectName.Api.Application.Commands;
using ProjectName.Domain.AggregatesModel.BlogAggregate;
using ProjectName.Domain.AggregatesModel.PostAggregate;

namespace ProjectName.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IMediator _mediator;
        private readonly IPostRepository _post;

        public BlogController(ILogger<BlogController> logger,
            IMediator mediator,
            IPostRepository post)
        {
            _logger = logger;
            _mediator = mediator;
            _post = post ?? throw new System.ArgumentNullException(nameof(post));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Post), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Post), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var test = await _post.GetAsync(id);
            return Ok(test);
        }

        [HttpPost]
        [EmployeeUnitOfWork(useTransaction: true)]
        [ProducesResponseType(typeof(Post), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task PostAsync([FromBody] CreatePostCommand value)
        {
            await _mediator.Send(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Post value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

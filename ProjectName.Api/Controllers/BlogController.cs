using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectName.Api.Application.Commands;
using ProjectName.Api.Application.Queries;
using ProjectName.Api.ViewModel;
using ProjectName.Domain.AggregatesModel.PostAggregate;

namespace ProjectName.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IMediator _mediator;
        private readonly IPostQueries _postQueries;

        public BlogController(ILogger<BlogController> logger,
            IMediator mediator,
            IPostQueries postQueries)
        {
            _logger = logger;
            _postQueries = postQueries;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            var post = await _postQueries.GetAsync();

            return Ok(post);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var post = await _postQueries.GetAsync(id);

            return Ok(post);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PostViewModel), (int)HttpStatusCode.OK)]
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

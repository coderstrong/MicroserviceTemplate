using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectName.Api.Application.Commands;
using ProjectName.Api.Application.Queries;
using ProjectName.Api.ViewModel;
using ProjectName.Domain.Entities;

namespace ProjectName.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IMediator _mediator;
        private readonly IPostQueries _postQueries;

        public PostController(ILogger<PostController> logger,
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
            if (post != null)
                return Ok(post);
            else
                return NotFound();
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
        public async Task<ActionResult<PostViewModel>> PostAsync([FromBody] CreatePostCommand value)
        {
            return await _mediator.Send(value);
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

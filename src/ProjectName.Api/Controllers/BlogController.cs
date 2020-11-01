using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectName.Api.Application.Commands;
using ProjectName.Api.Application.Queries;
using ProjectName.Api.Model;

namespace ProjectName.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IMediator _mediator;
        private readonly IBlogQueries _blogQueries;

        public BlogController(ILogger<BlogController> logger,
            IMediator mediator,
            IBlogQueries blogQueries)
        {
            _logger = logger;
            _blogQueries = blogQueries;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BlogResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var blog = await _blogQueries.GetAsync(id);
            if (blog != null)
                return Ok(blog);
            else
                return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(BlogResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PostAsync([FromBody] CreateBlogCommand value)
        {
            var blog = await _mediator.Send(value);
            return Ok(blog);
        }

        [HttpPut]
        public async Task Put([FromBody] UpdateBlogCommand value)
        {
            await _mediator.Send(value);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _mediator.Send(new DeleteBlogCommand() { Id = id });
        }
    }
}

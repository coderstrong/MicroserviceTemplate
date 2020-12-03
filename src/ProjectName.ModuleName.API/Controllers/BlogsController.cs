using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectName.ModuleName.API.Application.Commands;
using ProjectName.ModuleName.API.Application.Queries;
using ProjectName.ModuleName.API.Model;

namespace ProjectName.ModuleName.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly ILogger<BlogsController> _logger;
        private readonly IMediator _mediator;
        private readonly IBlogQueries _blogQueries;

        public BlogsController(ILogger<BlogsController> logger,
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
        public async Task<IActionResult> Get([FromRoute] Guid id)
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


        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteBlogCommand() { Id = id });
        }

        [HttpPut("{id}")]
        public async Task Put([FromRoute] Guid id, [FromBody] UpdateBlogCommand value)
        {
            await _mediator.Send(value);
        }
    }
}

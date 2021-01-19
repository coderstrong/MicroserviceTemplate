using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectName.ModuleName.Application.Commands;
using ProjectName.ModuleName.Application.Queries;
using ProjectName.ModuleName.Application.Models;

namespace ProjectName.ModuleName.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly ILogger<BlogsController> _logger;
        private readonly IMediator _mediator;

        public BlogsController(ILogger<BlogsController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CommandResponseBase), (int)HttpStatusCode.OK)]
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

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(GetBlogQueryResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAsync([FromQuery] GetBlogQueryRequest request)
        {
            var blog = await _mediator.Send(request);
            return Ok(blog);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetBlogByIdQueryResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var blog = await _mediator.Send(new GetBlogByIdQueryRequest { Id = id });
            return Ok(blog);
        }

        [HttpPut("{id}")]
        public async Task Put([FromRoute] Guid id, [FromBody] UpdateBlogCommand value)
        {
            await _mediator.Send(value);
        }
    }
}

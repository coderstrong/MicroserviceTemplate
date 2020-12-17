using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectName.ModuleName.API.Application.Commands;
using ProjectName.ModuleName.API.Application.Queries;
using ProjectName.ModuleName.Domain.Entities;

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

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetBlogByIdResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var blog = await _mediator.Send(new GetBlogByIdRequest { Id = id });
            return Ok(blog);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(Blog), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PostAsync([FromBody] CreateBlogCommand value)
        {
            var blog = await _mediator.Send(value);
            return Ok(blog);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteBlogCommand() { Id = id });
        }

        [Route("{id}")]
        [HttpPut]
        public async Task Put([FromRoute] Guid id, [FromBody] UpdateBlogCommand value)
        {
            await _mediator.Send(value);
        }
    }
}

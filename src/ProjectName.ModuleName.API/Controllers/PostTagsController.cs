using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectName.ModuleName.API.Application.Commands;

namespace ProjectName.ModuleName.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostTagsController : ControllerBase
    {
        private readonly ILogger<PostTagsController> _logger;
        private readonly IMediator _mediator;
        private readonly IPostTagQueries _posttagQueries;

        public PostTagsController(ILogger<PostTagsController> logger,
            IMediator mediator,
            IPostTagQueries posttagQueries)
        {
            _logger = logger;
            _posttagQueries = posttagQueries;
            _mediator = mediator;
        }


        [HttpPost]
        [ProducesResponseType(typeof(PostTagResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PostAsync([FromBody] CreatePostTagCommand value)
        {
            var posttag = await _mediator.Send(value);
            return Ok(posttag);
        }

        [HttpPut("{id}")]
        public async Task Put([FromRoute] Guid id, [FromBody] UpdatePostTagCommand value)
        {
            await _mediator.Send(value);
        }
    }
}

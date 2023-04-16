using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PipiApp.Api.Dtos;
using PipiApp.Api.RequestHandlers;
using PipiApp.Api.RequestHandlers.CommentRequests;

namespace PipiApp.Api.Controllers
{
    [Route("/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CommentController : ApiControllerBase
    {
        public CommentController(IMediator mediatr) : base(mediatr)
        { }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<CommentDto>), 200)]
        public async Task<IActionResult> Get()
        {
            return await ExecuteRequest(new GetAllCommentsRequest());
        }

        [HttpGet("/v{v:apiVersion}/[controller]/FromToilet/{recordId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<CommentDto>), 200)]
        public async Task<IActionResult> Get(string recordId)
        {
            return await ExecuteRequest(new GetAllCommentsFromToiletRequest(recordId));
        }

        [HttpGet("/v{v:apiVersion}/[controller]/FromPerson/{publicId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<CommentDto>), 200)]
        public async Task<IActionResult> Get(Guid publicId)
        {
            return await ExecuteRequest(new GetAllCommentsFromPersonRequest(publicId));
        }

        [HttpGet("{commentId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<CommentDto>), 200)]
        public async Task<IActionResult> Get(ulong commentId)
        {
            return await ExecuteRequest(new GetCommentRequest(commentId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<CommentDto>), 201)]
        public async Task<IActionResult> Post([FromBody] CommentDto commentDto)
        {
            return await ExecuteRequest(new PostCommentRequest(commentDto));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<CommentDto>), 201)]
        public async Task<IActionResult> Put([FromBody] CommentDto commentDto)
        {
            return await ExecuteRequest(new PutCommentRequest(commentDto));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<CommentDto>), 201)]
        public async Task<IActionResult> Delete(ulong commentId)
        {
            return await ExecuteRequest(new DeleteCommentRequest(commentId));
        }
    }
}


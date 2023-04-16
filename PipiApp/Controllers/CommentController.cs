using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PipiApp.Api.Dtos;
using PipiApp.Api.RequestHandlers;
using PipiApp.Api.RequestHandlers.ToiletRequests;

namespace PipiApp.Api.Controllers
{
    [Route("/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ToiletController:ApiControllerBase
	{
		public ToiletController(IMediator mediatr):base(mediatr)
		{}
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<ToiletDto>), 200)]
        public async Task<IActionResult> Get()
        {
            return await ExecuteRequest(new GetAllToiletsRequest());
        }

        [HttpGet("{recordId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<ToiletDto>), 200)]
        public async Task<IActionResult> Get(string recordId)
        {
            return await ExecuteRequest(new GetToiletRequest(recordId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<ToiletDto>), 201)]
        public async Task<IActionResult> Post([FromBody] AddToiletDto toiletDto)
        {
            return await ExecuteRequest(new PostToiletRequest(toiletDto));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<ToiletDto>), 201)]
        public async Task<IActionResult> Put([FromBody] ToiletDto toiletDto)
        {
            return await ExecuteRequest(new PutToiletRequest(toiletDto));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<ToiletDto>), 201)]
        public async Task<IActionResult> Delete(string recordId)
        {
            return await ExecuteRequest(new DeleteToiletRequest(recordId));
        }
    }
}


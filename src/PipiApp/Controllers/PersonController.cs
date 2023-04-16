using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PipiApp.Api.Dtos;
using PipiApp.Api.RequestHandlers;
using PipiApp.Api.RequestHandlers.PersonRequests;
using PipiApp.Api.RequestHandlers.ToiletRequests;

namespace PipiApp.Api.Controllers
{
    [Route("/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class PersonController:ApiControllerBase
	{
		public PersonController(IMediator mediatr):base(mediatr)
		{}
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public async Task<IActionResult> Get()
        {
            return await ExecuteRequest(new GetAllPersonsRequest());
        }

        [HttpGet("{publicId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public async Task<IActionResult> Get(Guid publicId)
        {
            return await ExecuteRequest(new GetPersonRequest(publicId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 201)]
        public async Task<IActionResult> Post([FromBody] PersonDto personDto)
        {
            return await ExecuteRequest(new PostPersonRequest(personDto));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 201)]
        public async Task<IActionResult> Put([FromBody] PersonDto personDto)
        {
            return await ExecuteRequest(new PutPersonRequest(personDto));
        }

        [HttpPut("/v{v:apiVersion}/[controller]/LikeOrDislikeToilet/{publicId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 201)]
        public async Task<IActionResult> Put(Guid publicId, string recordId,bool like)
        {
            return await ExecuteRequest(new PutPersonLikeOrDislikeToiletRequest(publicId,recordId,like));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 201)]
        public async Task<IActionResult> Delete(Guid publicId)
        {
            return await ExecuteRequest(new DeletePersonRequest(publicId));
        }
    }
}


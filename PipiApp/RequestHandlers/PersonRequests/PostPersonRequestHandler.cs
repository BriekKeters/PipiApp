using System;
using PipiApp.Api.Dtos;
using PipiApp.Repositories.Base;
using PipiApp.Model;
using MediatR;

namespace PipiApp.Api.RequestHandlers.ToiletRequests
{
	public class PostPersonRequest : CommandBase<PersonDto>
	{
		public PersonDto Dto { get; set; }
		public PostPersonRequest(PersonDto dto)
		{
			Dto = dto;
		}
	}
	public class PostPersonRequestHandler:IRequestHandler<PostPersonRequest, PersonDto>
	{
        private readonly IRepository<Person> _personRepo;

        public PostPersonRequestHandler(IRepository<Person> toiletRepo)
		{
			_personRepo = toiletRepo;
		}

        public async Task<PersonDto> Handle(PostPersonRequest request, CancellationToken cancellationToken)
        {
			Person person = new Person(
				request.Dto.Firstname,
				request.Dto.LastName,
				request.Dto.Preference);
			_personRepo.Add(person);
			await _personRepo.SaveAsync();
			return new PersonDto();
        }
    }
}
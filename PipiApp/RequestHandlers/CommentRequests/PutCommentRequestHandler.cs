using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Model;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.PersonRequests
{
	public class PutPersonRequest : CommandBase<PersonDto>
	{
        public PersonDto Dto { get; private set; }

        public PutPersonRequest(PersonDto dto)
		{
			this.Dto = dto;
		}
    }
	public class PutPersonRequestHandler: IRequestHandler<PutPersonRequest, PersonDto>
	{
        private readonly IRepository<Person> _personRepo;

        public PutPersonRequestHandler(IRepository<Person> personRepo)
		{
			this._personRepo = personRepo;
		}

        public async Task<PersonDto> Handle(PutPersonRequest request, CancellationToken cancellationToken)
        {
			Person person = await _personRepo.GetAsync(person => person.PublicId==request.Dto.PublicId);
			person.Update(request.Dto.Firstname,request.Dto.LastName,request.Dto.Preference);
			_personRepo.Update(person);
			await _personRepo.SaveAsync();
			return person.ConvertToDto();
		}
    }
}


using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Model;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.PersonRequests
{
	public class GetPersonRequest : QueryBase<PersonDto>
	{
		public Guid PublicId { get; set; }
		public GetPersonRequest(Guid id)
		{
			this.PublicId = id;
		}
	}
	public class GetPersonRequestHandler:IRequestHandler<GetPersonRequest, PersonDto>
	{
        private readonly IRepository<Person> _personRepo;

        public GetPersonRequestHandler(IRepository<Person> toiletRepo)
		{
            _personRepo = toiletRepo;

        }

        public async Task<PersonDto> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
			Person person = await _personRepo.GetAsync(person => person.PublicId == request.PublicId
										&& person.IsDeleted == false);
			return person.ConvertToDto();
        }
    }
}


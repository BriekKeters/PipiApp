using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Model;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.ToiletRequests
{
	public class DeletePersonRequest : CommandBase<PersonDto>
	{
		public Guid PublicId { get; set; }
		public DeletePersonRequest(Guid id)
		{
			this.PublicId = id;
		}
	}
	public class DeletePersonRequestHandler:IRequestHandler<DeletePersonRequest, PersonDto>
	{
		private readonly IRepository<Person> _personRepo;
		public DeletePersonRequestHandler(IRepository<Person> personRepo)
		{
			this._personRepo = personRepo;
		}

        public async Task<PersonDto> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
        {
			Person person = await _personRepo.GetAsync(person => person.PublicId == request.PublicId);
			person.Delete();
			await _personRepo.SaveAsync();
			return person.ConvertToDto();
        }
    }
}


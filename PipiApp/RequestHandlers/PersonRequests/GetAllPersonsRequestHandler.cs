using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Model;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.ToiletRequests
{
    public class GetAllPersonsRequest : QueryBase<IEnumerable<PersonDto>>
    {
        public GetAllPersonsRequest()
        {        }
    }
    public class GetAllPersonsRequestHandler : IRequestHandler<GetAllPersonsRequest, IEnumerable<PersonDto>>
    {
        private readonly IRepository<Person> _personRepo;

        public GetAllPersonsRequestHandler(IRepository<Person> personRepo)
        {
            _personRepo = personRepo;

        }

        public async Task<IEnumerable<PersonDto>> Handle(GetAllPersonsRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Person> people = await _personRepo.GetAllAsync(person => person.IsDeleted == false);
            List<PersonDto> dtos = new List<PersonDto>();
            foreach (Person person in people)
            {
                dtos.Add(person.ConvertToDto());
            }
            return dtos;
        }
    }
}


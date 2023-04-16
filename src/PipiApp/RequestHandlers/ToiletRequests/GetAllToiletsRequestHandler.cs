using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Models;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.ToiletRequests
{
    public class GetAllToiletsRequest : QueryBase<IEnumerable<ToiletDto>>
    {
        public GetAllToiletsRequest()
        {        }
    }
    public class GetAllToiletsRequestHandler : IRequestHandler<GetAllToiletsRequest, IEnumerable<ToiletDto>>
    {
        private readonly IRepository<Toilet> _toiletRepo;

        public GetAllToiletsRequestHandler(IRepository<Toilet> toiletRepo)
        {
            _toiletRepo = toiletRepo;

        }

        public async Task<IEnumerable<ToiletDto>> Handle(GetAllToiletsRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Toilet> toilets = await _toiletRepo.GetAllAsync(toilet => toilet.IsDeleted == false);
            List<ToiletDto> dtos = new List<ToiletDto>();
            foreach (Toilet toilet in toilets)
            {
                dtos.Add(toilet.ConvertToDto());
            }
            return dtos;
        }
    }
}


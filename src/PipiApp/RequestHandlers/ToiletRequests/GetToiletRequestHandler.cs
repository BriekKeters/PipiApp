using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Models;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.ToiletRequests
{
	public class GetToiletRequest : QueryBase<ToiletDto>
	{
		public string RecordId { get; set; }
		public GetToiletRequest(string id)
		{
			this.RecordId = id;
		}
	}
	public class GetToiletRequestHandler:IRequestHandler<GetToiletRequest, ToiletDto>
	{
        private readonly IRepository<Toilet> _toiletRepo;

        public GetToiletRequestHandler(IRepository<Toilet> toiletRepo)
		{
            _toiletRepo = toiletRepo;

        }

        public async Task<ToiletDto> Handle(GetToiletRequest request, CancellationToken cancellationToken)
        {
			Toilet newToilet = await _toiletRepo.GetAsync(toilet => toilet.RecordId == request.RecordId
										&& toilet.IsDeleted == false);
			return newToilet.ConvertToDto();
        }
    }
}


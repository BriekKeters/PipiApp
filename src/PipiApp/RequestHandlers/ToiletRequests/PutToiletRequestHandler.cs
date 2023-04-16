using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Models;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.ToiletRequests
{
	public class PutToiletRequest : CommandBase<ToiletDto>
	{
        public ToiletDto Dto { get; private set; }

        public PutToiletRequest(ToiletDto dto)
		{
			this.Dto = dto;
		}
    }
	public class PutToiletRequestHandler: IRequestHandler<PutToiletRequest, ToiletDto>
	{
        private readonly IRepository<Toilet> _toiletRepo;

        public PutToiletRequestHandler(IRepository<Toilet> toiletRepo)
		{
			this._toiletRepo = toiletRepo;
		}

        public async Task<ToiletDto> Handle(PutToiletRequest request, CancellationToken cancellationToken)
        {
			Toilet toilet = await _toiletRepo.GetAsync(toilet => toilet.RecordId==request.Dto.RecordId);
			toilet.Update(request.Dto.Toilets,request.Dto.Urinals,request.Dto.Status,request.Dto.Description);
			_toiletRepo.Update(toilet);
			await _toiletRepo.SaveAsync();
			return toilet.ConvertToDto();
		}
    }
}


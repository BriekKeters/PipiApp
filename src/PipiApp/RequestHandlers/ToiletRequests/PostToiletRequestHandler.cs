using System;
using PipiApp.Api.Dtos;
using PipiApp.Repositories.Base;
using PipiApp.Models;
using MediatR;

namespace PipiApp.Api.RequestHandlers.ToiletRequests
{
	public class PostToiletRequest : CommandBase<AddToiletDto>
	{
		public AddToiletDto Dto { get; set; }
		public PostToiletRequest(AddToiletDto dto)
		{
			Dto = dto;
		}
	}
	public class PostToiletRequestHandler:IRequestHandler<PostToiletRequest, AddToiletDto>
	{
        private readonly IRepository<Toilet> _toiletRepo;

        public PostToiletRequestHandler(IRepository<Toilet> toiletRepo)
		{
			_toiletRepo = toiletRepo;
		}

        public async Task<AddToiletDto> Handle(PostToiletRequest request, CancellationToken cancellationToken)
        {
			Toilet toilet = new Toilet(
				request.Dto.RecordId,
				request.Dto.Toilets,
				request.Dto.Urinals!=null?request.Dto.Urinals:0,
				request.Dto.Status,
				request.Dto.Address,
				request.Dto.Description,
				request.Dto.Longitude,
				request.Dto.Latitude,
				request.Dto.OpenHours);
			_toiletRepo.Add(toilet);
			await _toiletRepo.SaveAsync();
			return toilet.ConvertToAddDto();
        }
    }
}
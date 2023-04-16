using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Models;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.ToiletRequests
{
	public class DeleteToiletRequest : CommandBase<ToiletDto>
	{
		public string RecordId { get; set; }
		public DeleteToiletRequest(string id)
		{
			this.RecordId = id;
		}
	}
	public class DeleteToiletRequestHandler:IRequestHandler<DeleteToiletRequest, ToiletDto>
	{
		private readonly IRepository<Toilet> _toiletRepo;
		public DeleteToiletRequestHandler(IRepository<Toilet> toiletRepo)
		{
			this._toiletRepo = toiletRepo;
		}

        public async Task<ToiletDto> Handle(DeleteToiletRequest request, CancellationToken cancellationToken)
        {
			Toilet toilet = await _toiletRepo.GetAsync(toilet => toilet.RecordId == request.RecordId);
			toilet.Delete();
			await _toiletRepo.SaveAsync();
			return toilet.ConvertToDto();
        }
    }
}


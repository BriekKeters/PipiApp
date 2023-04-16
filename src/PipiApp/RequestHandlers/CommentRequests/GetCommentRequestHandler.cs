using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Models;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.CommentRequests
{
	public class GetCommentRequest : QueryBase<CommentDto>
	{
		public ulong CommentId { get; set; }
		public GetCommentRequest(ulong id)
		{
			this.CommentId = id;
		}
	}
	public class GetPersonRequestHandler:IRequestHandler<GetCommentRequest, CommentDto>
	{
        private readonly IRepository<Comment> _commentRepo;

        public GetPersonRequestHandler(IRepository<Comment> commentRepo)
		{
            _commentRepo = commentRepo;

        }

        public async Task<CommentDto> Handle(GetCommentRequest request, CancellationToken cancellationToken)
        {
			Comment comment = await _commentRepo.GetAsync(comment => comment.CommentId == request.CommentId
										&& comment.IsDeleted == false);
			return comment.ConvertToDto();
        }
    }
}


using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Models;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.CommentRequests
{
	public class PutCommentRequest : CommandBase<CommentDto>
	{
        public CommentDto Dto { get; private set; }

        public PutCommentRequest(CommentDto dto)
		{
			this.Dto = dto;
		}
    }
	public class PutCommentRequestHandler: IRequestHandler<PutCommentRequest, CommentDto>
	{
        private readonly IRepository<Comment> _commentRepo;

        public PutCommentRequestHandler(IRepository<Comment> commentRepo)
		{
			this._commentRepo = commentRepo;
		}

        public async Task<CommentDto> Handle(PutCommentRequest request, CancellationToken cancellationToken)
        {
			Comment comment = await _commentRepo.GetAsync(comment => comment.CommentId==request.Dto.CommentId);
			comment.Update(request.Dto.CommenterId,request.Dto.CommentedToiletId);
			_commentRepo.Update(comment);
			await _commentRepo.SaveAsync();
			return comment.ConvertToDto();
		}
    }
}


using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Models;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.CommentRequests
{
	public class DeleteCommentRequest : CommandBase<CommentDto>
	{
		public ulong CommentId { get; set; }
		public DeleteCommentRequest(ulong id)
		{
			this.CommentId = id;
		}
	}
	public class DeleteCommentRequestHandler:IRequestHandler<DeleteCommentRequest, CommentDto>
	{
		private readonly IRepository<Comment> _commentRepo;
        private readonly IRepository<Toilet> _toiletRepo;
        private readonly IRepository<Person> _personRepo;
        public DeleteCommentRequestHandler(IRepository<Comment> commentRepo, IRepository<Toilet> toiletRepo, IRepository<Person> personRepo)
        {
            _commentRepo = commentRepo;
            _personRepo = personRepo;
            _toiletRepo = toiletRepo;
        }

        public async Task<CommentDto> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
			Comment comment = await _commentRepo.GetAsync(comment => comment.CommentId == request.CommentId);
			comment.Delete();
			await _commentRepo.SaveAsync();

            Person commenter = await _personRepo.GetAsync(commenter => commenter.PublicId == comment.CommenterId);
            commenter.RemoveComment(comment.CommentId.ToString());
            Toilet toilet = await _toiletRepo.GetAsync(toilet => toilet.RecordId == comment.CommentedToiletId);
            toilet.RemoveComment(comment.CommentId.ToString());

            await _toiletRepo.SaveAsync();
            await _personRepo.SaveAsync();

            return comment.ConvertToDto();
        }
    }
}


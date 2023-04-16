using System;
using PipiApp.Api.Dtos;
using PipiApp.Repositories.Base;
using MediatR;
using PipiApp.Models;

namespace PipiApp.Api.RequestHandlers.CommentRequests
{
	public class PostCommentRequest : CommandBase<CommentDto>
	{
		public CommentDto Dto { get; set; }
		public PostCommentRequest(CommentDto dto)
		{
			Dto = dto;
		}
	}
	public class PostCommentRequestHandler:IRequestHandler<PostCommentRequest, CommentDto>
	{
        private readonly IRepository<Comment> _commentRepo;
        private readonly IRepository<Toilet> _toiletRepo;
        private readonly IRepository<Person> _personRepo;


        public PostCommentRequestHandler(IRepository<Comment> commentRepo, IRepository<Toilet> toiletRepo, IRepository<Person> personRepo)
		{
			_commentRepo = commentRepo;
			_personRepo = personRepo;
			_toiletRepo = toiletRepo;
		}

        public async Task<CommentDto> Handle(PostCommentRequest request, CancellationToken cancellationToken)
        {
			Comment comment = new Comment(
				request.Dto.CommenterId,
				request.Dto.CommentedToiletId,
				request.Dto.Message,
				request.Dto.Liked);
			_commentRepo.Add(comment);
			await _commentRepo.SaveAsync();

			Person commenter = await _personRepo.GetAsync(commenter => commenter.PublicId == request.Dto.CommenterId);
			commenter.AddComment(comment.CommentId.ToString());
			if (request.Dto.Liked)
			{
				commenter.AddLikedToilet(request.Dto.CommentedToiletId);
			}
			else
			{
                commenter.AddDislikedToilet(request.Dto.CommentedToiletId);
            }
			Toilet toilet = await _toiletRepo.GetAsync(toilet => toilet.RecordId == request.Dto.CommentedToiletId);
			toilet.AddComment(comment.CommentId.ToString());

			_personRepo.Update(commenter);
			_toiletRepo.Update(toilet);
			await _toiletRepo.SaveAsync();
            await _personRepo.SaveAsync();

            return comment.ConvertToDto();
        }
    }
}
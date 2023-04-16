using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Models;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.CommentRequests
{
    public class GetAllCommentsFromPersonRequest : QueryBase<IEnumerable<CommentDto>>
    {
        public Guid PublicId { get; set; }
        public GetAllCommentsFromPersonRequest(Guid publicId)
        {
            this.PublicId = publicId;
        }
    }
    public class GetAllCommentsFromPersonRequestHandler : IRequestHandler<GetAllCommentsFromPersonRequest, IEnumerable<CommentDto>>
    {
        private readonly IRepository<Comment> _commentRepo;

        public GetAllCommentsFromPersonRequestHandler(IRepository<Comment> commentRepo)
        {
            _commentRepo = commentRepo;

        }

        public async Task<IEnumerable<CommentDto>> Handle(GetAllCommentsFromPersonRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Comment> comments = await _commentRepo.GetAllAsync(comment => comment.IsDeleted == false && comment.CommenterId == request.PublicId);
            List<CommentDto> dtos = new List<CommentDto>();
            foreach (Comment comment in comments)
            {
                dtos.Add(comment.ConvertToDto());
            }
            return dtos;
        }
    }
}


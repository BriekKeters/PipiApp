using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Models;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.CommentRequests
{
    public class GetAllCommentsRequest : QueryBase<IEnumerable<CommentDto>>
    {
        public GetAllCommentsRequest()
        {        }
    }
    public class GetAllCommentsRequestHandler : IRequestHandler<GetAllCommentsRequest, IEnumerable<CommentDto>>
    {
        private readonly IRepository<Comment> _commentRepo;

        public GetAllCommentsRequestHandler(IRepository<Comment> commentRepo)
        {
            _commentRepo = commentRepo;

        }

        public async Task<IEnumerable<CommentDto>> Handle(GetAllCommentsRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Comment> comments = await _commentRepo.GetAllAsync(comment => comment.IsDeleted == false);
            List<CommentDto> dtos = new List<CommentDto>();
            foreach (Comment comment in comments)
            {
                dtos.Add(comment.ConvertToDto());
            }
            return dtos;
        }
    }
}


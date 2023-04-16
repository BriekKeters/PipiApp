using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Models;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.CommentRequests
{
    public class GetAllCommentsFromToiletRequest : QueryBase<IEnumerable<CommentDto>>
    {
        public string RecordId { get; set; }
        public GetAllCommentsFromToiletRequest(string recordId)
        {
            this.RecordId = recordId;
        }
    }
    public class GetAllCommentsFromToiletRequestHandler : IRequestHandler<GetAllCommentsFromToiletRequest, IEnumerable<CommentDto>>
    {
        private readonly IRepository<Comment> _commentRepo;

        public GetAllCommentsFromToiletRequestHandler(IRepository<Comment> commentRepo)
        {
            _commentRepo = commentRepo;

        }

        public async Task<IEnumerable<CommentDto>> Handle(GetAllCommentsFromToiletRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Comment> comments = await _commentRepo.GetAllAsync(comment => comment.IsDeleted == false && comment.CommentedToiletId == request.RecordId);
            List<CommentDto> dtos = new List<CommentDto>();
            foreach (Comment comment in comments)
            {
                dtos.Add(comment.ConvertToDto());
            }
            return dtos;
        }
    }
}


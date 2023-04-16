using System;
using PipiApp.Models;

namespace PipiApp.Api.Dtos
{
    public class CommentDto
    {
        public ulong CommentId { get; set; }
        public Guid CommenterId { get; set; }
        public string? CommentedToiletId { get; set; }
        public string? Message { get; set; }
        public bool Liked { get; set; }
    }
    public static class CommentExtensions
    {
        public static CommentDto ConvertToDto(this Comment comment)
        {
            return new CommentDto()
            {
                CommentId = comment.CommentId,
                CommenterId = comment.CommenterId,
                CommentedToiletId = comment.CommentedToiletId,
                Liked = comment.Liked,
                Message = comment.Message
            };
        }
    }
}

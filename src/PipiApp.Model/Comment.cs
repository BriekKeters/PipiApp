using System;
using System.ComponentModel.DataAnnotations;

namespace PipiApp.Models
{
	public class Comment:BaseAuditableEntity
	{
        [Key]
        public ulong CommentId { get; private set; }
		public Guid CommenterId { get; set; }
		public string CommentedToiletId { get; set; }
        public string Message { get; set; }
        public bool Liked { get; set; }
        public bool IsDeleted { get; private set; }

        public Comment() {}
        public Comment(Guid commenter, string toilet, string message, bool liked)
        {
            this.CommentId = this.Id;
            this.CommenterId = commenter;
            this.CommentedToiletId = toilet;
            this.Message = message;
            this.Liked = liked;
        }

        public bool Equals(Comment? other)
        {
            return this.CommentId == other?.CommentId;
        }
        public void Delete()
        {
            this.IsDeleted = true;
        }
        public void Update(Guid commenter, string toilet)
        {
            this.CommenterId = commenter;
            this.CommentedToiletId = toilet;
        }
    }
}


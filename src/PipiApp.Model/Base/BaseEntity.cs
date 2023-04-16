using System;
namespace PipiApp.Models
{
	public abstract class BaseEntity
	{
		public ulong Id { get; private set; }
	}
	public class BaseAuditableEntity : BaseEntity
	{
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}


using System;
using System.Drawing;
using PipiApp.Models;

namespace PipiApp.Api.Dtos
{
	public class ToiletDto
	{
		public string? RecordId { get; set; }
		public string? Description { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
		public string? Address { get; set; }
		public int Toilets { get; set; }
		public int Urinals { get; set; }
		public string? Status { get; set; }
		public bool IsOpen { get; set; }
		public string? Comments { get; set; }
	}
	public static class ToiletExtensions
	{
		public static ToiletDto ConvertToDto(this Toilet toilet)
		{
			return new ToiletDto()
			{
				RecordId = toilet.RecordId,
				Description = toilet.Description,
				Longitude = toilet.Longitude,
				Latitude = toilet.Latitude,
				Address = toilet.Address,
				Toilets = toilet.Toilets,
				Urinals = toilet.Urinals,
				Status = toilet.Status,
				IsOpen = toilet.IsOpen,
				Comments = toilet.Comments
			};
		}
        public static AddToiletDto ConvertToAddDto(this Toilet toilet)
        {
            return new AddToiletDto()
            {
                RecordId = toilet.RecordId,
                Description = toilet.Description,
                Longitude = toilet.Longitude,
                Latitude = toilet.Latitude,
                Address = toilet.Address,
                Toilets = toilet.Toilets,
                Urinals = toilet.Urinals,
                Status = toilet.Status,
            };
        }
    }
}


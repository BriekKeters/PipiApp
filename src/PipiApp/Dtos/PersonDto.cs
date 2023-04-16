using System;
using PipiApp.Models;

namespace PipiApp.Api.Dtos
{
	public class PersonDto
	{
        public Guid PublicId { get; set; }
        public string? Firstname { get; set; }
        public string? LastName { get; set; }
        public ToiletPreference Preference { get; set; }
        public string? Comments { get; set; }
        public string? LikedToilets { get; set; }
        public string? DislikedToilets { get; set; }

    }
    public static class PersonExtensions
    {
        public static PersonDto ConvertToDto(this Person person)
        {
            return new PersonDto()
            {
                PublicId = person.PublicId,
                Firstname = person.Firstname,
                LastName = person.LastName,
                Preference = person.Preference,
                Comments = person.Comments,
                LikedToilets = person.LikedToilets,
                DislikedToilets = person.DislikedToilets
            };
        }
    }
}


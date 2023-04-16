using System;
using System.Drawing;

namespace PipiApp.Api.Dtos
{
	public class ToiletDto
	{
		public string RecordId { get; set; }
		public string Description { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
		public string Address { get; set; }
		public ushort Toilets { get; set; }
		public ushort Urinals { get; set; }
		public string Status { get; set; }
        public string OpenHours { get; set; }
    }
}


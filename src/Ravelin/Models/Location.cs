namespace Ravelin.Models
{
	public class Location
	{
		/// <summary>
		/// First line of the street address
		/// </summary>
		public string Street1 { get; set; }

		/// <summary>
		/// Second line of the street address
		/// </summary>
		public string Street2 { get; set; }

		/// <summary>
		/// The neighbourhood of the location
		/// </summary>
		public string Neighbourhood { get; set; }

		/// <summary>
		/// The zone of the location
		/// </summary>
		public string Zone { get; set; }

		/// <summary>
		/// The city/village/town of the location
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// The state/county of the location
		/// </summary>
		public string Region { get; set; }

		/// <summary>
		/// The ISO 3166 country code (2- or 3-letter)
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// The PO box number, if applicable
		/// </summary>
		public string PoBoxNumber { get; set; }

		/// <summary>
		/// The postal or zip code, if applicable
		/// </summary>
		public string PostalCode { get; set; }

		/// <summary>
		/// The latitude of the location
		/// </summary>
		public double? Latitude { get; set; }

		/// <summary>
		/// The longitude of the location
		/// </summary>
		public double? Longitude { get; set; }

		/// <summary>
		/// The geohash of the location, if applicable
		/// </summary>
		public string Geohash { get; set; }
		
		/// <summary>
		/// Any data about this customer that does not fit in one of the above fields
		/// </summary>
		public object Custom { get; set; }
	}
}

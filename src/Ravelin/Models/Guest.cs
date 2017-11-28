using Newtonsoft.Json;

namespace Ravelin.Models
{
	public class Guest
	{
		/// <summary>
		/// The named guest's given name.
		/// </summary>
		public string GivenName { get; set; }

		/// <summary>
		/// The named guest's family name.
		/// </summary>
		public string FamilyName { get; set; }

		/// <summary>
		/// The named guest's full name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Whether this guest is the individual who is purchasing the tickets.
		/// </summary>
		[JsonProperty(PropertyName = "Purchaser")]
		public bool IsPurchaser { get; set; }
	}
}

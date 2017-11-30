using System;
using Newtonsoft.Json;

namespace Ravelin.Models
{
	public class Customer
	{
		/// <summary>
		/// The unique identifier of this customer in your system
		/// </summary>
		public string CustomerId { get; set; }

		/// <summary>
		/// When the customer registered
		/// </summary>
		[JsonProperty(PropertyName = "RegistrationTime")]
		public DateTime? RegistrationTimeUtc { get; set; }

		/// <summary>
		/// The full name of the customer
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The given name of the customer - often the first name of a customer
		/// </summary>
		public string GivenName { get; set; }

		/// <summary>
		/// The family name of the customer - often the last name of a customer
		/// </summary>
		public string FamilyName { get; set; }

		/// <summary>
		/// The date of birth of the customer, formatted as YYYY-MM-DD
		/// </summary>
		public string DateOfBirth { get; set; }

		/// <summary>
		/// The gender of the customer
		/// </summary>
		public string Gender { get; set; }

		/// <summary>
		/// The primary email of the customer
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// The timestamp when the customer's email was verified
		/// </summary>
		[JsonProperty(PropertyName = "EmailVerifiedTime")]
		public DateTime? EmailVerifiedTimeUtc { get; set; }

		/// <summary>
		/// The username of the customer
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// The telephone number of the customer, including international code
		/// </summary>
		public string Telephone { get; set; }

		/// <summary>
		/// The timestamp when the customer's telephone was verified
		/// </summary>
		[JsonProperty(PropertyName = "TelephoneVerifiedTime")]
		public DateTime? TelephoneVerifiedTimeUtc { get; set; }

		/// <summary>
		/// The country this phone number is registered in
		/// </summary>
		public string TelephoneCountry { get; set; }

		/// <summary>
		/// Where this customer was last seen
		/// </summary>
		public Location Location { get; set; }

		/// <summary>
		/// The home country for this customer; ISO 3166 (2- or 3-letter)
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// The logical place in which this customer exists
		/// </summary>
		public string Market { get; set; }

		/// <summary>
		/// Used in conjunction with market and country to fully describe the market for this customer
		/// </summary>
		public string MarketCity { get; set; }

		/// <summary>
		/// Any data about this customer that does not fit in one of the above fields
		/// </summary>
		public object Custom { get; set; }
	}
}

using System;
using Newtonsoft.Json;

namespace Ravelin.Models
{
	public class SecureProtocol
	{
		/// <summary>
		/// Whether the customer was put through the 3DS payment flow
		/// </summary>
		public bool Attempted { get; set; }

		/// <summary>
		/// Whether the customer 3DS authentication was successful
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// The time in UTC indicating when the customer was redirected to the 3DS payment flow
		/// </summary>
		[JsonProperty(PropertyName = "StartTime")]
		public DateTime? StartTimeUtc { get; set; }

		/// <summary>
		/// The time in UTC indicating when the customer returned from the 3DS payment flow
		/// </summary>
		[JsonProperty(PropertyName = "EndTime")]
		public DateTime? EndTimeUtc { get; set; }

		/// <summary>
		/// Whether you believe the customer to have abandoned your checkout flow during 3DS authentication
		/// </summary>
		public bool TimedOut { get; set; }
	}
}

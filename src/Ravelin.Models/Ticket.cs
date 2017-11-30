using System;
using Newtonsoft.Json;

namespace Ravelin.Models
{
	public class Ticket
	{
		/// <summary>
		/// A unique identifier for this ticket.
		/// </summary>
		public string TicketId { get; set; }

		/// <summary>
		/// A short human-readable description of the type of ticket.
		/// </summary>
		public string TicketType { get; set; }

		/// <summary>
		/// Timestamp at which this ticket is valid from (unix time).
		/// </summary>
		[JsonProperty(PropertyName = "ValidFromTime")]
		public DateTime? ValidFromTimeUtc { get; set; }

		/// <summary>
		/// Timestamp at which this ticket is valid until (unix time).
		/// </summary>
		[JsonProperty(PropertyName = "ValidUntilTime")]
		public DateTime? ValidUntilTimeUtc { get; set; }

		/// <summary>
		/// Whether this ticket is refundable or not.
		/// </summary>
		public bool? Refundable { get; set; }
	}
}

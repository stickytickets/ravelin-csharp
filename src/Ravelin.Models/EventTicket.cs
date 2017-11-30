using Newtonsoft.Json;

namespace Ravelin.Models
{
	public class EventTicket
	{
		/// <summary>
		/// The ticket information for this event.
		/// </summary>
		public Ticket Ticket { get; set; }

		/// <summary>
		/// The event the ticket is granting access to. This could be a access to an event, an attraction, or any other activity the customer is purchasing a ticket to attend.
		/// </summary>
		[JsonProperty(PropertyName = "Event")]
		public EventInformation Event { get; set; }

		/// <summary>
		/// The individual who will be attending the event.
		/// </summary>
		public Guest Guest { get; set; }
	}
}

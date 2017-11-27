using System;
using Newtonsoft.Json;
using Ravelin.Models.Enums;

namespace Ravelin.Models
{
	public class EventInformation
	{
		/// <summary>
		/// A unique identifier for this event.
		/// </summary>
		public string EventId { get; set; }

		/// <summary>
		/// The name of the event.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// A short description of the event.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Timestamp at which event is scheduled to start (unix time). If the event is ongoing/recurring, you can use the ticket time here.
		/// </summary>
		[JsonProperty(PropertyName = "StartTime")]
		public DateTime? StartTimeUtc { get; set; }

		/// <summary>
		/// Timestamp at which event is scheduled to end (unix time). If the event is ongoing/recurring, you can use the ticket time here.
		/// </summary>
		[JsonProperty(PropertyName = "EndTime")]
		public DateTime? EndTimeUtc { get; set; }

		/// <summary>
		/// The category that best described the type of event. One of: sport music attraction conference convention party festival
		/// </summary>
		public EventCategory Category { get; set; }

		/// <summary>
		/// The location the event will take place.
		/// </summary>
		public Venue Venue { get; set; }
	}
}
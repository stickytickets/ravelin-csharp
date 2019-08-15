using System;

namespace Ravelin.Models.Events
{
	public interface IEvent
	{
		DateTime? Timestamp { get; set; }

		Device Device { get; set; }

		string DeviceId { get; set; }
	}

	public class Event : IEvent
	{
		/// <summary>
		/// The timestamp of when the event occured, if not defined, will be set to the current time
		/// </summary>
		public DateTime? Timestamp { get; set; }

		/// <summary>
		/// Information about the device used by this customer (optional)
		/// </summary>
		public Device Device { get; set; }

		/// <summary>
		/// If the device used by the user was already sent in a previous event, its deviceId can be sent here instead of a full device object.
		/// Optional, and mutually exclusive with the device field.
		/// </summary>
		public string DeviceId { get; set; }
	}
}

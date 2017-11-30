namespace Ravelin.Models.Events
{
	public class OrderEvent : Event
	{
		/// <summary>
		/// Customer performing this order
		/// </summary>
		public string CustomerId { get; set; }

		/// <summary>
		/// A session ID, if the customer has not logged in yet
		/// </summary>
		public string TempCustomerId { get; set; }

		/// <summary>
		/// The order to update
		/// </summary>
		public Order Order { get; set; }
	}
}

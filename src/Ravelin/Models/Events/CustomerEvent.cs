namespace Ravelin.Models.Events
{
	public class CustomerEvent : Event
	{
		/// <summary>
		/// The customer to create or update
		/// </summary>
		public Customer Customer { get; set; }
	}
}

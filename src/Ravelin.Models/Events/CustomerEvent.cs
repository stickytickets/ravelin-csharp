namespace Ravelin.Models.Events
{
	public class CustomerEvent : Event
	{
		public CustomerEvent(Customer customer)
		{
			this.Customer = customer;
		}

		public CustomerEvent()
		{
			
		}
		/// <summary>
		/// The customer to create or update
		/// </summary>
		public Customer Customer { get; set; }
	}
}

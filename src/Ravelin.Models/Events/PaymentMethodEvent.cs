namespace Ravelin.Models.Events
{
	public interface IPaymentMethodEvent
	{
		PaymentMethod PaymentMethod { get; set; }
	}

	public class PaymentMethodEvent : Event, IPaymentMethodEvent
	{
		/// <summary>
		/// Customer this payment method belongs to
		/// </summary>
		public string CustomerId { get; set; }

		/// <summary>
		/// A session ID, if the customer has not logged in yet
		/// </summary>
		public string TempCustomerId { get; set; }

		/// <summary>
		/// The payment method to create/update
		/// </summary>
		public PaymentMethod PaymentMethod { get; set; }
	}
}

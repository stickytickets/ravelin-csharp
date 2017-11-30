namespace Ravelin.Models.Events
{
	public class CheckoutEvent : Event, IPaymentMethodEvent
	{
		/// <summary>
		/// The customer performing the checkout.
		/// If the information about this customer was already sent to Ravelin previously, only filling the CustomerId field of this object will suffice.
		/// </summary>
		public Customer Customer { get; set; }

		/// <summary>
		/// If this is not a new customer performing the check-out, and the customer is already known with Ravelin, set the CustomerId field instead of the Customer object (mutually exclusive)
		/// </summary>
		public string CustomerId { get; set; }

		/// <summary>
		/// The order under checkout
		/// </summary>
		public Order Order { get; set; }

		/// <summary>
		/// Payment method used for this checkout
		/// </summary>
		public PaymentMethod PaymentMethod { get; set; }

		/// <summary>
		/// If a payment method was already added for this user in a previous event, it can be referenced here.
		/// Mutually exclusive with the PaymentMethod field.
		/// </summary>
		public string PaymentMethodId { get; set; }

		/// <summary>
		/// (Attempted) transaction associated with this checkout
		/// </summary>
		public Transaction Transaction { get; set; }
	}
}

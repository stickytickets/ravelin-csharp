namespace Ravelin.Models.Events
{
	public class ChargebackEvent : Event
	{
		public ChargebackEvent(Chargeback chargeback)
		{
			Chargeback = chargeback;
		}

		/// <summary>
		/// The chargeback information
		/// </summary>
		public Chargeback Chargeback { get; set; }

		/// <summary>
		/// The ID of the order the chargeback originated from. 
		/// When provided instead of gatewayReference and transactionId, Ravelin will set the gatewayReference and transactionId to that of the first successful transaction of the order.
		/// </summary>
		public string OrderId { get; set; }
	}
}

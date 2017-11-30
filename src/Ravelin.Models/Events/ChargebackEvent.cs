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
	}
}

namespace Ravelin.Models.Events
{
	public class PreTransactionEvent : TransactionEventBase
	{
		/// <summary>
		/// The transaction that is about to be committed
		/// </summary>
		public PreTransaction Transaction { get; set; }
	}
}

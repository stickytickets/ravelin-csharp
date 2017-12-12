namespace Ravelin.Models.Events
{
	public class TransactionEvent : TransactionEventBase
	{
		/// <summary>
		/// The transaction which was committed to the PSP, including the response from the PSP
		/// </summary>
		public Transaction Transaction { get; set; }
	}
}

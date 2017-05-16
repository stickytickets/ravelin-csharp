using System;
using Newtonsoft.Json;
using Ravelin.Models.Enums;

namespace Ravelin.Models
{
	public class PreTransaction
	{
		/// <summary>
		/// A unique identifier for the transaction
		/// </summary>
		public string TransactionId { get; set; }

		/// <summary>
		/// Information about any 3D Secure flow the customer was put through
		/// </summary>
		[JsonProperty(PropertyName = "3ds")]
		public SecureProtocol SecureProtocol { get; set; }

		/// <summary>
		/// The email that the customer wants to be notified about transactions on
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// The ISO 4217 currency code (required)
		/// </summary>
		public string Currency { get; set; }

		/// <summary>
		/// The debit amount (money coming from the payment method, i.e. normal charge) of the transaction in the lowest denomination of the currency (required)
		/// </summary>
		public int Debit { get; set; }

		/// <summary>
		/// The credit amount (money going to the payment method, i.e. a refund) of the transaction in the lowest denomination of the currency (required)
		/// </summary>
		public int Credit { get; set; }

		/// <summary>
		/// The name of the payment gateway (required)
		/// </summary>
		public string Gateway { get; set; }

		/// <summary>
		/// The type of transaction
		/// </summary>
		public TransactionType Type { get; set; }

		/// <summary>
		/// When this transaction is authed, captured, or otherwise actioned (depending on the type)
		/// </summary>
		[JsonProperty(PropertyName = "Time")]
		public DateTime? TimeUtc { get; set; }

		/// <summary>
		/// Any data about this customer that does not fit in one of the above fields
		/// </summary>
		public object Custom { get; set; }
	}
}

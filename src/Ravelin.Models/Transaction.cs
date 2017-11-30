namespace Ravelin.Models
{
	public class Transaction : PreTransaction
	{
		/// <summary>
		/// Whether the transaction successfully completed with no error (required)
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// A code returned from the payment gateway after an attempt to charge, if applicable
		/// </summary>
		public string AuthCode { get; set; }

		/// <summary>
		/// The decline code from the payment gateway, if applicable
		/// </summary>
		public string DeclineCode { get; set; }

		/// <summary>
		/// Transaction Reference provided by the payment gateway (required)
		/// </summary>
		public string GatewayReference { get; set; }

		/// <summary>
		/// The result code from address verification for both street and postal code verification
		/// </summary>
		public AvsResult AvsResultCode { get; set; }

		/// <summary>
		/// The result code from a CVV verification (M, N, ...)
		/// </summary>
		public string CvvResultCode { get; set; }
	}
}

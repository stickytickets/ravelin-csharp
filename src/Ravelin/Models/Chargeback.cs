using System;
using Newtonsoft.Json;
using Ravelin.Models.Enums;

namespace Ravelin.Models
{
	public class Chargeback
	{
		/// <summary>
		/// A unique identifier for this chargeback. Can be the same as the PSP ID. (required)
		/// </summary>
		public string ChargebackId { get; set; }

		/// <summary>
		/// The name of the payment gateway (required)
		/// </summary>
		public string Gateway { get; set; }

		/// <summary>
		/// Transaction Reference of the original transaction, not the chargeback. Provided by the payment gateway. (required)
		/// </summary>
		public string GatewayReference { get; set; }

		/// <summary>
		/// The reason code from the chargeback
		/// </summary>
		public string Reason { get; set; }

		/// <summary>
		/// Status of the dispute
		/// </summary>
		public ChargebackStatus Status { get; set; }

		/// <summary>
		/// The amount that is being disputed, in the lowest denomination of the currency
		/// </summary>
		public int Amount { get; set; }

		/// <summary>
		/// The ISO 4217 currency code
		/// </summary>
		public string Currency { get; set; }

		/// <summary>
		/// The time the dispute was opened
		/// </summary>
		[JsonProperty(PropertyName = "DisputeTime")]
		public DateTime? DisputeTimeUtc { get; set; }

		/// <summary>
		/// Whether liability for this chargeback has been shifted to a third-party.
		/// </summary>
		public bool LiabilityShifted { get; set; }

		/// <summary>
		/// Whether this chargeback was claimed for reasons other than fraud.
		/// </summary>
		public bool NonFraud { get; set; }

		/// <summary>
		/// Any data about this chargeback that does not fit in one of the above fields
		/// </summary>
		public object Custom { get; set; }
	}
}

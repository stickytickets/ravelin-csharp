using System.Runtime.Serialization;

namespace Ravelin.Models.Enums
{
	public enum ChargebackStatus
	{
		/// <summary>
		/// The chargeback, retrieval, or pre-arb has been issued and no action has been taken yet
		/// </summary>
		[EnumMember(Value = "OPEN")]
		Open,

		/// <summary>
		/// You have opted out of providing evidence for the chargeback or pre-arb
		/// </summary>
		[EnumMember(Value = "ACCEPTED")]
		Accepted,

		/// <summary>
		/// You have submitted evidence against the claim and are waiting for the decision from the bank
		/// </summary>
		[EnumMember(Value = "DISPUTED")]
		Disputed,

		/// <summary>
		/// The bank has ruled in your favor, and the funds should return to your bank account within 2-3 business days
		/// </summary>
		[EnumMember(Value = "WON")]
		Won,

		/// <summary>
		/// The bank has not ruled in your favor, and the funds will remain with the cardholder
		/// </summary>
		[EnumMember(Value = "LOST")]
		Lost,

		/// <summary>
		/// The reply-by date to submit evidence has passed and you have forfeited your right to dispute the case
		/// </summary>
		[EnumMember(Value = "EXPIRED")]
		Expired
	}
}

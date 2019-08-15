using System.Runtime.Serialization;

namespace Ravelin.Models.Enums
{
	public enum OrderStageReason
	{
		//Failed Reasons
		[EnumMember(Value = "payment_declined")]
		FailedPaymentDeclined,

		[EnumMember(Value = "seller_rejected")]
		FailedSellerRejected,

		[EnumMember(Value = "system_error")]
		FailedSystemError,

		//Cancelled Reasons
		[EnumMember(Value = "buyer")]
		CancelledBuyer,

		[EnumMember(Value = "seller")]
		CancelledSeller,

		[EnumMember(Value = "merchant")]
		CancelledMerchant,

		[EnumMember(Value = "ravelin")]
		CancelledRavelin,

		//Refunded Reason
		[EnumMember(Value = "returned")]
		RefundedReturned,

		[EnumMember(Value = "complaint")]
		RefundedComplaint
	}
}

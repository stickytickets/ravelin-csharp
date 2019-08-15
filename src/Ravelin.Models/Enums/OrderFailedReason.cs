using System.Runtime.Serialization;

namespace Ravelin.Models.Enums
{
	public enum OrderFailedReason
	{
		[EnumMember(Value = "payment_declined")]
		PaymentDeclined,

		[EnumMember(Value = "seller_rejected")]
		SellerRejected,

		[EnumMember(Value = "system_error")]
		SystemError
	}
}

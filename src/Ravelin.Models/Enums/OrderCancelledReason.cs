using System.Runtime.Serialization;

namespace Ravelin.Models.Enums
{
	public enum OrderCancelledReason
	{
		[EnumMember(Value = "buyer")]
		Buyer,

		[EnumMember(Value = "seller")]
		Seller,

		[EnumMember(Value = "merchant")]
		Merchant,

		[EnumMember(Value = "ravelin")]
		Ravelin
	}
}

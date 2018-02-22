using System.Runtime.Serialization;

namespace Ravelin.Models.Enums
{
	public enum PaymentMethodType
	{
		[EnumMember(Value = "card")]
		Card,

		[EnumMember(Value = "voucher")]
		Voucher,

		[EnumMember(Value = "bitcoin")]
		Bitcoin,

		[EnumMember(Value = "cash")]
		Cash,

		[EnumMember(Value = "transfer")]
		Transfer,

		[EnumMember(Value = "paypal")]
		Paypal,

		[EnumMember(Value = "credit")]
		Credit
	}
}

using System.Runtime.Serialization;

namespace Ravelin.Models.Enums
{
	public enum CardType
	{
		[EnumMember(Value = "mastercard")]
		Mastercard,

		[EnumMember(Value = "visa")]
		Visa,

		[EnumMember(Value = "amex")]
		Amex
	}
}

using System.Runtime.Serialization;

namespace Ravelin.Models.Enums
{
	public enum Label
	{
		[EnumMember(Value = "UNREVIEWED")]
		Unreviewed,

		[EnumMember(Value = "GENUINE")]
		Genuine,

		[EnumMember(Value = "FRAUDSTER")]
		Fraudster
	}
}

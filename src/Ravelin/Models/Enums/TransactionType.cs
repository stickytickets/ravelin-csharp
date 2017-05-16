using System.Runtime.Serialization;

namespace Ravelin.Models.Enums
{
	public enum TransactionType
	{
		[EnumMember(Value = "auth")]
		Auth,

		[EnumMember(Value = "capture")]
		Capture,

		[EnumMember(Value = "auth_capture")]
		AuthCapture,

		[EnumMember(Value = "void")]
		Void,

		[EnumMember(Value = "refund")]
		Refund
	}
}

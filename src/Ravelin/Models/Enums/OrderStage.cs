using System.Runtime.Serialization;

namespace Ravelin.Models.Enums
{
	public enum OrderStage
	{
		[EnumMember(Value = "pending")]
		Pending,

		[EnumMember(Value = "accepted")]
		Accepted,

		[EnumMember(Value = "failed")]
		Failed,

		[EnumMember(Value = "cancelled")]
		Cancelled,

		[EnumMember(Value = "fulfilled")]
		Fulfilled,

		[EnumMember(Value = "refunded")]
		Refunded
	}
}

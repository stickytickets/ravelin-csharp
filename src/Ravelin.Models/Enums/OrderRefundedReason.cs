using System.Runtime.Serialization;

namespace Ravelin.Models.Enums
{
	public enum OrderRefundedReason
	{
		[EnumMember(Value = "returned")]
		Returned,

		[EnumMember(Value = "complaint")]
		Complaint
	}
}

using System.Runtime.Serialization;

namespace Ravelin.Models.Enums
{
	public enum ScoreAction
	{
		[EnumMember(Value = "ALLOW")]
		Allow,

		[EnumMember(Value = "REVIEW")]
		Review,

		[EnumMember(Value = "PREVENT")]
		Prevent
	}
}

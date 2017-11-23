using System.ComponentModel;

namespace Ravelin.Models.Enums
{
	public enum ScoreAction
	{
		[Description("ALLOW")]
		Allow,

		[Description("REVIEW")]
		Review,

		[Description("PREVENT")]
		Prevent
	}
}

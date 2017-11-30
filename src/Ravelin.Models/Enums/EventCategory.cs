using System.Runtime.Serialization;

namespace Ravelin.Models.Enums
{
	public enum EventCategory
	{
		[EnumMember(Value = "other")]
		Other,

		[EnumMember(Value = "adventure")]
		Adventure,

		[EnumMember(Value = "attraction")]
		Attraction,

		[EnumMember(Value = "business")]
		Business,

		[EnumMember(Value = "family")]
		Family,

		[EnumMember(Value = "culinary")]
		Culinary,

		[EnumMember(Value = "health")]
		Health,

		[EnumMember(Value = "live show")]
		LiveShow,

		[EnumMember(Value = "music")]
		Music,

		[EnumMember(Value = "social")]
		Social,

		[EnumMember(Value = "sport")]
		Sport,

		[EnumMember(Value = "conference")]
		Conference,

		[EnumMember(Value = "convention")]
		Convention,

		[EnumMember(Value = "party")]
		Party,

		[EnumMember(Value = "festival")]
		Festival
	}
}

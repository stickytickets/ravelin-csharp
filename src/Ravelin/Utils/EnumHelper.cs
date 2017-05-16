using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Ravelin.Utils
{
	public static class EnumHelper
	{
		public static string GetEnumMemberValue(this Enum enumVal)
		{
			var member = enumVal.GetType().GetMember(enumVal.ToString());
			var attr = member.FirstOrDefault()?.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();

			return attr?.Value;
		}

		public static string GetEndpoint(this Enum enumVal)
		{
			var member = enumVal.GetType().GetMember(enumVal.ToString());
			var attr = member.FirstOrDefault()?.GetCustomAttributes(false).OfType<EndpointAttribute>().FirstOrDefault();
			return attr?.Endpoint;
		}
	}
}

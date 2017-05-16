using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Ravelin.Models.Events;

namespace Ravelin.Serialization
{
	public static class SerializeExtensions
	{
		static SerializeExtensions()
		{
			JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore,
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Converters = new List<JsonConverter> { new StringEnumConverter(true), new UnixDateTimeConverter() }
			};
		}

		/// <summary>
		/// Creates the JSON object required to make a request to Ravelin
		/// </summary>
		/// <returns>The JSON object required to make a request to Ravelin</returns>
		public static string Serialize(this IEvent item)
		{
			item.Timestamp = item.Timestamp ?? DateTime.UtcNow;

			return JsonConvert.SerializeObject(item);
		}
	}
}

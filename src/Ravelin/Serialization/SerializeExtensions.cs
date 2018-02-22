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
		private static JsonSerializerSettings serializerSettings;

		//followed similar approach discussed here: https://github.com/HangfireIO/Hangfire/issues/286
		//and sample code: https://github.com/HangfireIO/Hangfire/blob/master/src/Hangfire.Core/Common/JobHelper.cs
		public static void SetSerializerSettings(JsonSerializerSettings setting)
		{
			serializerSettings = setting;
		}

		static SerializeExtensions()
		{
			//set default for Ravelin serialization only 
			serializerSettings = new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore,
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Converters = new List<JsonConverter> { new StringEnumConverter(), new UnixDateTimeConverter() }
			};
		}

		/// <summary>
		/// Creates the JSON object required to make a request to Ravelin
		/// </summary>
		/// <returns>The JSON object required to make a request to Ravelin</returns>
		public static string Serialize(this IEvent item)
		{
			item.Timestamp = item.Timestamp ?? DateTime.UtcNow;

			return JsonConvert.SerializeObject(item, serializerSettings);
		}

		public static string Serialize(this object data)
		{
			return JsonConvert.SerializeObject(data, serializerSettings);
		}
	}
}

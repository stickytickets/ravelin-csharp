using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ravelin.Serialization
{
	public class UnixDateTimeConverter : DateTimeConverterBase
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteRawValue(ToUnixTimeStamp((DateTime)value).ToString(CultureInfo.InvariantCulture));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return reader.Value == null ? new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) : UnixTimeStampToDateTime((long)reader.Value);
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
		}

		public static DateTime UnixTimeStampToDateTime(long unixTimestamp)
		{
			// Unix timestamp is seconds past epoch
			var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(unixTimestamp);
			return dtDateTime;
		}

		public static long ToUnixTimeStamp(DateTime date)
		{
			// Unix timestamp is seconds past epoch
			return (long)date.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds/1000;
		}
	}
}

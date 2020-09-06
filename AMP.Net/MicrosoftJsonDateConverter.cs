using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AMP.Net
{
    public class MicrosoftJsonDateConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = reader.GetString();
            var ms = long.Parse(dateString.Substring(6).TrimEnd(')', '/'));
            return DateTime.UnixEpoch.AddMilliseconds(ms).ToLocalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"/Date({(long)(value - DateTime.UnixEpoch).TotalMilliseconds})/");
        }
    }
}

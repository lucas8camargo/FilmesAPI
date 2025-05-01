using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class JsonDateTimeNoSecondsConverter : JsonConverter<DateTime>
{
    private readonly string format = "dd/MM/yyyy HH:mm";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateTime.ParseExact(reader.GetString(), format, null);

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(format));
}

using System.Text.Json;
using System.Text.Json.Serialization;

namespace func_shops.Helpers;

public class NumericStringConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetInt64().ToString();
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            return reader.GetString();
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}
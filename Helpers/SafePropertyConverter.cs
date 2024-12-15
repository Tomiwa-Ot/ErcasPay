using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ErcasPay.Helpers
{
    public class SafePropertyConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                // Deserialize as an object
                return serializer.Deserialize<T>(reader);
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                // Handle array (return null or handle elements if needed)
                JArray array = JArray.Load(reader);
                return null; // Or handle as needed, e.g., throw an exception or process the array
            }
            throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Serialization is not implemented");
        }
    }
}
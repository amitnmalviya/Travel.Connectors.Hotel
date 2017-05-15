using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Travel.Connectors.Hotel.Common;
using Travel.Connectors.Hotel.Common.ErrorHandling;

namespace Travel.Connectors.Hotel
{
    public class InfoTranslator : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var actualObject = value as Info;
            if (actualObject == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteStartObject();
            writer.WriteField("code", actualObject.Code);
            writer.WriteField("message", actualObject.Message);
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var json = JToken.ReadFrom(reader) as JObject;
            if (json == null)
                return null;

            var code = json.ReadAsString("code");

            var message = json.ReadAsString("message");

            var actualObject = new Info(code, message);
            return actualObject;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Info) == objectType;
        }
    }
}
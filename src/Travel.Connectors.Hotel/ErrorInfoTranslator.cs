using Newtonsoft.Json;
using System;
using Travel.Connectors.Hotel.Common.ErrorHandling;
using Newtonsoft.Json.Linq;
using Travel.Connectors.Hotel.Common;

namespace Travel.Connectors.Hotel
{
    public class ErrorInfoTranslator : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var actualObject = value as ErrorInfo;
            if (actualObject == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteStartObject();
            writer.WriteField("code", actualObject.Code);
            writer.WriteField("message", actualObject.Message);
            writer.WriteField("info", actualObject.Info, serializer);
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var json = JToken.ReadFrom(reader) as JObject;
            if (json == null)
                return null;

            var code = json.ReadAsString("code");

            var message = json.ReadAsString("message");

            var infos = json.ReadAsArray<Info>("info", serializer);

            var actualObject = new ErrorInfo(code, message, System.Net.HttpStatusCode.InternalServerError);
            actualObject.Info.AddRange(infos);

            return actualObject;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(ErrorInfo) == objectType;
        }
    }
}
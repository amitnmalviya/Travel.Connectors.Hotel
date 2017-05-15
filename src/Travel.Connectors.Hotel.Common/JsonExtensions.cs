using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Travel.Connectors.Hotel.Common.ErrorHandling;

namespace Travel.Connectors.Hotel.Common
{
    public static class JsonExtensions
    {
        public static JsonWriter WriteField(this JsonWriter writer, string property, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                writer.WritePropertyName(property);
                writer.WriteValue(value);
            }
            return writer;
        }

        public static JsonWriter WriteField(this JsonWriter writer, string property, int value)
        {
            writer.WritePropertyName(property);
            writer.WriteValue(value);
            return writer;
        }

        public static JsonWriter WriteField(this JsonWriter writer, string property, int? value)
        {
            if (value.HasValue)
            {
                writer.WritePropertyName(property);
                writer.WriteValue(value);
            }
            return writer;
        }

        public static JsonWriter WriteField(this JsonWriter writer, string property, decimal value)
        {
            writer.WritePropertyName(property);
            writer.WriteValue(value);
            return writer;
        }

        public static JsonWriter WriteField(this JsonWriter writer, string property, decimal? value)
        {
            if (value.HasValue)
            {
                writer.WritePropertyName(property);
                writer.WriteValue(value);
            }
            return writer;
        }

        public static JsonWriter WriteField(this JsonWriter writer, string property, long value)
        {
            writer.WritePropertyName(property);
            writer.WriteValue(value);
            return writer;
        }

        public static JsonWriter WriteField(this JsonWriter writer, string property, long? value)
        {
            if (value.HasValue)
            {
                writer.WritePropertyName(property);
                writer.WriteValue(value);
            }
            return writer;
        }

        public static JsonWriter WriteField(this JsonWriter writer, string property, double value)
        {
            writer.WritePropertyName(property);
            writer.WriteValue(value);
            return writer;
        }

        public static JsonWriter WriteField(this JsonWriter writer, string property, double? value)
        {
            if (value.HasValue)
            {
                writer.WritePropertyName(property);
                writer.WriteValue(value);
            }
            return writer;
        }

        public static JsonWriter WriteField(this JsonWriter writer, string property, DateTime value)
        {
            writer.WritePropertyName(property);
            writer.WriteValue(value.ToString("yyyy-MM-dd"));
            return writer;
        }

        public static JsonWriter WriteDateFieldWithTime(this JsonWriter writer, string property, DateTime value)
        {
            writer.WritePropertyName(property);
            writer.WriteValue(value.ToString("yyyy-MM-ddTHH:mm"));
            return writer;
        }
        public static JsonWriter WriteField(this JsonWriter writer, string property, DateTime? value)
        {
            if (value.HasValue)
            {
                writer.WritePropertyName(property);
                writer.WriteValue(value);
            }
            return writer;
        }

        public static JsonWriter WriteField(this JsonWriter writer, string property, bool value)
        {
            writer.WritePropertyName(property);
            writer.WriteValue(value);
            return writer;
        }

        public static JsonWriter WriteField(this JsonWriter writer, string property, bool? value)
        {
            if (value.HasValue)
            {
                writer.WritePropertyName(property);
                writer.WriteValue(value);
            }
            return writer;
        }

        public static JsonWriter WriteField<T>(this JsonWriter writer, string property, T value, JsonSerializer serializer)
        {
            if (value != null)
            {
                writer.WritePropertyName(property);
                serializer.Serialize(writer, value);
            }
            return writer;
        }

        public static string ReadAsString(this JObject json, string property, string path = null)
        {
            JToken value;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
                return null;
            property = path == null ? property : $"{path}.{property}";
            var val = value as JValue;
            if (val != null)
            {
                if (val.Type == JTokenType.String || val.Type == JTokenType.Null)
                {
                    return value?.Value<string>()?.Trim();
                }
                SerializerUtility.ThrowBadRequestException($"{property}", "string");
            }
            SerializerUtility.ThrowBadRequestException($"{property}", "string");
            return null;
        }

        public static T ReadAsObject<T>(this JObject json, string property, JsonSerializer serializer)
        {
            JToken value;

            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
                return default(T);

            return serializer.Deserialize<T>(value.CreateReader());
        }
        public static T ReadAsEnumMandatory<T>(this JObject json, string property, JsonSerializer serializer, string path)
        {
            JToken value;

            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
                SerializerUtility.ThrowBadRequestException(path + "." + property, " enum value");

            return serializer.Deserialize<T>(value.CreateReader());
        }

        public static decimal? ReadAsNullableDecimal(this JObject json, string property, string path)
        {
            JToken value;
            decimal parsed;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false || value.Type == JTokenType.Null)
                return null;
            if (decimal.TryParse(value.ToString(), out parsed) == false)
                SerializerUtility.ThrowBadRequestException(path + "." + property, " decimal value");

            return parsed;
        }

        public static int? ReadAsNullableInt(this JObject json, string property, string path)
        {
            JToken value;
            int parsed;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false || value.Type == JTokenType.Null)
                return null;
            if (int.TryParse(value.ToString(), out parsed) == false)
                SerializerUtility.ThrowBadRequestException(path + "." + property, " int value");

            return parsed;
        }
        public static bool? ReadAsNullableBool(this JObject json, string property, string path)
        {
            JToken value;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
                return null;
            var val = value as JValue;
            if (val != null)
            {
                if ((val.Type == JTokenType.Boolean) || (val.Type == JTokenType.Null))
                {
                    return value?.Value<bool?>();
                }
            }
            SerializerUtility.ThrowBadRequestException(path + "." + property, " bool value");
            return null;
        }

        public static int ReadAsInt(this JObject json, string property, string path)
        {
            JToken value;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
                return 0;
            var val = value as JValue;
            if (val != null)
            {
                if (val.Type == JTokenType.Integer)
                {
                    return value.Value<int>();
                }
            }
            SerializerUtility.ThrowBadRequestException(path + "." + property, "integer value");
            return 0;
        }

        public static double ReadAsDouble(this JObject json, string property, string path)
        {
            JToken value;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
            {
                if (value == null)
                    SerializerUtility.ThrowBadRequestException(path + "." + property, "double value");
                return 0;
            }
            var val = value as JValue;
            if (val != null)
            {
                if (val.Type == JTokenType.Float || val.Type == JTokenType.Integer)
                {
                    return value.Value<double>();
                }
            }
            SerializerUtility.ThrowBadRequestException(path + "." + property, " double value");
            return 0;
        }
        public static long ReadAsLong(this JObject json, string property, string path)
        {
            JToken value;
            long parsed;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
                return 0;
            if (long.TryParse(value.ToString(), out parsed) == false)
                SerializerUtility.ThrowBadRequestException(path + "." + property, " double value");

            return parsed;
        }

        public static double? ReadAsNullableDouble(this JObject json, string property, string path)
        {
            JToken value;
            double parsed;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false || value.Type == JTokenType.Null)
                return null;
            if (double.TryParse(value.ToString(), out parsed) == false)
                SerializerUtility.ThrowBadRequestException(path + "." + property, " double value");

            return parsed;
        }
        public static long? ReadAsNullableLong(this JObject json, string property, string path)
        {
            JToken value;
            long parsed;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false || value.Type == JTokenType.Null)
                return null;
            if (long.TryParse(value.ToString(), out parsed) == false)
                SerializerUtility.ThrowBadRequestException(path + "." + property, " long value");

            return parsed;
        }
        public static decimal ReadAsDecimal(this JObject json, string property, string path)
        {
            JToken value;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
            {
                if (value == null)
                    SerializerUtility.ThrowBadRequestException(path + "." + property, "decimal value");
                return 0;
            }

            var val = value as JValue;
            if (val != null)
            {
                if (val.Type == JTokenType.Float || val.Type == JTokenType.Integer)
                {
                    return value.Value<decimal>();
                }
            }
            SerializerUtility.ThrowBadRequestException(path + "." + property, "decimal value");
            return 0;
        }
        public static bool ReadAsBooleanMandatory(this JObject json, string property, string path)
        {
            JToken value;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
                SerializerUtility.ThrowBadRequestExceptionWithMessage(ErrorMessages.InvalidRequest() + $" The boolean value field is required in the request at {path}.{ property}");

            var val = value as JValue;
            if (val == null)
                SerializerUtility.ThrowBadRequestException(path + "." + property, "boolean value");
            bool parsed;
            if (!bool.TryParse(value.ToString(), out parsed))
                SerializerUtility.ThrowBadRequestException(path + "." + property, "boolean value");
            return parsed;
        }

        public static bool ReadAsBool(this JObject json, string property, string path)
        {
            JToken value;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
                return false;
            var val = value as JValue;
            if (val != null)
            {
                if (val.Type == JTokenType.Boolean)
                {
                    return value.Value<bool>();
                }
            }
            SerializerUtility.ThrowBadRequestException(path + "." + property, " bool value");
            return false;
        }

        public static DateTime ReadAsDateTime(this JObject json, string property, string path)
        {
            JToken value;
            DateTime parsed;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
                return new DateTime();
            if (!DateTime.TryParse(value.ToString(), out parsed))
                SerializerUtility.ThrowBadRequestException(path + "." + property, "date value in format \"yyyy-MM-dd\"");
            return parsed;
        }

        public static List<T> ReadAsArray<T>(this JObject json, string property, JsonSerializer serializer)
        {
            JToken value;

            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
                return new List<T>();
            var val = value as JArray;
            if (val == null)
            {
                SerializerUtility.ThrowBadRequestException($"{json.Path}.{property}", $"Array of {typeof(T).Name}");
            }
            try
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                    return new List<T>();
                return serializer.Deserialize<T[]>(value.CreateReader()).ToList();
            }
            catch (JsonSerializationException)
            {
                try
                {
                    return new List<T> { serializer.Deserialize<T>(value.CreateReader()) };
                }
                catch (JsonSerializationException ex1)
                {
                    var path = Regex.Match(ex1.Message, @"Path '.+'", RegexOptions.Compiled);

                    SerializerUtility.ThrowBadRequestException(path.Value, $"Array of {typeof(T).Name}");
                }
            }
            return new List<T>();
        }

        public static uint ReadAsUInt(this JObject json, string property, string path)
        {
            JToken value;
            uint parsed = 0;
            if (json.TryGetValue(property, StringComparison.OrdinalIgnoreCase, out value) == false)
                return 0;
            var val = value as JValue;
            if (val != null)
            {
                if (val.Type == JTokenType.Integer)
                {
                    if (!uint.TryParse(value.ToString(), out parsed))
                        SerializerUtility.ThrowBadRequestException(path + "." + property, "integer value");
                }
                else
                    SerializerUtility.ThrowBadRequestException(path + "." + property, "integer value");
            }
            else
                SerializerUtility.ThrowBadRequestException(path + "." + property, "integer value");
            return parsed;
        }
    }
    public static class SerializerUtility
    {
        public static void ThrowBadRequestException(string path, string expectedValue = null)
        {
            string message = expectedValue == null
                        ? ErrorMessages.InvalidRequest() + $"Incorrect value at {path}."
                        : ErrorMessages.InvalidRequest() + $"Incorrect value at {path}, expected was {expectedValue}.";

            var info = new List<Info>
            {
                new Info ( FaultCodes.InvalidRequest, message )
            };
            var errorInfo = new ErrorInfo(FaultCodes.ValidationFailure, ErrorMessages.ValidationFailure(), System.Net.HttpStatusCode.BadRequest);
            errorInfo.Info.AddRange(info);
            throw new BadRequestException(errorInfo);
        }

        public static void ThrowBadRequestException(Exception ex)
        {
            string message = ErrorMessages.InvalidRequest();
            var info = new List<Info>
            {
                new Info ( FaultCodes.InvalidRequest, message )
            };
            var errorInfo = new ErrorInfo(FaultCodes.ValidationFailure, ErrorMessages.ValidationFailure(), System.Net.HttpStatusCode.BadRequest);
            errorInfo.Info.AddRange(info);
            throw new BadRequestException(errorInfo);
        }

        public static void ThrowBadRequestExceptionWithMessage(string message)
        {
            var info = new List<Info>
            {
                new Info ( FaultCodes.InvalidRequest, message )
            };
            var errorInfo = new ErrorInfo(FaultCodes.ValidationFailure, ErrorMessages.ValidationFailure(), System.Net.HttpStatusCode.BadRequest);
            errorInfo.Info.AddRange(info);
            throw new BadRequestException(errorInfo);
        }
    }

}
using PetProjectC_NeuroWeb.Modules.UserModule;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetProjectC_NeuroWeb.Modules.Converters
{
    public class CustomJSONConverter : JsonConverter<UserData>
    {

        public override UserData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var login = "Undefined";
            var hashedPassword = "Undefined";
            var salt = "Unknown";

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read();

                    switch (propertyName?.ToLower())
                    {
                        case "login":
                            login = reader.GetString();
                            break;

                        case "hashedPassword":
                            hashedPassword = reader.GetString();
                            break;

                        case "salt":
                            salt = reader.GetString();
                            break;
                    }

                }
            }
            return new UserData(login, salt, hashedPassword);


        }

        public override void Write(Utf8JsonWriter writer, UserData userData, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("login", userData.Login);
            writer.WriteString("salt", userData.Salt);
            writer.WriteEndObject();
        }

    }
}

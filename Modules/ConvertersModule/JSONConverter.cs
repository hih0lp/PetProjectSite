using PetProjectC_NeuroWeb.Modules.UserModule;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetProjectC_NeuroWeb.Modules.ConvertersModule
{
    public class CustomJSONConverter : JsonConverter<UserData>
    {

        public override UserData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var login = "Undefined";
            var password = "Undefined";

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

                        case "password":
                            password = reader.GetString();
                            break;

                    }

                }
            }
            if(login == null || password == null) return null;
            return new UserData(login, salt, password);


        }

        public override void Write(Utf8JsonWriter writer, UserData userData, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("login", userData.Login);
            writer.WriteEndObject();
        }

    }
}

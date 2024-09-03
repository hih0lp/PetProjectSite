using PetProjectC_NeuroWeb.Modules.User;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetProjectC_NeuroWeb.Modules.Converters
{
    public class JSONConverter : JsonConverter <UserData> 
    {



        public override void Write(Utf8JsonWriter writer, UserData value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override UserData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }



    }
}

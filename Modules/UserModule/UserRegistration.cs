using Microsoft.AspNetCore.Http.Json;
using PetProjectC_NeuroWeb.Modules.ConvertersModule;
using System.Text.Json;
using PetProjectC_NeuroWeb.Modules.DataBaseModule;

namespace PetProjectC_NeuroWeb.Modules.UserModule
{
    public class UserRegistration
    {
        public static async void Registration(HttpContext context)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new CustomJSONConverter());

            if (context.Request.HasJsonContentType())
            {
                var userDTO = await context.Request.ReadFromJsonAsync<RegisterUserDTO>(options);

                if (userDTO != null)
                {
                    
                    using (var db = new UserDataBase())
                    {

                    }
                }
            }

            
                 

            

           
        }
    }
}

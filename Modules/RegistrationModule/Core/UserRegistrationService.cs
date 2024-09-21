using Microsoft.AspNetCore.Http.Json;
using PetProjectC_NeuroWeb.Modules.UserModule.UserModule.ConvertersModule;
using System.Text.Json;
using PetProjectC_NeuroWeb.Modules.HashModule;
using System.Text;
using System.Security.Cryptography;
using PetProjectC_NeuroWeb.Modules.UserModule.UserModule.DataTransferObject;
using Microsoft.EntityFrameworkCore.Storage.Json;
using PetProjectC_NeuroWeb.Modules.UserModule.UserModule.Core;
using PetProjectC_NeuroWeb.Modules.RegistrationModule.Ports;
using PetProjectC_NeuroWeb.Modules.HashModule.Ports;
using PetProjectC_NeuroWeb.Modules.HashModule.Core;




namespace PetProjectC_NeuroWeb.Modules.RegistrationModule.Services
{
    //summary


    public class UserRegistrationService : IUserRegistrationService
    {
        public async Task UserRegistration(HttpContext context, HashSHA512 hashService)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new UserJSONConverter());

            if (context.Request.HasJsonContentType())
            {
                var userDTO = await context.Request.ReadFromJsonAsync<UserDTO>(options);

                if (userDTO != null)
                {
                    byte[] salt = GenerateSalt();
                    string hashedPassword = Convert.ToBase64String(hashService.GenerateHashedPassword(userDTO.password, salt));
                    string id = Guid.NewGuid().ToString();

                    User user = new User(userDTO.login!, Convert.ToBase64String(salt), hashedPassword, id);

                    using (var db = new UserDataBase())
                    {
                        db.Users.Add(user);
                    }
                }
            }
        }

        private byte[] GenerateSalt()
        {

            const int SALTLENGTH = 64;
            byte[] salt = new byte[SALTLENGTH];

            var cryptoProvider = new RNGCryptoServiceProvider();
            cryptoProvider.GetBytes(salt);



            return salt;
        }

        
    }
}



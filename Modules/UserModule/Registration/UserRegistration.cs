using Microsoft.AspNetCore.Http.Json;
using PetProjectC_NeuroWeb.Modules.UserModule.ConvertersModule;
using System.Text.Json;
using PetProjectC_NeuroWeb.Modules.DataBaseModule;
using System.Security.Cryptography;
using System.Text;
using PetProjectC_NeuroWeb.Modules.UserModule.Services;
using PetProjectC_NeuroWeb.Modules.UserModule.DataTransferObject;
using Microsoft.EntityFrameworkCore.Storage.Json;




namespace PetProjectC_NeuroWeb.Modules.UserModule.Registration
{
    //summary


    public class UserRegistrationService : IUserRegistrationService
    {
        public async Task UserRegistration(HttpContext context)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new UserJSONConverter());

            if (context.Request.HasJsonContentType())
            {
                var userDTO = await context.Request.ReadFromJsonAsync<RegisterUserDTO>(options);

                if (userDTO != null)
                {
                    byte[] salt = GenerateSalt();
                    string hashedPassword = Convert.ToBase64String(GenerateHashedPassword(userDTO.password, salt));


                    User user = new User(userDTO.login!, Convert.ToBase64String(salt), hashedPassword);

                    using (var db = new UserDataBase())
                    {
                        db.Users.Add(user);
                    }
                }
            }
        }

        private byte[] GenerateSalt()
        {

            const int saltLength = 64;
            byte[] salt = new byte[saltLength];

            var cryptoProvider = new RNGCryptoServiceProvider();
            cryptoProvider.GetBytes(salt);



            return salt;
        }

        private byte[] GenerateHashedPassword(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] _salt = salt;
            byte[] saltedPassword = new byte[passwordBytes.Length + _salt.Length];

            Array.Copy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
            Array.Copy(_salt, 0, saltedPassword, 0, _salt.Length);

            var hashProvider = new SHA512CryptoServiceProvider();

            return hashProvider.ComputeHash(saltedPassword);
        }
    }
}



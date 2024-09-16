using Microsoft.AspNetCore.Http.Json;
using PetProjectC_NeuroWeb.Modules.ConvertersModule;
using System.Text.Json;
using PetProjectC_NeuroWeb.Modules.DataBaseModule;
using System.Security.Cryptography;
using System.Text;




namespace PetProjectC_NeuroWeb.Modules.UserModule
{
    //summary
    

    public class UserRegistrationService : IUserRegistrationService
    {
        public async Task UserRegistration(HttpContext context)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new CustomJSONConverter());

            if (context.Request.HasJsonContentType())
            {
                var userDTO = await context.Request.ReadFromJsonAsync<RegisterUserDTO>(options);

                if (userDTO != null)
                {
                    byte[] salt = GenerateSalt();
                    byte[] hashedPassword = GenerateHashedPassword(userDTO.password, salt);

                    using (var db = new UserDataBase())
                    {

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

            var hashProvider = new SHA256CryptoServiceProvider();

            return hashProvider.ComputeHash(saltedPassword);
        }
    }
}


//lets celebrate and suck some dick
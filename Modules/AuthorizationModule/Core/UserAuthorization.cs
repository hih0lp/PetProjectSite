using PetProjectC_NeuroWeb.Modules.HashModule.Ports;
using PetProjectC_NeuroWeb.Modules.UserModule.UserModule.ConvertersModule;
using PetProjectC_NeuroWeb.Modules.UserModule.UserModule.DataTransferObject;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PetProjectC_NeuroWeb.Modules.AuthorizationModule.Core
{
    public class UserAuthorization
    {
        public async Task UserAuthorizationAsync(HttpContext context, IHashService hashService)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new UserJSONConverter());

            if (context.Request.HasJsonContentType())
            {
                var userDTO = await context.Request.ReadFromJsonAsync<UserDTO>(options);

                if(userDTO != null)
                {
                    

                    using (var db = new UserDataBase())
                    {
                        var users = db.Users.ToList();
                        var checkingUser = users.FirstOrDefault(u => u.Login == userDTO.login);

                        if (checkingUser != null)
                        {
                            var checkingHashPassword = hashService.GenerateHashedPassword(userDTO.password, Encoding.UTF8.GetBytes(checkingUser.Salt));

                            if(checkingUser.HashedPassword == checkingHashPassword.ToString())
                            {
                                ///отправить jwt
                            }
                        }
                        
                        
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

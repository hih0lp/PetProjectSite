using PetProjectC_NeuroWeb.Modules.UserModule.UserModule.Core;
using PetProjectC_NeuroWeb.Modules.UserModule.UserModule.DataTransferObject;


namespace PetProjectC_NeuroWeb.Modules.AuthorizationModule.Core.Core
{
    public class UserTokenService
    {
        public static async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            using (var db = new UserDataBase())
            {
                var users = db.Users.ToList();
                var user = users.FirstOrDefault(u => u.RefreshToken == refreshToken);

                if (user != null)
                {
                    return user;
                }
                return null;
            }
        }
    }
}

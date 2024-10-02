using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Primitives;

namespace PetProjectC_NeuroWeb.Modules.UserModule.UserModule
{
    public class UserData
    {

        public UserData(string login, string salt, string hashedPassword)
        {
            _login = login;
            _salt = salt;
            _hashedPassword = hashedPassword;
            
        }

        private string _login;
        private string _salt;
        private string _hashedPassword;
        

        public string Login
        {
            get => _login; 
            set => _login = value; 
        }

        public string Salt
        {
            get => _salt; 
            set => _salt = value; 
        }

        public string hashedPassword
        {
            get => _hashedPassword;
            set => _hashedPassword = value; 
        }

    }
}

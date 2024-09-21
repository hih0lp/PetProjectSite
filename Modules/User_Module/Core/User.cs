using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace PetProjectC_NeuroWeb.Modules.UserModule.UserModule.Core
{
    public class User
    {

        public User()
        {

        }

        public User(string login, string hashedPassword, string salt, string Id)
        {
            _login = login;
            _salt = salt;
            _hashedPassword = hashedPassword;
            _id = Id;
        }

        private string _login;
        private string _salt;
        private string _hashedPassword;
        private string _id;








    }
}




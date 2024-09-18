


using PetProjectC_NeuroWeb.Modules.UserModule;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace PetProjectC_NeuroWeb.Modules.UserModule
{
    public class User
    {

        public User()
        {

        }

        public User(string login, string hashedPassword, string salt)
        {
            _login = login;
            _salt = salt;
            _hashedPassword = hashedPassword;
        }

        private string _login;
        private string _salt;
        private string _hashedPassword;

        




        

    }
}




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

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string HashedPassword
        { 
            get { return _hashedPassword; }
            set { _hashedPassword = value; } 
        }

        public string Salt
        {
            get { return _salt; }
            set { _salt = value; }
        }











    }
}




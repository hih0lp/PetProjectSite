


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

        public User(string login, string salt, string hashedPassword)
        {
            _userdata = new UserData(login, salt, hashedPassword);
        }

        public User(UserData userData)
        {
            _userdata.Login = userData.Login;
            _userdata.Salt = userData.Salt;
            _userdata.hashedPassword = userData.hashedPassword;
        }

        private UserData _userdata = null!;



        public UserData UserData
        {
            get => _userdata;
            set => _userdata = value;
        }

        public int UserDataId { get; set; }

        //public async Task Save()
        //{
        //    using (var dataBase = new DataBaseModule())
        //    {

        //    }
        //}

        

    }
}




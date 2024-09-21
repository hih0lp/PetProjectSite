using System.Text;
using System.Security.Cryptography;
using PetProjectC_NeuroWeb.Modules.HashModule.Ports;

namespace PetProjectC_NeuroWeb.Modules.HashModule.Core
{
    public class HashSHA512 : IHashService
    {
        public byte[] GenerateHashedPassword(string password, byte[] salt)
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

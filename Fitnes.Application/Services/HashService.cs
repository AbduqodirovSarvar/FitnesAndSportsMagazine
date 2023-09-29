using Fitnes.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Fitnes.Application.Services
{
    public class HashService : IHashService
    {
        public string GetHash(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            string hash = Convert.ToBase64String(hashBytes);
            return hash;
        }
    }
}

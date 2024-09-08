using System.Security.Cryptography;
using System.Text;

namespace Gvn.IceCream.API.Services
{
    public class PasswordServices
    {
        private const int SaltSize = 512;
        public (string salt, string hashedPassword) GenerateSaltedHash(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                throw new ArgumentException("Password cannot be empty or null");
            var buffer = RandomNumberGenerator.GetBytes(SaltSize);
            var salt = Convert.ToBase64String(buffer);
            var bytes=Encoding.UTF8.GetBytes(plainPassword+salt);
            var hash = SHA256.HashData(bytes);

            var hashedPassword = GenerateHashedPassword(plainPassword,salt);
            return (salt, hashedPassword);
        }
        public bool ComparePassword(string plainPassword, string salt, string hashedPassword)
        { 
            var hashedPasswordToCompare = GenerateHashedPassword(plainPassword,salt);
            return hashedPassword == hashedPasswordToCompare;
        }
        private static string GenerateHashedPassword(string plainPassword, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(plainPassword + salt);
            var hash = SHA256.HashData(bytes);
            return Convert.ToBase64String(hash);
        }
        public bool AreEqual(string plainPassword, string salt, string hashedPassword)
        {
            var hashedPasswordToCompare = GenerateHashedPassword(plainPassword, salt);
            return hashedPassword == hashedPasswordToCompare;
        }
    }
}

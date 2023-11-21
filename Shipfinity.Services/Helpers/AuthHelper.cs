using Shipfinity.Domain.Models;
using System.Security.Cryptography;
using System.Text;

namespace Shipfinity.Services.Helpers
{
    internal static class AuthHelper
    {
        public static void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if(string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Password cannot be empty");
            }

            using var sha512 = new HMACSHA512();
            passwordSalt = sha512.Key;
            passwordHash = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public static bool VerifyPassword(this BaseUser user, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            using var sha512 = new HMACSHA512(user.PasswordSalt);
            byte[] testHash = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            return user.PasswordHash.SequenceEqual(testHash);
        }
    }
}

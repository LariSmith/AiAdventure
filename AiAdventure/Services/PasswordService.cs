using AiAdventure.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace AiAdventure.Services
{
    public class PasswordService : IPasswordService
    {
        public string Encrypt(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    stringBuilder.Append(hashedBytes[i].ToString("x2"));
                }

                string hashedPassword = stringBuilder.ToString();
                return hashedPassword;
            }
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInputPassword = Encrypt(password);
            return hashedInputPassword.Equals(hashedPassword);
        }
    }
}

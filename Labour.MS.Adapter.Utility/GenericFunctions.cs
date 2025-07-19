using System.Security.Cryptography;
using System.Text;

namespace Labour.MS.Adapter.Utility
{
    public class GenericFunctions
    {
        public static string GetEncryptedPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Fixed the error by replacing the missing 'Cryptography.GetHash' with direct hashing logic  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool VerifyHashPassword(string password, string encryptedPassword)
        {
            string inputHashPassword = GetEncryptedPassword(password);
            return inputHashPassword.Equals(encryptedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}

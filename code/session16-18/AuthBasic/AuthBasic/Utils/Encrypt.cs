using System.Text;
using System.Security.Cryptography;

namespace AuthBasic.Utils {
    public class Encrypt {
        public static string EncryptPassword(string password) {

            byte[] bytes = Encoding.UTF8.GetBytes(password);

            byte[] hash = SHA256.HashData(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}

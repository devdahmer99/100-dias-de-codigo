
using System.Text;
using System.Security.Cryptography;

namespace _100_dias_de_codigo.Services;


public class Criptografia
{
    public string HashPassword(string password)
    {
       using (SHA256 sha256sh = SHA256.Create())
        {
            byte[] bytes = sha256sh.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder build = new StringBuilder();
            foreach(byte b in bytes)
            {
                build.Append(b.ToString("x2"));
            }

            return build.ToString();
        }
    }

}

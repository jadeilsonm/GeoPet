using System.Security.Cryptography;
using System.Text;


// ref -> "https://learn.microsoft.com/pt-br/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=net-7.0"
namespace GeoPetAPI.Shared.Helprs
{
    public static class CreateHashInformation
    {
        public static string CreatHash(string str)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hash = GetHash(sha256Hash, str);
                return hash;
            };
        }
         

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}

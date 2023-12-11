using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace Shipfinity.Services.Helpers
{
    public class StringEncoder : IStringEncoder
    {
        private readonly string _key;
        public StringEncoder(IConfiguration configuration)
        {
            _key = configuration["CryptKey"] ?? "__EncodingKey__";
        }
        public string Decode(string value)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(value);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                    using StreamReader streamReader = new StreamReader(cryptoStream);
                    return streamReader.ReadToEnd();
                }
            }
        }

        public string Encode(string value)
        {
            byte[] iv = new byte[16];
            byte[] buffer;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_key);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(value);
                        }
                        buffer = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(buffer);
        }
    }
}

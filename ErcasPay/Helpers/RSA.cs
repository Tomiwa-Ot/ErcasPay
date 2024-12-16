using System.Security.Cryptography;
using System.Text;
using ErcasPay.Base.Request;
using Newtonsoft.Json;

namespace ErcasPay.Helpers
{
    /// <summary>
    /// RSA encryption helper
    /// </summary>
    public static class RSA
    {
        /// <summary>
        /// Encrypt card information using RSA
        /// </summary>
        /// <param name="publicKey">RSA public key</param>
        /// <param name="card">Card information</param>
        /// <returns>RSA encrypted string</returns>
        public static string EncryptCard(string publicKey, Card card)
        {
            // Remove forward slash in card expiry data and json encode
            card.expiryDate.Replace("/", "");
            string json = System.Text.Json.JsonSerializer.Serialize(card);
            
            // Encrypt json using RSA and public key
            publicKey.Replace("RSA", "").Trim();
            using (System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create())
            {
                // Import the public key (from PEM format)
                rsa.ImportFromPem(publicKey.ToCharArray());

                // Convert the data to a byte array
                byte[] dataBytes = Encoding.UTF8.GetBytes(json);

                // Encrypt the data
                return Convert.ToBase64String(rsa.Encrypt(dataBytes, RSAEncryptionPadding.Pkcs1));
            }
        }
    }
}
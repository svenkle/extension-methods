using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Svenkle.ExtensionMethods
{
    public static class StringExtensions
    {
        public static byte[] ToByteArray(this string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string[] Split(this string str, string separator, StringSplitOptions options)
        {
            return str.Split(new[] { separator }, options);
        }

        public static string[] Split(this string str, char separator, StringSplitOptions options)
        {
            return str.Split(new[] { separator }, options);
        }

        public static string[] Split(this string str, string separator)
        {
            return str.Split(new[] { separator }, StringSplitOptions.None);
        }

        public static string ToSHA1Hash(this string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var shaProvider = new SHA1CryptoServiceProvider();
            var hashBytes = shaProvider.ComputeHash(bytes);

            var sb = new StringBuilder();
            foreach (var b in hashBytes)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        
        public static string ToMD5Hash(this string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var shaProvider = new MD5CryptoServiceProvider();
            var hashBytes = shaProvider.ComputeHash(bytes);

            var sb = new StringBuilder();
            foreach (var b in hashBytes)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        
        public static string ToSHA256Hash(this string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var shaProvider = new SHA256CryptoServiceProvider();
            var hashBytes = shaProvider.ComputeHash(bytes);

            var sb = new StringBuilder();
            foreach (var b in hashBytes)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public static Guid ToGuid(this string str)
        {
            var provider = new MD5CryptoServiceProvider();
            var inputBytes = Encoding.Default.GetBytes(str);
            var hashBytes = provider.ComputeHash(inputBytes);
            var hashGuid = new Guid(hashBytes);
            return hashGuid;
        }
        
        public static string RemoveWhitespace(this string str)
        {
            return new string(str.Where(x => !char.IsWhiteSpace(x)).ToArray());
        }

    }
}

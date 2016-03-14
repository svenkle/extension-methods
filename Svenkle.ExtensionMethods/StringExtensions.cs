using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Svenkle.ExtensionMethods
{
    public static class StringExtensions
    {
        public static byte[] ToByteArray(this string @string)
        {
            var bytes = new byte[@string.Length * sizeof(char)];
            Buffer.BlockCopy(@string.ToCharArray(), 0, bytes, 0, bytes.Length);
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

        public static string ToHash(this string @string)
        {
            var bytes = Encoding.UTF8.GetBytes(@string);
            var shaProvider = new SHA1CryptoServiceProvider();
            var hashBytes = shaProvider.ComputeHash(bytes);

            var sb = new StringBuilder();
            foreach (var b in hashBytes)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public static Guid ToGuid(this string @string)
        {
            var provider = new MD5CryptoServiceProvider();
            var inputBytes = Encoding.Default.GetBytes(@string);
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

using System.Security.Cryptography;
using System.Text;

namespace Archery.Tools
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public static class Extension
    {
        public static string HashMD5(this string value)
        {
            byte[] valueBytes = System.Text.Encoding.Default.GetBytes(value);
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] calcul = provider.ComputeHash(valueBytes);
            string result = "";
            foreach (byte b in calcul)
            {
                if (b < 16)
                    result += "0" + b.ToString("x");
                else
                    result += b.ToString("x");
            }
            return result;
        }

        //public static string MD5Hash(string text)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    md5.ComputeHash(Encoding.UTF8.GetBytes(text));
        //    byte[] protectedPassword = md5.Hash;
        //    StringBuilder stringBuilder = new StringBuilder();
        //    for (int i = 0; i < protectedPassword.Length; i++)
        //    {
        //        stringBuilder.Append(protectedPassword[i].ToString("x2"));
        //    }
        //    return stringBuilder.ToString();
        //}

        //public static string MD5Hashed (string stringToConvert)
        //{
        //    return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(stringToConvert)).Select(s => s.ToString("x2")));
        //}

        public static string SHA1Hash(string text)
        {
            SHA1 sHA1 = new SHA1CryptoServiceProvider();
            sHA1.ComputeHash(Encoding.UTF8.GetBytes(text));
            byte[] protectedPassword = sHA1.Hash;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < protectedPassword.Length; i++)
            {
                stringBuilder.Append(protectedPassword[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
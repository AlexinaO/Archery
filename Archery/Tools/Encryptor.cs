using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using Archery.Models;
using System.Text;

namespace Archery.Tools
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public sealed class Encryptor
    {

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            byte[] protectedPassword = md5.Hash;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i< protectedPassword.Length; i++)
            {
                stringBuilder.Append(protectedPassword[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }

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
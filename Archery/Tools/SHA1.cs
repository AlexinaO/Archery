using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using Archery.Models;


namespace Archery.Tools
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public sealed class SHA1 : HashAlgorithm
    {
        byte[] data = new byte[Archer.Password];
            byte[] protectedPassword;
            SHA1 sha = new SHA1CryptoServiceProvider;
        protectedPassword = sha.ComputeHash(data);
public override void Initialize()
        {
            throw new NotImplementedException();
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            throw new NotImplementedException();
        }

        protected override byte[] HashFinal()
        {
            throw new NotImplementedException();
        }
    }
}
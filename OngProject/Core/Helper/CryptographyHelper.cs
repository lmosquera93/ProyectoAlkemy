﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public static class CryptographyHelper
    {
        //Encripta Contraseña
        public static string CreateHashPass(string password)
        {
            using (var hmac = SHA256.Create())
            {
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                var sb = new StringBuilder();
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    sb.Append(passwordHash[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
        public static string DecryptHashPass(string password)
        {
            using (var hmac = SHA256.Create())
            {
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                var sb = new StringBuilder();
                foreach (byte b in passwordHash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}

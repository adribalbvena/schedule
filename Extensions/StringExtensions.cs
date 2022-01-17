using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tp_nt1.Extensions
{
    public static class StringExtensions
    {
        public static byte[] Encrypt(this string text)
        {
            return new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(text));
        }

        public static void ValidatePassword(this string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("La contraseña es requerida.");
            }

            
            if (password.Length < 6)
            {
                throw new Exception("La contraseña debe tener al menos 6 caracteres.");
            }

            
            bool containsANumber = new Regex("[0-9]").Match(password).Success;
            bool containsALowercase = new Regex("[a-z]").Match(password).Success;
            bool containsAnUppercase = new Regex("[A-Z]").Match(password).Success;

            if (!containsANumber || !containsALowercase || !containsAnUppercase)
            {
                throw new Exception("La contraseña debe contener al menos un número, una minúscula y una mayúscula.");
            }
        }
    }
}

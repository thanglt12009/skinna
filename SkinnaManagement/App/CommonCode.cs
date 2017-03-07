using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SkinnaManagement.App
{
    public class CommonCode
    {
        public static string HashStringValue(string value, string salt)
        {
            return GetHash(value + salt);
        }

        public static string GetHash(string StringToHash)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(StringToHash);

            SHA1Managed SHhash = new SHA1Managed();
            HashValue = SHhash.ComputeHash(MessageBytes);

            StringBuilder sb = new StringBuilder();

            foreach (byte b in HashValue)
            {
                sb.Append(string.Format("{0:x2}", b));
            }

            return sb.ToString();
        }

        public static string CreateSaltValue()
        {
            StringBuilder genString = new StringBuilder();
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int randomValue = 0;
            for (int i = 0; i < 10; i++)
            {
                randomValue = random.Next(0, 25);
                genString.Append((char)(randomValue + 65));
            }
            return genString.ToString();
        }
    }
}
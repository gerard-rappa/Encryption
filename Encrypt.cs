using System;
using System.Text;
using System.Security.Cryptography;

namespace EX3A
{
   public class Encrypt
    {
        public static string MakeKey(string input)
        {
            //Console.WriteLine();
            //Console.WriteLine("Password= "+input);
            string hash;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, input);
            }
            //Console.WriteLine("Hashed Password= "+hash);
            //Console.WriteLine();
            return hash;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            //Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}

using System;
using System.Security.Cryptography;
using System.Text;

namespace BankSystemBusinessLayar.Security
{
    public  class HashService
    {
       public static string ComuteHash(string Input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashbytes =sha256.ComputeHash(Encoding.UTF8.GetBytes(Input));

                return BitConverter.ToString(hashbytes).Replace("-","").ToLower();
            }
        }

    }
}

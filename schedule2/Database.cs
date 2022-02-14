using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
 

namespace schedule2
{
    internal class Database
    {
        //username, (hashpass, salt)
        private Dictionary<string, string[]> accounts;
        public Database()
        {
            accounts = new Dictionary<string, string[]>();
            var lines = File.ReadAllLines("pwds.txt");
            foreach (string line in lines)
            {
                string[] split_line = line.Split(',');
                string[] output = { split_line[1], split_line[2] };
                accounts.Add(split_line[0], output);
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            try {
                string[] pwd_and_hash = accounts[username];
                return pwd_and_hash[0] == ComputeHash(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(pwd_and_hash[1]));
            }
            catch (KeyNotFoundException) { return false; };


        }
        private string ComputeHash(byte[] bytesToHash, byte[] salt)
        {
            var byteResult = new Rfc2898DeriveBytes(bytesToHash, salt, 10000);
            return Convert.ToBase64String(byteResult.GetBytes(24));
        }
        private string GenerateSalt()
        {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}

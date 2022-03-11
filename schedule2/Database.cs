using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
 

namespace schedule2
{
    public class Database
    {

        public struct Schedule
        {
            public string[] monday;
            public string[] tuesday;
            public string[] wednesday;
            public string[] thursday;
            public string[] friday;
            public string[] saturday;
            public string[] sunday;
        } 


        public struct DBReturnMessage
        {
            public bool success;
            public string[] error_messages;
        }

        public struct SignInMessage
        {
            public bool success;
            public User user;
            public string[] error_messages;
        }


        //username, (hashpass, salt, user)
        private Dictionary<string, object[]> accounts;
        public Database()
        {
            accounts = new Dictionary<string, object[]>();

            var lines = File.ReadAllLines("pwds.txt");
            foreach (string line in lines)
            {
                string[] split_line = line.Split(',');
                User user = getUserById(split_line[3]).user;
                string[] output = { split_line[1], split_line[2], split_line[3]};
                accounts.Add(split_line[0], output);
            }
        }

        public SignInMessage AuthenticateUser(string username, string password)
        {
            SignInMessage message = new SignInMessage();
            message.success = false;
            try {
                object[] pwd_and_hash = accounts[username];
                if (pwd_and_hash[0].ToString() == ComputeHash(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(pwd_and_hash[1].ToString())))
                {
                    message.success = true;
                    message.user = (User)pwd_and_hash[2];
                }
                else
                {
                    string[] errors = { "incorrect password" };
                    message.error_messages = errors;
                }
            }
            catch (KeyNotFoundException) {
                string[] errors = { "no account" };
                message.error_messages = errors;
            };

            return message;

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

        public DBReturnMessage RegisterUser(string username, string password, User user)
        {
            DBReturnMessage return_message = new DBReturnMessage();
            string json_file_name;
            string json_text;

            try {
                string salt = GenerateSalt();
                string hash = ComputeHash(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt));
                string uuid = Guid.NewGuid().ToString();
                string[] user_login_info = { hash, salt, uuid };
                accounts.Add(username, user_login_info);
                File.AppendAllText("pwds.txt", Environment.NewLine + username + "," + hash + "," + salt + "," + uuid );

               

                if (user.isDirector)
                {
                    json_file_name = "masterAvailability.json";

                    Schedule schedule = new Schedule();
                    schedule.monday = user.days[0];
                    schedule.tuesday = user.days[1];
                    schedule.wednesday = user.days[2];
                    schedule.thursday = user.days[3];
                    schedule.friday = user.days[4];
                    schedule.saturday = user.days[5];
                    schedule.sunday = user.days[6];
                    json_text = JsonConvert.SerializeObject(schedule);
                }
                else
                {
                    json_file_name = "users/" + uuid + ".json";
                    json_text = JsonConvert.SerializeObject(user);
                }
               
                File.WriteAllText(json_file_name, json_text);
            }
            catch (Exception e)
            {
                return_message.success = false;
                string[] error = { e.ToString() };
                return_message.error_messages = error;
                Console.Write(e.ToString());
            }

            return return_message;

        }

        public SignInMessage getUserById(string uuid)
        {
            SignInMessage message = new SignInMessage();
            message.success = false;
            try
            {
                string json_text = File.ReadAllText("user/" + uuid + ".json");
                message.user = JsonConvert.DeserializeObject<User>(json_text);
            }
            catch(Exception e)
            {
                message.success = false;
                string[] error = { e.ToString() };
                message.error_messages = error;
            }
            return message;
        }

        public Schedule getMasterAvalibility()
        {
            string json_text = File.ReadAllText("masterAvailability.json");
            return JsonConvert.DeserializeObject<Schedule>(json_text);
        }


    }
}

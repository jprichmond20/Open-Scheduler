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
    // This class is our database that we use to store all our information 
    {

        public struct UserListSchedule
        {
            public List<List<User>> monday;
            public List<List<User>> tuesday;
            public List<List<User>> wednesday;
            public List<List<User>> thursday;
            public List<List<User>> friday;
            public List<List<User>> saturday;
            public List<List<User>> sunday;
        }

        public struct UserListSchedGUID
        {
            public List<List<String>> monday;
            public List<List<String>> tuesday;
            public List<List<String>> wednesday;
            public List<List<String>> thursday;
            public List<List<String>> friday;
            public List<List<String>> saturday;
            public List<List<String>> sunday;
        }
        private struct DirectorSettings
        {
            public bool mix_ages;
            public bool multiple_shifts;
            public bool multiple_majors;
        }


        public struct Schedule // Scruct to hold a schedule
        {
            public string[] monday;
            public string[] tuesday;
            public string[] wednesday;
            public string[] thursday;
            public string[] friday;
            public string[] saturday;
            public string[] sunday;
        } 


        public struct DBReturnMessage // Struct for default return message from database
        {
            public bool success;
            public string[] error_messages;
        }

        public struct SignInMessage // struct for return message on sign in 
        {
            public bool success;
            public User user;
            public string[] error_messages;
        }


        //username, (hashpass, salt, user)
        // Intialize dictionary to hold all of our accounts that have been generated
        private Dictionary<string, object[]> accounts;
        public Database()
        {
            // When constructor is called, we initialize our accounts dictionary
            accounts = new Dictionary<string, object[]>();

            var lines = File.ReadAllLines("pwds.txt");
            foreach (string line in lines)
            {
                string[] split_line = line.Split(',');
                User user = getUserById(split_line[3]).user;
                object[] output = { split_line[1], split_line[2], user};
                accounts.Add(split_line[0], output);
            }

        }

        public SignInMessage AuthenticateUser(string username, string password)
        // this function authenitcates our user and gets us their information after they login
        {
            SignInMessage message = new SignInMessage(); // create a new sign in message
            message.success = false; // by default we set success to false
            try {
                // This code will all execute if the suer has an account but the password is incorrect
                object[] pwd_and_hash = accounts[username];
                if (pwd_and_hash[0].ToString() == ComputeHash(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(pwd_and_hash[1].ToString())))
                // If the login is correct we set success to true and set the user 
                {
                    message.success = true;
                    message.user = (User) pwd_and_hash[2];
                }
                else
                // Otherwise we tell them its an incorrect password
                {
                    string[] errors = { "incorrect password" };
                    message.error_messages = errors;
                }
            }
            catch (KeyNotFoundException) {
                // This code will execute if there is no account
                string[] errors = { "no account" };
                message.error_messages = errors;
            };

            return message; // return our sign in message 

        }
        private string ComputeHash(byte[] bytesToHash, byte[] salt)
        // function to compute hash 
        {
            var byteResult = new Rfc2898DeriveBytes(bytesToHash, salt, 10000);
            return Convert.ToBase64String(byteResult.GetBytes(24));
        }
        private string GenerateSalt()
        // function to generate salt
        {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public DBReturnMessage RegisterUser(string username, string password, User user)
        // This function registers a user to our database
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

                if (user.IsDirector())
                {
                    
                    Director director = new Director(user);
                    director.updatefromMasterSched(getMasterAvalibility());

                }
                /*else
                {
                    Consultant user = new Consultant(user);
                }*/
                 Directory.CreateDirectory("users/");
                 json_file_name = "users/" + uuid + ".json";
                 json_text = JsonConvert.SerializeObject(user);
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
        // Gets a user from our database using their user id
        {
            SignInMessage message = new SignInMessage();
            message.success = false;
            try
            {
                string json_text = File.ReadAllText("users/" + uuid + ".json");
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
        // Gets the master availability from our database and returns a schedule
        {
            string json_text = File.ReadAllText("masterAvailability.json");
            return JsonConvert.DeserializeObject<Schedule>(json_text);
        }

        public void setMasterAvailibility(Director user)
        {
            String json_file_name = "masterAvailability.json";

            Schedule schedule = new Schedule();
            schedule.monday = user.days[0];
            schedule.tuesday = user.days[1];
            schedule.wednesday = user.days[2];
            schedule.thursday = user.days[3];
            schedule.friday = user.days[4];
            schedule.saturday = user.days[5];
            schedule.sunday = user.days[6];
            String json_text = JsonConvert.SerializeObject(schedule);
            File.WriteAllText(json_file_name, json_text);
        }

        public void saveSchedule(UserListSchedule schedule)
        {
            String json_file_name = "userSchedule.json";
            String json_text = "{ \"monday\":[";
            foreach(List<User> slot in schedule.monday)
            {
                json_text += "[";
                foreach (User consultant in slot)
                {
                    json_text += "\"" + consultant.userID + "\",";
                }
                json_text = json_text.TrimEnd(',');
                json_text += "],";
            }
            json_text = json_text.TrimEnd(',');
            json_text += "], \"tuesday\":[";
            foreach (List<User> slot in schedule.tuesday)
            {
                json_text += "[";
                foreach (User consultant in slot)
                {
                    json_text += "\"" + consultant.userID + "\",";
                }
                json_text = json_text.TrimEnd(',');                
                json_text += "],";
            }
            json_text = json_text.TrimEnd(',');
            json_text += "], \"wednesday\":[";
            foreach (List<User> slot in schedule.wednesday)
            {
                json_text += "[";
                foreach (User consultant in slot)
                {
                    json_text += "\"" + consultant.userID + "\",";
                }
                json_text = json_text.TrimEnd(',');
                json_text += "],";
            }
            json_text = json_text.TrimEnd(',');
            json_text += "], \"thursday\":[";
            foreach (List<User> slot in schedule.thursday)
            {
                json_text += "[";
                foreach (User consultant in slot)
                {
                    json_text += "\"" + consultant.userID + "\",";
                }
                json_text = json_text.TrimEnd(',');
                json_text += "],";
            }
            json_text += "], \"friday\":[";
            foreach (List<User> slot in schedule.friday)
            {
                json_text += "[";
                foreach (User consultant in slot)
                {
                    json_text += "\"" + consultant.userID + "\",";
                }
                json_text = json_text.TrimEnd(',');
                json_text += "],";
            }
            json_text = json_text.TrimEnd(',');
            json_text += "], \"saturday\":[";
            foreach (List<User> slot in schedule.saturday)
            {
                json_text += "[";
                foreach (User consultant in slot)
                {
                    json_text += "\"" + consultant.userID + "\",";
                }
                json_text = json_text.TrimEnd(',');
                json_text += "],";
            }
            json_text = json_text.TrimEnd(',');
            json_text += "], \"sunday\":[";
            foreach (List<User> slot in schedule.sunday)
            {
                json_text += "[";
                foreach (User consultant in slot)
                {
                    json_text += "\"" + consultant.userID + "\",";
                }
                json_text = json_text.TrimEnd(',');
                json_text += "],";
            }
            json_text = json_text.TrimEnd(',');
            json_text += "]}";
            File.WriteAllText(json_file_name, json_text);
        }

        public UserListSchedule getUserSchedule()
        {
            String json_text = File.ReadAllText("userSchedule.json");
            UserListSchedGUID userListSchedIDs = JsonConvert.DeserializeObject<UserListSchedGUID>(json_text);
            UserListSchedule userSchedule = new UserListSchedule();
            userSchedule.monday = new List<List<User>>();
            userSchedule.tuesday = new List<List<User>>();
            userSchedule.wednesday = new List<List<User>>();
            userSchedule.thursday = new List<List<User>>();
            userSchedule.friday = new List<List<User>>();
            userSchedule.saturday = new List<List<User>>();
            userSchedule.sunday = new List<List<User>>();
            foreach (List<String> idList in userListSchedIDs.monday)
            {
                List<User> temp_user_time = new List<User>();
                if (idList.Count == 0)
                {
                    temp_user_time.Add(new User());
                }
                else
                {
                    foreach(String id in idList)
                    {
                        temp_user_time.Add(getUserById(id).user);
                    }
                 
                }
                userSchedule.monday.Add(temp_user_time);

            }
            foreach (List<String> idList in userListSchedIDs.tuesday)
            {
                List<User> temp_user_time = new List<User>();
                if (idList.Count == 0)
                {
                    temp_user_time.Add(new User());
                }
                else
                {
                    foreach (String id in idList)
                    {
                        temp_user_time.Add(getUserById(id).user);
                    }

                }
                userSchedule.tuesday.Add(temp_user_time);

            }
            foreach (List<String> idList in userListSchedIDs.wednesday)
            {
                List<User> temp_user_time = new List<User>();
                if (idList.Count == 0)
                {
                    temp_user_time.Add(new User());
                }
                else
                {
                    foreach (String id in idList)
                    {
                        temp_user_time.Add(getUserById(id).user);
                    }

                }
                userSchedule.wednesday.Add(temp_user_time);

            }
            foreach (List<String> idList in userListSchedIDs.thursday)
            {
                List<User> temp_user_time = new List<User>();
                if (idList.Count == 0)
                {
                    temp_user_time.Add(new User());
                }
                else
                {
                    foreach (String id in idList)
                    {
                        temp_user_time.Add(getUserById(id).user);
                    }

                }
                userSchedule.thursday.Add(temp_user_time);

            }
            foreach (List<String> idList in userListSchedIDs.friday)
            {
                List<User> temp_user_time = new List<User>();
                if (idList.Count == 0)
                {
                    temp_user_time.Add(new User());
                }
                else
                {
                    foreach (String id in idList)
                    {
                        temp_user_time.Add(getUserById(id).user);
                    }

                }
                userSchedule.friday.Add(temp_user_time);

            }
            foreach (List<String> idList in userListSchedIDs.saturday)
            {
                List<User> temp_user_time = new List<User>();
                if (idList.Count == 0)
                {
                    temp_user_time.Add(new User());
                }
                else
                {
                    foreach (String id in idList)
                    {
                        temp_user_time.Add(getUserById(id).user);
                    }

                }
                userSchedule.saturday.Add(temp_user_time);

            }
            foreach (List<String> idList in userListSchedIDs.sunday)
            {
                List<User> temp_user_time = new List<User>();
                if (idList.Count == 0)
                {
                    temp_user_time.Add(new User());
                }
                else
                {
                    foreach (String id in idList)
                    {
                        temp_user_time.Add(getUserById(id).user);
                    }

                }
                userSchedule.sunday.Add(temp_user_time);

            }

            return userSchedule;
        }

        public UserListSchedule createSchedule()
        {
            List<List<List<User>>> return_schedule_list = getEmptyScheduleForList();

            UserListSchedule return_sched = new UserListSchedule();
            try {
                List<Consultant> consultant_list = getAllConsultants();
                Schedule master_availibility = getMasterAvalibility();
                List<string[]> hour_option_list = new List<string[]> { 
                    master_availibility.monday, master_availibility.tuesday, master_availibility.wednesday, 
                    master_availibility.thursday, master_availibility.friday, master_availibility.saturday, 
                    master_availibility.sunday 
                };

                //Choices_List = [MULTIPLE_SHIFTS,MIX_MAJORS,MIX_AGES,SHIFT_MINIMUM_WORKERS,SHIFT_MAXIMUM_WORKERS]//Need to imlement

                // Workers get distributed to all available work times
            for(int x = 0; x < hour_option_list.Count; x++) {
                 for(int y = 0; y < hour_option_list[0].Length; y++)
                 {
                      if(hour_option_list[x][y] == " ")
                      {
                            foreach (Consultant worker in consultant_list)
                            {
                                if (worker.days[x][y] == " ")
                                {
                                    return_schedule_list[x][y].Add(worker);
                                    worker.numberOfShifts += 1;
                                }
                            }
                      }
                 }
            }
                List<List<List<User>>> return_schedule_list_temp = ScheduleTrimmer1(return_schedule_list, true);
                return_schedule_list = return_schedule_list_temp;
                return_sched.monday = return_schedule_list[0];
                return_sched.tuesday = return_schedule_list[1];
                return_sched.wednesday = return_schedule_list[2];
                return_sched.thursday = return_schedule_list[3];
                return_sched.friday = return_schedule_list[4];
                return_sched.saturday = return_schedule_list[5];
                return_sched.sunday = return_schedule_list[6];
                //priority = 3
                //while (priority >= 1):#Tries to reduce to SHIFT_MINIMUM_WORKERS using priority
                //    for Shift in range(len(Hour_OptionsList)):
                //        if Hour_OptionsList[Shift].priority == priority:
                //            ScheduleTrimmer1(Hour_OptionsList, Shift, Choices_List[3], False, Choices_List[0], Choices_List[1], Choices_List[2])
                //    priority -= 1

                /*
                CreateOutputFile(Hour_OptionsList, WorkersList)#Creates the "Schedule.csv" file
                PrintErrorReport(Hour_OptionsList, WorkersList, Choices_List[4], Choices_List[3])#Prints Efficiencies to Shell
                */
                

            }
            catch(Exception e) { Console.WriteLine(e); }


            return return_sched;
        }


        private List<Consultant> getAllConsultants()
        {
            List<Consultant> consultants = new List<Consultant>();
            foreach(object[] account_info in accounts.Values){
                if (!((User)account_info[2]).director){
                    consultants.Add(new Consultant((User)account_info[2]));
                }
            }
            return consultants;
        }

        private Schedule getEmptySchedule()
        {
            Schedule new_sched = new Schedule();
            Schedule master = getMasterAvalibility();

            string[] days = new string[master.monday.Length];
            for (int i = 0; i < master.monday.Length; i++)
            {
                days[i] = "";
            }

            new_sched.monday = days;
            new_sched.tuesday = days;
            new_sched.wednesday = days;
            new_sched.thursday = days;
            new_sched.friday = days;
            new_sched.saturday = days;
            new_sched.sunday = days;

            return new_sched;
        }
        private List<List<List<User>>> getEmptyScheduleForList()
        {
            List<List<List<User>>> new_sched = new List<List<List<User>>>();
            Schedule master = getMasterAvalibility();
            
            for (int i = 0; i < 7; i++)
            {
                List<List<User>> days = new List<List<User>>();
                for (int x = 0; x < master.monday.Length; x++)
                {
                    days.Add(new List<User>());
                }
                new_sched.Add(days);
            }

            return new_sched;
        }

        private List<List<List<User>>> ScheduleTrimmer1(List<List<List<User>>> shifts, bool count) {
            //will be the actual goal later
            int num_worker_goal = 4;
            int num_min_worker = 2;
            DirectorSettings director_settings = getDirectorSettings();

            List<List<int>> num_extra_workers = new List<List<int>>();
            for (int i = 0; i < shifts.Count; i++)
            {
                num_extra_workers.Add(new List<int>());
                foreach (List<User> shift in shifts[i].ToList())
                {
                    num_extra_workers[i].Add(shift.Count - num_worker_goal);
                }
            }

            for (int x = 0; x < num_extra_workers.Count; x++)
            {
                for (int y = 0; y < num_extra_workers[x].Count; y++)
                {
                    if (num_extra_workers[x][y] > 0)
                    {
                        int largest_number_of_shifts = 0;
                        int number_of_upperclassmen = 0;
                        List<Consultant> temp_kick_list = new List<Consultant>();

                        int current_extra_workers = num_extra_workers[x][y];

                        foreach (Consultant worker in shifts[x][y].ToList())
                        {
                            if (worker.numberOfShifts > int.Parse(worker.hoursPer) * 2)
                            {
                                temp_kick_list.Add(worker);
                            }
                            if (int.Parse(worker.yearsWorked) > 2)
                            {
                                number_of_upperclassmen++;
                            }
                        }
                            // Ages
                        if (director_settings.mix_ages)
                        {
                            if (count && number_of_upperclassmen == 1)
                            {
                                foreach (Consultant staff in temp_kick_list.ToList())
                                {
                                    if (temp_kick_list.Count - current_extra_workers > 0)
                                    {
                                        if (int.Parse(staff.yearsWorked) > 2)
                                        {
                                            temp_kick_list.Remove(staff);
                                        }
                                    }
                                }
                            }
                        }
                        if (director_settings.multiple_shifts)
                        {
                            foreach(Consultant staff in temp_kick_list.ToList())
                            {
                                if (temp_kick_list.Count - current_extra_workers > 0)
                                {
                                    if (y > 0)
                                    {
                                        if (y < shifts[x].Count - 1)
                                        {
                                            if (shifts[x][y - 1].Contains(staff) || shifts[x][y + 1].Contains(staff))
                                            {
                                                temp_kick_list.Remove(staff);
                                            }
                                        }
                                        else
                                        {
                                            if(shifts[x][y - 1].Contains(staff))
                                            {
                                                temp_kick_list.Remove(staff);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if(shifts[x][y + 1].Contains(staff))
                                        {
                                            temp_kick_list.Remove(staff);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach(Consultant staff in temp_kick_list.ToList())
                            {
                                if(temp_kick_list.Count - current_extra_workers > 0)
                                {
                                    if (y > 0)
                                    {
                                        if (y < shifts[x].Count - 1)
                                        {
                                            if (shifts[x][y - 1].Contains(staff) || shifts[x][y + 1].Contains(staff))
                                            {
                                                temp_kick_list.Remove(staff);
                                                current_extra_workers++;
                                                shifts[x][y].Remove(staff);
                                            }
                                        }
                                        else
                                        {
                                            if (shifts[x][y - 1].Contains(staff))
                                            {
                                                temp_kick_list.Remove(staff);
                                                current_extra_workers--;
                                                shifts[x][y].Remove(staff);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (shifts[x][y + 1].Contains(staff))
                                        {
                                            temp_kick_list.Remove(staff);
                                            current_extra_workers--;
                                            shifts[x][y].Remove(staff);
                                        }
                                    }
                                }
                            }
                        }

                        if (director_settings.multiple_majors)
                        {
                            //find major matches
                            foreach (Consultant staff in temp_kick_list)
                            {

                            }
                        }

                        while(temp_kick_list.Count > 0 && current_extra_workers > 0)
                        {
                            Consultant largest_gap_staff = temp_kick_list[0];
                            int largest_gap = 0;
                            foreach(Consultant staff in temp_kick_list.ToList())
                            {
                                if((staff.numberOfShifts - (int.Parse(staff.hoursPer) * 2)) > largest_gap)
                                {
                                    largest_gap_staff = staff;
                                    largest_gap = staff.numberOfShifts - (int.Parse(staff.hoursPer) * 2);
                                }
                            }
                                
                            current_extra_workers--;
                            largest_gap_staff.numberOfShifts--;
                            temp_kick_list.Remove(largest_gap_staff);
                            shifts[x][y].Remove(largest_gap_staff);
                        }

                        if(current_extra_workers > 0)
                        {
                            Random random = new Random();
                            for (int i = 0; i < current_extra_workers; i++)
                            {
                                int remove = random.Next(0, shifts[x][y].Count);
                                shifts[x][y].RemoveAt(remove);
                            }
                        }

                    }
                }
            }
            return shifts;
        }


        private DirectorSettings getDirectorSettings()
        {
            DirectorSettings director_settings = new DirectorSettings();
            director_settings.multiple_majors = true;
            director_settings.mix_ages = true;
            director_settings.multiple_shifts = true;
            return director_settings;
        }

    }
}

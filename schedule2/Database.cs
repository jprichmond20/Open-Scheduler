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
                    File.WriteAllText(json_file_name, json_text);
                }
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

        public Schedule createSchedule()
        {
            List<List<List<User>>> return_schedule_list = getEmptyScheduleForList();

            Schedule return_sched = getEmptySchedule();


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
                foreach (Consultant worker in consultant_list) {
                    for(int x = 0; x < hour_option_list.Count; x++) {
                        for(int y = 0; y < hour_option_list[0].Length; y++)
                        {
                            if(hour_option_list[x][y] == "")
                            {
                                if(worker.days[x][y] == "")
                                {
                                    return_schedule_list[x][y].Add(worker);
                                    worker.numberOfShifts += 1;
                                }
                            }
                        }
                    }
                }


                for Shift in range(len(Hour_OptionsList)):##Tries to reduce under SHIFT_MAXIMUM_WORKERS
                    ScheduleTrimmer1(Hour_OptionsList, Shift, Choices_List[4], True, Choices_List[0], Choices_List[1], Choices_List[2])


                priority = 3
                while (priority >= 1):#Tries to reduce to SHIFT_MINIMUM_WORKERS using priority
                    for Shift in range(len(Hour_OptionsList)):
                        if Hour_OptionsList[Shift].priority == priority:
                            ScheduleTrimmer1(Hour_OptionsList, Shift, Choices_List[3], False, Choices_List[0], Choices_List[1], Choices_List[2])
                    priority -= 1

                /*
                CreateOutputFile(Hour_OptionsList, WorkersList)#Creates the "Schedule.csv" file
                PrintErrorReport(Hour_OptionsList, WorkersList, Choices_List[4], Choices_List[3])#Prints Efficiencies to Shell
                */            
            }
            catch(Exception e) { Console.WriteLine(e); }


            return schedule;
        }


        private List<Consultant> getAllConsultants()
        {
            List<Consultant> consultants = new List<Consultant>();
            foreach(object[] account_info in accounts.Values){
                if (((User)account_info[2]).director){
                    consultants.Add((Consultant)account_info[2]);
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

            List<List<User>> days = new List<List<User>>();
            for (int i = 0; i < master.monday.Length; i++)
            {
                days.Add(new List<User>());
            }
            for (int i = 0; i < 7; i++)
            {
                new_sched.Add(days);
            }

            return new_sched;
        }

        private List<List<List<User>>> ScheduleTrimmer1(List<List<List<User>>> shifts, bool count) {
            //will be the actual goal later
            int num_worker_goal = 3;
            List<List<int>> num_extra_workers = new List<List<int>>();
            for(int i = 0; i < shifts.Count; i++)
            {
                num_extra_workers.Add(new List<int>());
                foreach (List<User> shift in shifts[i])
                {
                    num_extra_workers[i].Add(shift.Count - num_worker_goal);
                }
            }
          NumExtraWorkers = len(Hour_OptionsList[Shift].workerNames) - numWorkerGoal
          if (NumExtraWorkers > 0):
              LargestNumberOfShifts = 0
              NumberOfUpperClassmen = 0
              TempKickList =[]
              for worker in Hour_OptionsList[Shift].workerNames:
                  if worker.NumberOfShifts > worker.Hours_Wanted:
                      TempKickList.append(worker)##apending all workers scheduled for to many shifts
                      LargestNumberOfShifts = max(LargestNumberOfShifts, worker.NumberOfShifts)
                  if (worker.Year == "Senior" or worker.Year == "Junior"):
                      NumberOfUpperClassmen += 1

              # Ages
            if MIX_AGES:
                 if (CountUpper and NumberOfUpperClassmen == 1):##Removes upperclass if only one
                   for staff in TempKickList:
                      if (staff.Year == "Senior" or staff.Year == "Junior"):
                          TempKickList.remove(staff)

              # Consecutive Shifts
            if MULTIPLE_SHIFTS:
                  for staff in TempKickList:
                      if NumExtraWorkers > 0:
                          if staff in Hour_OptionsList[Shift - 1].workerNames or staff in Hour_OptionsList[min(Shift + 1, len(Hour_OptionsList) - 1)].workerNames:
                              if len(TempKickList) > NumExtraWorkers:
                                #Removes Staff from temp list
                                TempKickList.remove(staff)
              else:
                  for staff in TempKickList:
                    if NumExtraWorkers > 0:
                         if staff in Hour_OptionsList[Shift - 1].workerNames or staff in Hour_OptionsList[min(Shift + 1, len(Hour_OptionsList) - 1)].workerNames:
                            #Removes Staff from shift
                            NumExtraWorkers -= 1
                            staff.NumberOfShifts -= 1
                            TempKickList.remove(staff)
                            Hour_OptionsList[Shift].workerNames.remove(staff)

        # Mixing Majors
            matches_found = True
              if MIX_MAJORS:
                 while (len(TempKickList) > 0 and NumExtraWorkers> 0 and matches_found):
                    MostMatchesOverall = -1
                    CurrentLargestFieldWorker = BlankWorker


                    for staff in TempKickList:
                        MostMatches = -1
                        for FieldStudy in staff.Field_Of_Study:##Possible to have more than 1 major
                             MajorMatches = 0
                             for otherstaff in Hour_OptionsList[Shift].workerNames:
                                if FieldStudy in otherstaff.Field_Of_Study:
                                    MajorMatches += 1
                             if MajorMatches > MostMatches:
                              MostMatches = MajorMatches
                        if MostMatches >= MostMatchesOverall:
                          MostMatchesOverall = MostMatches
                          CurrentLargestFieldWorker = staff

                    if MostMatchesOverall > 1:#probably 1 and not 0
                        #Removes Staff from shift
                        NumExtraWorkers -= 1
                        CurrentLargestFieldWorker.NumberOfShifts -= 1
                        TempKickList.remove(CurrentLargestFieldWorker)
                        Hour_OptionsList[Shift].workerNames.remove(CurrentLargestFieldWorker)
                    else:
                        matches_found = False

              # Largest Differences
            while (len(TempKickList) > 0 and NumExtraWorkers> 0):
                CurrentLargestFieldWorker = BlankWorker
                biggest_diff = 0
                for staff in TempKickList:
                    if (staff.NumberOfShifts - staff.Hours_Wanted) > biggest_diff:
                        CurrentLargestFieldWorker = staff
                        biggest_diff = staff.NumberOfShifts - staff.Hours_Wanted

                # Removes Staff from shift
            NumExtraWorkers -= 1
                CurrentLargestFieldWorker.NumberOfShifts -= 1
                TempKickList.remove(CurrentLargestFieldWorker)
                Hour_OptionsList[Shift].workerNames.remove(CurrentLargestFieldWorker)
        }

    }
}

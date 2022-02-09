using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace schedule2
{
    internal class Database
    {
        private FileStream db_file;
        public Database()
        {
           db_file = File.Open("db.txt",FileMode.OpenOrCreate);
        }

        public CreateUser()
    }
}

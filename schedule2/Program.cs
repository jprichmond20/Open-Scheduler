using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schedule2
{
    internal static class Program
    {
        public static Database db = new Database();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //db.RegisterUser("admin", "admin", new Director());
            Application.Run(new SignIn());
        }
    }
}

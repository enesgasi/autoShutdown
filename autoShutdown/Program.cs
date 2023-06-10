using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace autoShutdown
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What do you want to do?: (shutdown, restart or cancel: )");
            string answer = Console.ReadLine();

            if (answer == "shutdown")
            {
                Console.WriteLine("After how many minutes do you want the computer to shut down?: ");
                int minutes = Convert.ToInt32(Console.ReadLine());
                int seconds = minutes * 60;

                Shutdown(seconds);

                Process.Start("shutdown", $"/s /f /t {seconds}");
            }
            else if (answer == "restart")
            {
                Restart();
            }
            else if (answer == "cancel")
            {
                Cancel();
            }
            else
            {
                Console.WriteLine("Error: Unvalid command. Restart the program.");
            }

            //Functions
            static void Shutdown(int time)
            {
                Process.Start("shutdown", $"/s /f /t {time}");
            }

            static void Restart()
            {
                Process.Start("shutdown", "/r");
            }

            static void Cancel()
            {
                Process.Start("shutdown", "/a");
            }
        }
    }
}
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
            programStart:
            Console.WriteLine
                (
                "What do you want to do?: \r\n1. Shutdown \r\n2. Restart \r\n3. Cancel active process"
                );
            int answer = Convert.ToInt32(Console.ReadLine());
            System.Type type = answer.GetType();

            while (answer != null)
            {
                if (answer == 1)
                {
                    Console.WriteLine("After how many minutes do you want the computer to shut down?: ");
                    int minutes = Convert.ToInt32(Console.ReadLine());
                    int seconds = minutes * 60;

                    Shutdown(seconds);
                    Console.Clear();
                    goto programStart;
                }
                else if (answer == 2)
                {
                    Console.WriteLine("After how many minutes do you want the computer to restart?: ");
                    int minutes = Convert.ToInt32(Console.ReadLine());
                    int seconds = minutes * 60;

                    Restart(seconds);
                    Console.Clear();
                    goto programStart;
                }
                else if (answer == 3)
                {
                    Cancel();
                    Console.Clear();
                    goto programStart;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error: Unvalid command.");                   
                    goto programStart;
                }

                //Functions
                static void Shutdown(int time)
                {
                    Process.Start("shutdown", $"/s /f /t {time}");
                }

                static void Restart(int time)
                {
                    Process.Start("shutdown", $"/r /t {time}");
                }

                static void Cancel()
                {
                    Process.Start("shutdown", "/a");
                }
            }
        }
    }
}
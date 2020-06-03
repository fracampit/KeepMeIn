using System;
using System.Runtime.InteropServices;

namespace KeepMeIn
{
    class Program
    {
        private const int Offset = 1;
        
        static void Main(string[] args)
        {
            // mark this app in a way that will force the screen to stay up
            // (similar to what happens when you play a long video)
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | 
                                          EXECUTION_STATE.ES_AWAYMODE_REQUIRED |
                                          EXECUTION_STATE.ES_DISPLAY_REQUIRED);

            // quit?
            var input = "";
            while (input.ToLowerInvariant() != "y")
            {
                Console.Clear();
                PrintMessages();
                input = Console.ReadLine();
            }
            
            Console.WriteLine("Quitting...");
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto,SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
        
        private static void PrintMessages()
        {
            Console.WriteLine("\n            ██╗  ██╗███████╗███████╗██████╗     ███╗   ███╗███████╗    ██╗███╗   ██╗\n            ██║ ██╔╝██╔════╝██╔════╝██╔══██╗    ████╗ ████║██╔════╝    ██║████╗  ██║\n            █████╔╝ █████╗  █████╗  ██████╔╝    ██╔████╔██║█████╗      ██║██╔██╗ ██║\n            ██╔═██╗ ██╔══╝  ██╔══╝  ██╔═══╝     ██║╚██╔╝██║██╔══╝      ██║██║╚██╗██║\n            ██║  ██╗███████╗███████╗██║         ██║ ╚═╝ ██║███████╗    ██║██║ ╚████║\n            ╚═╝  ╚═╝╚══════╝╚══════╝╚═╝         ╚═╝     ╚═╝╚══════╝    ╚═╝╚═╝  ╚═══╝\n                                                                                    \n");
            
            Console.WriteLine("This app will prevent your screen from locking itself up.");
            Console.WriteLine("Do you want to quit? (y/n)");
        }
    }
    
    [Flags]
    public enum EXECUTION_STATE :uint
    {
        ES_AWAYMODE_REQUIRED = 0x00000040,
        ES_CONTINUOUS = 0x80000000,
        ES_DISPLAY_REQUIRED = 0x00000002,
        ES_SYSTEM_REQUIRED = 0x00000001
        // Legacy flag, should not be used.
        // ES_USER_PRESENT = 0x00000004
    }
}
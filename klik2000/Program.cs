using System;

namespace klik2000
{
    static class Program
    {

        private const int DEFAULT_SLEEP_TIME = 30000;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            int sleepTime = FindSleepTimeFromArgs(Args);
            Klicker klicker = new Klicker(sleepTime);
        }

        private static int FindSleepTimeFromArgs(string[] Args)
        {
            if (Args.Length == 0)
            {
                return DEFAULT_SLEEP_TIME;
            }
            else
            {
                int result = 0;
                try
                {
                    result = Convert.ToInt32(Args[0]) * 1000;                    
                }
                catch
                {
                    result = DEFAULT_SLEEP_TIME;
                }

                return result;
            }
        }        
    }
}

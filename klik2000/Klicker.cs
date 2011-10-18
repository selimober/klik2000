using System;
using System.Threading;
using System.Windows.Forms;

namespace klik2000
{
    class Klicker
    {        
        private Thread clickingthread;
        private int sleepTime;

        public Klicker(int sleepTime)
        {
            this.sleepTime = sleepTime;
            clickingthread = new Thread(SleepAndClick);
            clickingthread.Start();
        }

        private void SleepAndClick()
        {            
            Thread.Sleep(sleepTime);
            DoMouseClick();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void DoMouseClick()
        {
            try
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
            catch (Exception ex) { showerrormessage(ex); }
        }

        void showerrormessage(Exception error)
        {
            MessageBox.Show("Error:  " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
}

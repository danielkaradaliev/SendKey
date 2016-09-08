/*namespace SendKey
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Threading;

    public class SendKey
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        [STAThread]
        static void Main()
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
            Console.WriteLine("Executing...");
            SendKeys.SendWait("{CAPSLOCK}");
        }
    }
}*/


namespace SendKey
{
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class SendKey
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

        static void Main()
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);
            
            while (true)
            {
                SendKeys.SendWait("{CAPSLOCK}");                

                Thread.Sleep(5000);
            }
        }
    }
}
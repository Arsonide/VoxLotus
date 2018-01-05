using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VoxLotus
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += GlobalUnhandledExceptionHandler;
            Application.ThreadException += GlobalThreadExceptionHandler;

            Process[] instances = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location));

            if (instances.Length > 1)
            {
                Process first = instances.OrderBy(e => e.StartTime).First();
                IntPtr hWnd = first.MainWindowHandle;

                if (hWnd != IntPtr.Zero)
                {
                    SetForegroundWindow(hWnd);
                    ShowWindow(hWnd, 9);
                }

                MessageBox.Show(@"There's already an instance of Vox Lotus running!", @"Vox Lotus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Context1());
        }

        private static void DumpException(Exception ex)
        {
            using (var writer = new StreamWriter(Utilities.ErrorLogLocation, true))
            {
                writer.WriteLine("Message :" + ex.Message + Environment.NewLine +
                                 "Exception :" + ex.InnerException + Environment.NewLine +
                                 "StackTrace :" + ex.StackTrace + Environment.NewLine +
                                 "Date :" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

        private static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception)e.ExceptionObject;
            DumpException(ex);
        }

        private static void GlobalThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            DumpException(ex);
        }

        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}

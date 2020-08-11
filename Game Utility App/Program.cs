using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GameUtilityApp
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                int cnt = 0;
                Process[] procs = Process.GetProcesses();
                foreach(Process p in procs)
                {
                    if (p.ProcessName.Equals("Game Utility App") == true) cnt++;
                }
                if (cnt > 1)
                {
                    IntPtr hwnd = FindWindow(null, "Game Utility App");
                    if (!hwnd.Equals(IntPtr.Zero))
                    {
                        ShowWindowAsync(hwnd, SW_SHOWNORMAL);
                        SetForegroundWindow(hwnd);
                    }
                    return;
                }
                else
                {
                    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Main());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "실행 중 오류가 발생하였습니다.");
            }

            
        }
        
        // .NET 4.0 이상
        static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            var name = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";

            var resources = thisAssembly.GetManifestResourceNames().Where(s => s.EndsWith(name));
            if (resources.Count() > 0)
            {
                string resourceName = resources.First();
                using (Stream stream = thisAssembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        byte[] assembly = new byte[stream.Length];
                        stream.Read(assembly, 0, assembly.Length);
                        //Console.WriteLine("Dll file load : " + resourceName);
                        return Assembly.Load(assembly);
                    }
                }
            }
            return null;
        }
        
    }
}

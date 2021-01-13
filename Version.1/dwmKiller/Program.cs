using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace dwmKiller
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowsVerCheck();
            Process[] processesList = Process.GetProcessesByName("Game Utility App");

            if (processesList.Length > 0)
            {
                int time = Convert.ToInt32(DateTime.Now.ToString("HHmmss"));
                int endTime = time + 5;
                for (time = Convert.ToInt32(DateTime.Now.ToString("HHmmss")); time < endTime; time = Convert.ToInt32(DateTime.Now.ToString("HHmmss")))
                {
                    Killer();
                }
            }
            else
            {
                MessageBox.Show("잘못된 접근입니다.", "실행 오류");
                Application.Exit();
            }
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Exit();
        }

        private static void Killer()
        {
            Process[] processList = Process.GetProcessesByName("dwm");
            try
            {
                if (processList.Length > 0)
                {
                    processList[0].Kill();
                }

            }
            catch (Exception)
            {
            }

        }


        private static void WindowsVerCheck()
        {
            OperatingSystem osVer = Environment.OSVersion;
            if(osVer.Version.Major != 6 || osVer.Version.Minor != 1)
            {
                MessageBox.Show("Windows 7에서만 지원하는 기능입니다.", "Windows 버전 오류");
                Application.Exit();
            }
        }
    
    }
}

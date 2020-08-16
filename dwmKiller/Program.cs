using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            int time = Convert.ToInt32(DateTime.Now.ToString("HHmmss"));
            int endTime = time + 5;
            for (time = Convert.ToInt32(DateTime.Now.ToString("HHmmss")); time < endTime; time = Convert.ToInt32(DateTime.Now.ToString("HHmmss")))
            {
                Killer();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
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

    
    }
}

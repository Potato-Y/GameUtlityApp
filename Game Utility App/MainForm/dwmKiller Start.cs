using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp
{
    class dwmKiller_Start
    {
        static string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\Documents\Game Utility App";

        public void StartCheck()
        {
            int dwmKillerRelease = 20200816;

            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("Game Utility App", true);
            if (reg.OpenSubKey("setting") == null || Convert.ToString(reg.OpenSubKey("setting").GetValue("dwmKiller ver")) == "")
            {
                reg.SetValue("dwmKiller ver", dwmKillerRelease);
                Download_dwmKiller();
            }
            else if (Convert.ToInt32(reg.OpenSubKey("setting").GetValue("dwmKiller ver")) != dwmKillerRelease)
            {
                Download_dwmKiller();
            }
            else if(Convert.ToInt32(reg.OpenSubKey("setting").GetValue("dwmKiller ver")) == dwmKillerRelease)
            {
                System.Diagnostics.Process.Start(path + @"\dwmKiller.exe");
            }
            reg.Close();

        }

        private void Download_dwmKiller()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            DirectoryInfo Documents_App_Directory = new DirectoryInfo(path);
            if (Documents_App_Directory.Exists == false)
            {
                Documents_App_Directory.Create();
            }
           

            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://github.com/Potato-Y/Game-Utility-App/releases/download/dwmKiller_v1.0.0/dwmKiller.exe", path + @"\dwmKiller.exe");
            System.Diagnostics.Process.Start(path + @"\dwmKiller.exe");

        }
    }
}

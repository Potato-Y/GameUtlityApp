using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameUtilityApp.Essential.DB_Control;
using System.Drawing.Text;
using System.Drawing;
using System.Reflection;
using System.Security.Principal;
using System.Diagnostics;

namespace GameUtilityApp.Essential.Class
{
    class BasicCheck
    {

        public void EssentialCheck()
        {
            DB_Check();
            FontCheck();
        }

        public void DB_Check()
        {
            Main_Setting_DB mainDB = new Main_Setting_DB();
            mainDB.FileCheck();
        }

        public void FontCheck()
        {
            if (IsFontInstalled("나눔고딕") == false) //폰트가 있는지 없는지 확인
            {
                GetAdministrator();
            }
        }

        public void GetAdministrator() //관리자 권한이 있는지 확인 후 없으면 관리자 권한 얻기
        {
            if (!IsRunningAsAdministrator())
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(Assembly.GetEntryAssembly().CodeBase);
                {
                    var withBlock = processStartInfo;
                    withBlock.UseShellExecute = true;
                    withBlock.Verb = "runas";
                    Process.Start(processStartInfo);
                    Application.Exit();
                }


            }
        }

        private bool IsRunningAsAdministrator() //관리자 권한 상태 확인
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private bool IsFontInstalled(string fontName) //폰트가 있는지 확인하는 함수
        {
            InstalledFontCollection collection = new InstalledFontCollection();

            foreach (FontFamily fontFamily in collection.Families)
            {
                if (fontFamily.Name.Equals(fontName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

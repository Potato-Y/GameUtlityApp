using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameUtilityApp.Essential.DB_Control;
using GameUtilityApp.Essential.Language;
using GameUtilityApp.Essential.Forms;
using System.Drawing.Text;
using System.Drawing;
using System.Reflection;
using System.Security.Principal;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Net.Http;
using System.Net;

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
                if(IsRunningAsAdministrator() == false)
                {
                    if ((MessageBox.Show(StringLib.ERROR_2, StringLib.ERROR, MessageBoxButtons.YesNo) == DialogResult.Yes)) //폰트를 설치한다면 관리자 권한을 요청하며 재실행한다.
                    {
                        GetAdministrator();
                        FontSetup fm = new Forms.FontSetup();
                        fm.ShowDialog();
                    }
                    else //거부시 프로그램이 종료된다.
                    {
                        Application.Exit();
                    }
                }


            }
        }

        public void GetAdministrator() //관리자 권한이 있는지 확인 후 없으면 관리자 권한 얻기
        {
            if (!IsRunningAsAdministrator())
            {
                try
                {
                    ProcessStartInfo procInfo = new ProcessStartInfo();
                    procInfo.UseShellExecute = true;
                    procInfo.FileName = Application.ExecutablePath;
                    procInfo.WorkingDirectory = Environment.CurrentDirectory;
                    procInfo.Verb = "runas";
                    Process.Start(procInfo);
                }
                catch (Exception ex)
                {
                    // 사용자가 프로그램을 관리자 권한으로 실행하기를 원하지 않을 경우에 대한 처리
                    MessageBox.Show(ex.Message);
                    Application.Exit();
                    return;
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

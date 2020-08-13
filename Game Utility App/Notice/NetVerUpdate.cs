using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Notice
{
    public partial class NetVerUpdate : Form
    {
        public NetVerUpdate()
        {
            InitializeComponent();
        }

        private void Setup472(object sender, EventArgs e)
        {
            MessageBox.Show("Microsoft 홈페이지로 연결합니다.", "홈페이지에서 설치 파일 다운");
            System.Diagnostics.Process.Start("https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net48-web-installer");
        }

        private void WinUpdate_x86(object sender, EventArgs e)
        {
            MessageBox.Show("Windows 7용 보안 업데이트를 다운로드하고 설치하세요.", "안내");
            System.Diagnostics.Process.Start("https://www.microsoft.com/ko-kr/download/details.aspx?id=39110");
        }
        private void WinUpdate_x64(object sender, EventArgs e)
        {
            MessageBox.Show("Windows 7용 보안 업데이트를 다운로드하고 설치하세요.", "안내");
            System.Diagnostics.Process.Start("https://www.microsoft.com/ko-kr/download/details.aspx?id=39115");
        }


        private void WinUpdate_other(object sender, EventArgs e)
        {
            MessageBox.Show("본인에게 맞는 Windows 용 보안 업데이트를 다운로드하고 설치하세요.", "안내");
            System.Diagnostics.Process.Start("https://support.microsoft.com/ko-kr/help/2813430/an-update-is-available-that-enables-administrators-to-update-trusted-a");
        }

        private void netvercheck(object sender, EventArgs e)
        {
            String sProcess;

            if (Environment.Is64BitOperatingSystem == true)
            {
                sProcess = "64 bit";
            }
            else
            {
                sProcess = "32 bit";
            }
            label6.Text = sProcess;

            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    label4.Text = CheckFor45PlusVersion((int)ndpKey.GetValue("Release"));
                }
                else
                {
                    label4.Text = ".NET Framework Version이 4.5 혹은 설치되어 있지 않음.";
                }
            }


            string CheckFor45PlusVersion(int releaseKey)
            {
                if (releaseKey >= 528040)
                    return "4.8 or later";
                if (releaseKey >= 461808)
                    return "4.7.2";
                if (releaseKey >= 461308)
                    return "4.7.1";
                if (releaseKey >= 460798)
                    return "4.7";
                if (releaseKey >= 394802)
                    return "4.6.2";
                if (releaseKey >= 394254)
                    return "4.6.1";
                if (releaseKey >= 393295)
                    return "4.6";
                if (releaseKey >= 379893)
                    return "4.5.2";
                if (releaseKey >= 378675)
                    return "4.5.1";
                if (releaseKey >= 378389)
                    return "4.5";

                return "No 4.5 or later version detected";
            }
        }
        private void form_Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

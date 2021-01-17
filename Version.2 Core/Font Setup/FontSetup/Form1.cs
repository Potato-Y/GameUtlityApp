using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FontSetup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\Downloads";

        void fileDownloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            RegisterFont(path + @"\NanumGothic.ttf");
            MessageBox.Show("설치가 완료되었습니다.\nInstallation is complete.");
            this.Close();
            Application.Exit();
        }

        void fileDownloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void AppStart(object sender, EventArgs e)
        {

            try
            {
                using (WebClient fileDownloader = new WebClient())
                {
                    string tmpSetupPath = Path.Combine(path, "NanumGothic.ttf");
                    fileDownloader.DownloadProgressChanged += fileDownloader_DownloadProgressChanged; // 다운로드 진행 상황 표시하기 위해
                    fileDownloader.DownloadFileCompleted += fileDownloader_DownloadFileCompleted;        // 다운로드가 완료되면 실행
                    fileDownloader.DownloadFileAsync(new Uri("https://github.com/Potato-Y/Game-Utility-App/releases/download/font/NanumGothic.ttf"), tmpSetupPath, tmpSetupPath);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("다운로드 중 오류가 발생하였습니다.");
                return;
            }
        }


        [DllImport("gdi32.dll")]
        private static extern int AddFontResource(String fontFilePath);
        private static string _keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts";

        private static void RegisterFont(string sourceFontFilePath)
        {
            string targetFontFileName = Path.GetFileName(sourceFontFilePath);
            string targetFontFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), targetFontFileName);
            
            if (!File.Exists(targetFontFilePath))
            {
                File.Copy(sourceFontFilePath, targetFontFilePath);
                PrivateFontCollection collection = new PrivateFontCollection();
                collection.AddFontFile(targetFontFilePath);
                string actualFontName = collection.Families[0].Name;
                AddFontResource(targetFontFilePath);
                Registry.SetValue(_keyName, actualFontName, targetFontFileName, RegistryValueKind.String);
            }
        }
    }
}

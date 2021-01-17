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
using System.Net.Http;
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

            string message = "설치가 완료되었습니다. 폰트 오픈소스 라이센스를 확인하시겠습니까?\nInstallation is complete. Would you like to check the font open source license?";
            if (MessageBox.Show(message, "Complete",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                var client = new HttpClient(); //웹으로부터 다운로드 받을 수 있는 클래스의 인스턴스를 제작 한다.
                var response = client.GetAsync("https://raw.githubusercontent.com/Potato-Y/Game-Utility-App/master/Open%20source%20used/Font%20License.md").Result; //웹으로부터 다운로드 
                var html = response.Content.ReadAsStringAsync().Result; //다운로드 결과를 html 로 받아 온다. 

                System.IO.File.WriteAllText(path + @"\Font License.html", html, Encoding.Default);
                System.Diagnostics.Process.Start(path + @"\Font License.html");
            }
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
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Essential.Forms
{
    public partial class FontSetup : Form
    {
        public FontSetup()
        {
            InitializeComponent();
        }

        private void FontDownload()
        {
            try
            {
                string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\AppData\Local\Game Utility App";

                DirectoryInfo Documents_App_Directory = new DirectoryInfo(path);
                if (Documents_App_Directory.Exists == false)
                {
                    Documents_App_Directory.Create();
                }
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;


                WebClient webClient = new WebClient();
                webClient.DownloadFile("https://github.com/Potato-Y/Game-Utility-App/releases/download/font/NanumGothic.ttf", path + @"\Font.ttf");


                var client = new HttpClient(); //웹으로부터 다운로드 받을 수 있는 클래스의 인스턴스를 제작 한다.
                var response = client.GetAsync("https://raw.githubusercontent.com/Potato-Y/Game-Utility-App/master/Open%20source%20used/Font%20License.md").Result; //웹으로부터 다운로드 
                var html = response.Content.ReadAsStringAsync().Result; //다운로드 결과를 html 로 받아 온다. 

                System.IO.File.WriteAllText(path + @"\Font License.html", html, Encoding.Default);

            }
            catch (Exception)
            {
                MessageBox.Show("폰트를 설치할 수 없습니다.");
                Application.Exit();
            }
        }
    }
}

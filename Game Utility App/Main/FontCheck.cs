using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp
{
    class FontCheck
    {
        public void FontFileCheck()
        {
            if(IsFontInstalled("나눔스퀘어라운드 Regular") != true)
            {
                if(MessageBox.Show("폰트가 설치되어 있지 않습니다. 프로그램 정책에 의해 '나눔스퀘어라운드' 글꼴이 설치되어 있어야 합니다. 폰트를 설치하고 다시 실행 부탁드립니다.\r\n글꼴을 다운로드하시겠습니까?","폰트가 없습니다.", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\Documents\Game Utility App";

                        DirectoryInfo Documents_App_Directory = new DirectoryInfo(path);
                        if (Documents_App_Directory.Exists == false)
                        {
                            Documents_App_Directory.Create();
                        }
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;


                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://github.com/Potato-Y/Game-Utility-App/releases/download/font/NanumSquareRoundR.ttf", path + @"\Font.ttf");
                        System.Diagnostics.Process.Start(path + @"\Font.ttf");


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
                Application.Exit();
            }
           
        }
        public bool IsFontInstalled(string fontName)

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

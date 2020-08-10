using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateClient
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        

        private void Main_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            label2.Text = "";

            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                var client = new HttpClient(); //웹으로부터 다운로드 받을 수 있는 클래스의 인스턴스를 제작 한다.
                var response = client.GetAsync("https://raw.githubusercontent.com/Potato-Y/Game-Utility-App/master/release/Release%20Notes.md").Result; //웹으로부터 다운로드 
                var html = response.Content.ReadAsStringAsync().Result; //다운로드 결과를 html 로 받아 온다. 
                var replacement = html.Replace("<br>", "\r\n");
                textBox1.Text = Convert.ToString(replacement);
            }
            catch (Exception)
            {
                textBox1.Text = "업데이트 정보를 불러오는 중에 문제가 생겼습니다...";
            }


        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.ControlBox = false;
            button1.Enabled = false;
            this.ActiveControl = label1;
            try
            {
                using (WebClient fileDownloader = new WebClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                    label2.Text = "파일 다운로드를 시작";
                    var client = new HttpClient(); //웹으로부터 다운로드 받을 수 있는 클래스의 인스턴스를 제작 한다.
                    var server_check_response = client.GetAsync("https://github.com/Potato-Y/Game-Utility-App/blob/master/release/release%20guide.md").Result; //웹으로부터 다운로드 
                    var html = server_check_response.Content.ReadAsStringAsync().Result; //다운로드 결과를 html 로 받아 온다.
                    

                    var file_check_match = Regex.Match(html, "업데이트 파일 주소 :.+?입"); //정규식을 사용해서 위의 문장과 동일한 패턴을 가져온다.
                    string link_result = file_check_match.Value; //캡쳐 된 내용을 가져온다.
                    string dataLink = link_result.Substring(12, link_result.Length - 13);


                    string tmpSetupPath = Path.Combine(Application.StartupPath, "Game Utility App.exe");
                    fileDownloader.DownloadProgressChanged += fileDownloader_DownloadProgressChanged; // 다운로드 진행 상황 표시하기 위해
                    fileDownloader.DownloadFileCompleted += fileDownloader_DownloadFileCompleted;        // 다운로드가 완료되면 실행
                    fileDownloader.DownloadFileAsync(new Uri(dataLink), tmpSetupPath, tmpSetupPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex, "오류");
                Application.Exit();
            }
        }

        void fileDownloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                label2.Text = "다운로드 완료";
                string tmpSetupPath = e.UserState.ToString();
                Process.Start(tmpSetupPath);
            }
            catch (Exception)
            {
                MessageBox.Show("업데이트에 실패하였습니다.");
            }
            Application.Exit();
            this.Close();
        }

        void fileDownloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

    }
}

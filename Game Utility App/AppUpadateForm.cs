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

namespace GameUtilityApp.Properties
{
    public partial class AppUpadateForm : Form
    {
        public AppUpadateForm()
        {
            InitializeComponent();
        }

        private void AppUpadate(object sender, EventArgs e)
        {
            this.ActiveControl = progressBar1;
            try
            {
                using(WebClient fileDownloader=new WebClient())
                {
                    textBox1.Text += "클라이언트 주소를 검색합니다.";
                    this.textBox1.SelectionStart = textBox1.Text.Length;
                    this.textBox1.ScrollToCaret();

                    var client = new HttpClient(); //웹으로부터 다운로드 받을 수 있는 클래스의 인스턴스를 제작 한다.
                    var server_check_response = client.GetAsync("https://github.com/Potato-Y/Game-Utility-App/blob/master/release/release%20guide.md").Result; //웹으로부터 다운로드 
                    var html = server_check_response.Content.ReadAsStringAsync().Result; //다운로드 결과를 html 로 받아 온다.


                    var file_check_match = Regex.Match(html, "클라이언트 다운주소 :.+?입"); //정규식을 사용해서 위의 문장과 동일한 패턴을 가져온다.
                    string link_result = file_check_match.Value; //캡쳐 된 내용을 가져온다.
                    string clientLink = link_result.Substring(12, link_result.Length - 13);

                    textBox1.Text += "업데이트 클라이언트 다운로드를 시작합니다.";
                    this.textBox1.SelectionStart = textBox1.Text.Length;
                    this.textBox1.ScrollToCaret();
                    string tmpSetupPath = Path.Combine(Application.StartupPath, "UpdateClient.exe");
                    fileDownloader.DownloadProgressChanged += fileDownloader_DownloadProgressChanged;
                    fileDownloader.DownloadFileCompleted += fileDownloader_DownloadFileComplated;
                    fileDownloader.DownloadFileAsync(new Uri(clientLink), tmpSetupPath, tmpSetupPath);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(""+ex);
                System.Diagnostics.Process.Start("https://cafe.naver.com/checkmateclub");
                Application.Exit();
            }
        }
        void fileDownloader_DownloadFileComplated(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                string tmpSetupPath = e.UserState.ToString();
                textBox1.Text += "\r\n업데이트 클라이언트 다운로드 완료\r\n업데이트 클라이언트를 실행합니다.";
                this.textBox1.SelectionStart = textBox1.Text.Length;
                this.textBox1.ScrollToCaret();
                System.Diagnostics.Process.Start(tmpSetupPath);
                //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("업데이트 클라이언트가 실행되지 못하였습니다.");
                Application.Exit();
            }
            
        }
        void fileDownloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}

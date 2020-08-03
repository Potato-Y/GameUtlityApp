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
            try
            {
                using(WebClient fileDownloader=new WebClient())
                {
                    textBox1.Text += "클라이언트 주소를 검색합니다.";
                    
                    var client = new HttpClient();
                    var server_check_response = client.GetAsync("https://github.com/Potato-Y/Game-Utility-App/blob/master/release/release%20guide.md").Result;
                    var html = server_check_response.Content.ReadAsStringAsync().Result; 

                    var file_check_match = Regex.Match(html, "클라이언트 다운주소 :.+?입"); 
                    string link_result = file_check_match.Value;
                    string clientLink = link_result.Substring(15, link_result.Length - 16);

                    textBox1.Text += "업데이트 클라이언트 다운로드를 시작합니다.";
                    string tmpSetupPath = Path.Combine(Application.StartupPath, "UpdateClient.exe");
                    fileDownloader.DownloadProgressChanged += fileDownloader_DownloadProgressChanged;
                    fileDownloader.DownloadFileCompleted += fileDownloader_DownloadFileComplated;
                    fileDownloader.DownloadFileAsync(new Uri(clientLink), tmpSetupPath, tmpSetupPath);
                }
            }catch(Exception ex)
            {
                textBox1.Text += "오류 : " + ex.Message;
                Process.Start("https://cafe.naver.com/checkmateclub");
                Application.Exit();
            }
        }
        void fileDownloader_DownloadFileComplated(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                string tmpSetupPath = e.UserState.ToString();
                textBox1.Text += "\r\n업데이트 클라이언트 다운로드 완료\r\n업데이트 클라이언트를 실행합니다.";
                Process.Start(tmpSetupPath);
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

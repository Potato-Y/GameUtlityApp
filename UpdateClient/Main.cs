using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            this.ActiveControl = label1;
            try
            {
                using (WebClient fileDownloader = new WebClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                    label2.Text = "파일 다운로드를 시작";
                    string tmpSetupPath = Path.Combine(Application.StartupPath, "Game Utility App.exe");
                    fileDownloader.DownloadProgressChanged += fileDownloader_DownloadProgressChanged; // 다운로드 진행 상황 표시하기 위해
                    fileDownloader.DownloadFileCompleted += fileDownloader_DownloadFileCompleted;        // 다운로드가 완료되면 실행
                    fileDownloader.DownloadFileAsync(new Uri("https://github.com/Potato-Y/Game-Utility-App/releases/download/v0.1.4/updatedata.exe"), tmpSetupPath, tmpSetupPath);
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

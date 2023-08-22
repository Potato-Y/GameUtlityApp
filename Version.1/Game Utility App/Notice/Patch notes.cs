using System;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace GameUtilityApp.Notice
{
    public partial class Patch_notes : Form
    {
        public Patch_notes()
        {
            InitializeComponent();
        }

        private void Patch_note_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;

            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                
                var client = new HttpClient(); //웹으로부터 다운로드 받을 수 있는 클래스의 인스턴스를 제작 한다.
                var response = client.GetAsync("https://potato-y.github.io/Game-Utility-App/api/release/old/note/").Result; //웹으로부터 다운로드 
                var html = response.Content.ReadAsStringAsync().Result; //다운로드 결과를 html 로 받아 온다. 
                var replacement = html.Replace("<br>", "\r\n");
                textBox1.Text = Convert.ToString(replacement);
            }
            catch (Exception)
            {
                textBox1.Text = "업데이트 정보를 불러오는 중에 문제가 생겼습니다...";
            }


        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

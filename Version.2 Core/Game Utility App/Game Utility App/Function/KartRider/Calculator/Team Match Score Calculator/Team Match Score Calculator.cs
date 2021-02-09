using GameUtilityApp.Essential.Class;
using GameUtilityApp.Essential.Language;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Function.Calculator.Team_Match_Score_Calculator
{
    public partial class Team_Match_Score_Calculator : Form
    {
        /* 채널 별 코드
         * 매빠 개인전 speedIndiFastest
         * 매빠 팀전 speedTeamFastest
         * 빠름 개인전 speedIndiFast 
         * 빠름 팀전 speedTeamFast 
         * 무부 개인전 speedIndiInfinit 
         * 무부 팀전 speedTeamInfinit 
         * 가빠템 개인전 itemNewItemIndiFastest2Enchant 
         * 가빠템 팀전 itemNewItemTeamFastest2Enchant 
         * 보통템 개인전 itemNewItemIndi 
         * 보통템 팀전 itemNewItemTeam 
         */


        public Team_Match_Score_Calculator()
        {
            InitializeComponent();
            this.Text = StringLib.Title_1;
        }

        /// <summary>
        /// 트래킹 스레드 미리 만들어두기
        /// </summary>
        Thread TrackingThread;

        int myScore = 0; //우리팀 점수
        int relativeScore = 0; //상대팀 점수
        private void buttonTracking_Click(object sender, EventArgs e)
        {
            buttonTrackingStart.Enabled = false;
            textBoxNickname.ReadOnly = true;
            textBoxState.Text = textBoxNickname.Text + "유저의 매칭 정보를 트래킹합니다.\r\n마지막 정보를 불러옵니다. 점수에 포함되지 않습니다.";
            textboxScroll();
            myScore = 0; //점수 초기화
            relativeScore = 0; //점수 초기화
            scoreSet();

            TrackingThread = new Thread(new ThreadStart(Tracking));
            TrackingThread.Start();
        }

        string accessId = "";
        string endTime = "";

        private void Tracking()
        {
            //제일 먼저 기본 자료 가져오기.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            string responseText = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.nexon.co.kr/kart/v1.0/users/nickname/" + textBoxNickname.Text);
                request.Method = "GET";
                request.Timeout = 10 * 1000;
                request.Headers.Add("Authorization", new ThisGET().OpenApiKey());

                using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
                {
                    HttpStatusCode status = resp.StatusCode;

                    Stream respStream = resp.GetResponseStream();
                    using (StreamReader sr = new StreamReader(respStream))
                    {
                        responseText = sr.ReadToEnd();
                    }
                }
                JObject json = JObject.Parse(responseText);
                JToken jToken = json["accessId"];
                accessId = (string)jToken;
            }
            catch (WebException)
            {
                if (textBoxState.Text.Length != 0) textBoxStateTextAdd("\r\n");
                textBoxStateTextAdd("유저 정보가 확인되지 않습니다.");
                accessId = "NOT FOUND";
            }

            if (accessId.Equals("NOT FOUND")) return;

            //문제시 여기까지 못 옴. 인제 기본 정보 수집
            try
            {
                string url = "https://api.nexon.co.kr/kart/v1.0/users/" + accessId + "/matches?start_date=&end_date=&offset=&limit=1&match_types=";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Timeout = 10 * 1000;
                request.Headers.Add("Authorization", new ThisGET().OpenApiKey());

                using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
                {
                    HttpStatusCode status = resp.StatusCode;

                    Stream respStream = resp.GetResponseStream();
                    using (StreamReader sr = new StreamReader(respStream))
                    {
                        responseText = sr.ReadToEnd();
                    }
                }
                JObject json = JObject.Parse(responseText);


                MessageBox.Show((string)j3);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex + "");
            }

            while (true)
            {

            }

        }

        private void textBoxStateTextAdd(string msg)
        {
            textBoxState.BeginInvoke(new Action(() => textBoxState.Text += msg));
            textBoxState.BeginInvoke(new Action(() => this.textBoxState.SelectionStart = textBoxState.Text.Length));
            textBoxState.BeginInvoke(new Action(() => this.textBoxState.ScrollToCaret()));
        }

        private void textboxScroll()
        {
            textBoxState.SelectionStart = textBoxState.Text.Length;
            textBoxState.ScrollToCaret();
        }
        
        private void scoreSet()
        {
            labelMyScore.Text = myScore.ToString();
            labelRelativeScore.Text = relativeScore.ToString();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            TrackingThread.Abort();
            buttonTrackingStart.Enabled = true;
            textBoxNickname.ReadOnly = false;
        }

        private void buttonMyScoreP_Click(object sender, EventArgs e)
        {
            myScore++;
            scoreSet();
        }

        private void buttonRelativeScoreP_Click(object sender, EventArgs e)
        {
            relativeScore++;
            scoreSet();
        }

        private void buttonMyScoreM_Click(object sender, EventArgs e)
        {
            if (myScore > 0)
            {
                myScore--;
                scoreSet();
            }
        }

        private void buttonRelativeM_Click(object sender, EventArgs e)
        {
            if (relativeScore > 0)
            {
                relativeScore--;
                scoreSet();
            }
        }
    }
}

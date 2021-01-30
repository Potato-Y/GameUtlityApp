using GameUtilityApp.Essential.Class;
using GameUtilityApp.Essential.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Function.KartRider.Nickname_Tracker
{
    public delegate void DataGetEventHandler(bool type, string nickname, string accessID); //delegate 선언

    public partial class Add_my_nickname : Form
    {
        static string accessID = "";

        public Add_my_nickname()
        {
            InitializeComponent();
            buttonCancel.Text = StringLib.Cancel;
            buttonSave.Text = StringLib.save;
            label1.Text = StringLib.Message_4;
        }

        public DataGetEventHandler DataSendEvent;
        
        private void Add_my_nickname_Load(object sender, EventArgs e)
        {
            panelSaveCancel.Left = (this.ClientSize.Width - panelSaveCancel.Width) / 2; //저장, 취소 버튼 위치 재 설정
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DataSendEvent(true, textBox1.Text.ToString(), accessID); //정상처리로 true, 유저 이름
            this.Close();
        }

        bool saveButton = false;
        private void buttonUserCheck_Click(object sender, EventArgs e)
        {
            
            string responseText = string.Empty;
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.nexon.co.kr/kart/v1.0/users/nickname/"+textBox1.Text);
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

                var capture = Regex.Match(responseText, "\"accessId\":\".+?\"");
                accessID = capture.Value.Replace("\"accessId\":\"", "").Replace("\"", "");
                label1.Visible = true;
                buttonSave.Enabled = true;
            }
            catch (WebException)
            {
                accessID = "NULL";
                MessageBox.Show(StringLib.Message_3,StringLib.Message);
                buttonSave.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show(StringLib.ERROR, StringLib.ERROR);
            }
            finally
            {
                saveButton = true;
            }
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            buttonSave.Enabled = false;
            label1.Visible = false;
            saveButton = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DataSendEvent(false, textBox1.Text.ToString(), accessID);
            this.Close();
        }

        private void Add_my_nickname_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saveButton)
            {
                DataSendEvent(false, textBox1.Text.ToString(), accessID);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Space))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
    }
}
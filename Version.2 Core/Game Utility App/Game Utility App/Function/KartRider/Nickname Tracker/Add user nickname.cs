using GameUtilityApp.Essential.Class;
using GameUtilityApp.Essential.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
    public partial class User_NickName_Add : Form
    {
        public User_NickName_Add()
        {
            InitializeComponent();
        }

        private void User_NickName_Add_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            buttonSave.Left = (this.ClientSize.Width - buttonSave.Width) / 2;
        }

        static string accessID = "";

        private void buttonUserCheck_Click(object sender, EventArgs e)
        {
            string responseText = string.Empty;
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.nexon.co.kr/kart/v1.0/users/nickname/" + textBox1.Text);
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

                using (SQLiteConnection conn = new SQLiteConnection(new NickName_Tracker_DB_set().GetstrConn())) //중복 저장 확인
                {
                    conn.Open(); //DB 연결

                    string sqlCommand = "";

                    sqlCommand += "SELECT COUNT(*) FROM `Friend nickname` WHERE `access ID`=\"" + accessID + "\"";

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            rdr.Read();
                            int count = Convert.ToInt32(rdr["COUNT(*)"].ToString());

                            if (count > 0)
                            {
                                toolStripStatusLabel1.Text = StringLib.Message_5;
                                buttonSave.Enabled = false;
                                return;
                            }
                        }
                    }

                    conn.Close();
                }

                buttonSave.Enabled = true;
                toolStripStatusLabel1.Text = StringLib.Message_4;
            }
            catch (WebException)
            {
                accessID = null;
                toolStripStatusLabel1.Text = StringLib.Message_3;
                buttonSave.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show(StringLib.ERROR, StringLib.ERROR);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Space))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            buttonSave.Enabled = false;
            toolStripStatusLabel1.Text = "";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(new NickName_Tracker_DB_set().GetstrConn())) //새로운 유저의 ID로 교체
                {
                    conn.Open(); //DB 연결

                    string sqlCommand="";

                    sqlCommand += "INSERT INTO `Friend nickname` (`access ID`, `user nickname`,`first nickname`, `memo`) VALUES (\"" + accessID + "\",\"" + textBox1.Text + "\",\"" + textBox1.Text + "\",\"" + textBox2.Text + "\");";

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(StringLib.ERROR_1+ex, StringLib.ERROR); //저장 중 에러 발생
                this.Close();
            }
            this.Close();
        }
    }
}

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
    public partial class Nickname_Tracker : Form
    {
        public Nickname_Tracker()
        {
            InitializeComponent();
        }

        private void Nickname_Tracker_Load(object sender, EventArgs e)
        {
            DB_Check();
            MyNameCheck();
        }

        private void DB_Check()
        {
            NickName_Tracker_DB_set ntds = new NickName_Tracker_DB_set();
            if (!ntds.DB_Check()) //만약에 false 라면~
            {
                MessageBox.Show("DB를 설정하는 도중 오류가 발생하였습니다.");
                this.Close(); //닫아버리기
            }


        }

        string nicknametemp = "";
        bool newUserCheck = false; //첫 이용자인지 확인
        private void MyNameCheck()
        {
            string strConn = new NickName_Tracker_DB_set().GetstrConn();
            string myAccessID = "";
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(strConn))
                {
                    conn.Open(); //DB 연결

                    string sqlCommand = "SELECT * FROM `Main DB`";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            rdr.Read();
                            if(rdr["My access ID"].ToString().Equals("!NULL")){
                                newUserCheck = true;
                            }
                            else
                            {
                                myAccessID = rdr["My access ID"].ToString();
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("설정값을 불러오는 중 문제가 발생하였습니다.\n" + e);
                this.Close();
            }

            if (newUserCheck)
            {
                Add_my_nickname amn = new Add_my_nickname();
                amn.DataSendEvent += new DataGetEventHandler(this.DataGet);
                amn.ShowDialog();
            }
            else
            {
                myCurrentNickname(myAccessID);
            }
            
        }

        private void myCurrentNickname(string useraccessID) //내 최신 닉네임 받아오기
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            string responseText = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.nexon.co.kr/kart/v1.0/users/" + useraccessID);
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

                var capture = Regex.Match(responseText, "\"name\":\".+?\"");
                nicknametemp = capture.Value.Replace("\"name\":\"", "").Replace("\"", ""); //불필요 자료들 삭제하기

                userArray(); //작업 완료 후 유저 표시하기
            }
            catch (WebException)
            {
                MessageBox.Show(StringLib.Message_3, StringLib.Message);
                
            }
            catch (Exception)
            {
                MessageBox.Show(StringLib.ERROR, StringLib.ERROR);
            }
        }

        private void DataGet(bool type,string nickname, string accessID)
        {
            if (!type)
            {
                if (newUserCheck) this.Close(); //처음 사용자 이면서 닉네임을 저장하지 않으면 닫기
            }
            else
            {
                
                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(new NickName_Tracker_DB_set().GetstrConn())) //새로운 유저의 ID로 교체
                    {
                        conn.Open(); //DB 연결

                        string sqlCommand = "SELECT * FROM `Main DB`";
                        
                        sqlCommand = "UPDATE `Main DB` SET `My access ID`="+accessID+";";
                        using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        conn.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(StringLib.ERROR_1, StringLib.ERROR); //저장 중 에러 발생
                    this.Close();
                }
                nicknametemp = nickname;
                userArray();
            }
        }

        private void userArray() //모든 유저 추가하기
        {
            treeView1.Nodes.Clear();
            TreeNode tn = new TreeNode("MY");
            tn.Nodes.Add(nicknametemp);
            treeView1.Nodes.Add(tn);
            treeView1.ExpandAll();
            treeView1.Nodes[0].Expand();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.treeView1.Nodes[0].IsSelected)
            {
                return; //그룹을 선택한 경우 종료
            }
            else if(treeView1.Nodes[0].Nodes[0].IsSelected)
            {
                Add_my_nickname amn = new Add_my_nickname();
                amn.DataSendEvent += new DataGetEventHandler(this.DataGet);
                amn.ShowDialog();
            }
        }
    }
}

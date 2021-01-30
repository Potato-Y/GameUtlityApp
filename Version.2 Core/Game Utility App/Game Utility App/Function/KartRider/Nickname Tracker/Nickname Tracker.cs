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

                        string sqlCommand = "UPDATE `Main DB` SET `My access ID`="+accessID+";";
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

        static string groupTag = "||DB User Group||:"; //그룹 key에 붙는 구분용 태그
        static Dictionary<string, string> userMemo = new Dictionary<string, string>();
        private void userArray() //모든 유저 추가하기
        {
            comboBoxGroupChoose.Items.Clear();
            treeView1.Nodes.Clear(); //초기화
            TreeNode[] tn; 
            Dictionary<string, string> tnGroupKey = new Dictionary<string, string>(); //유저의 그룹 연결
            string sqlCommand;
            int groupcount; //그룹 수
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(new NickName_Tracker_DB_set().GetstrConn()))
                {
                    conn.Open(); //DB 연결

                    sqlCommand = "SELECT COUNT(*) FROM `Friend nickname group`";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            rdr.Read();
                            groupcount = Convert.ToInt32(rdr["COUNT(*)"].ToString()); //그룹 수를 가져오기
                            if (groupcount > 0) //그룹이 있으면 실행
                            {
                                tn = new TreeNode[groupcount + 1];
                                tn[0] = new TreeNode("MY");
                            }
                            else
                            {
                                tn = new TreeNode[1];
                                tn[0] = new TreeNode("MY");
                                comboBoxGroupChoose.Items.Add("MY");
                            }

                        }
                    }
                    if (groupcount > 0)
                    {
                        sqlCommand = "SELECT * FROM `Friend nickname group`";
                        using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                        {
                            using (SQLiteDataReader rdr = cmd.ExecuteReader())
                            {
                                int i = 1; //그룹 id는 1부터 시작. 0은 기본 유저용

                                while (rdr.Read())
                                {
                                    if(rdr["group name"].ToString().Equals("DB System default group"))
                                    {
                                        tn[i] = new TreeNode(StringLib.Text_1);
                                        comboBoxGroupChoose.Items.Add(StringLib.Text_1);
                                    }
                                    else
                                    {
                                        tn[i] = new TreeNode(rdr["group name"].ToString());
                                        comboBoxGroupChoose.Items.Add(rdr["group name"].ToString());
                                    }
                                    tnGroupKey.Add(rdr["group name"].ToString(), groupTag + i);
                                    i++;
                                }

                            }
                        }

                        sqlCommand = "SELECT * FROM `Friend nickname`";
                        using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                        {
                            using (SQLiteDataReader rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    tn[Convert.ToInt32(tnGroupKey[rdr["group name"].ToString()].Replace(groupTag, ""))].Nodes.Add(rdr["access ID"].ToString(),rdr["user nickname"].ToString());
                                    
                                }
                            }
                        }
                    }

                    
                    
                    conn.Close();
                }
                
                tn[0].Nodes.Add(nicknametemp);
                
                for(int i = 0; i < groupcount + 1; i++)
                {
                    treeView1.Nodes.Add(tn[i]);
                }
                
                treeView1.ExpandAll();
            }
            catch (Exception e)
            {
                MessageBox.Show("설정값을 불러오는 중 문제가 발생하였습니다.\n" + e);
                this.Close();
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.Nodes[0].IsSelected||treeView1.Nodes[1].IsSelected)
            {
                return;
            }
            else if (treeView1.SelectedNode.Name.Equals("")) 
            {
                MessageBox.Show("메뉴임");
                return; //그룹을 선택한 경우 종료
            }
            else if(treeView1.Nodes[0].Nodes[0].IsSelected)
            {
                Add_my_nickname amn = new Add_my_nickname();
                amn.DataSendEvent += new DataGetEventHandler(this.DataGet);
                amn.ShowDialog();
                return;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.Nodes[0].IsSelected || treeView1.Nodes[1].IsSelected || treeView1.Nodes[0].Nodes[0].IsSelected || treeView1.SelectedNode.Name.Equals("")) 
            { //그룹이거나, 내 닉네임을 선택하면 패스
                textBoxMemo.Text = "";
                textBoxNickname.Text = treeView1.SelectedNode.Text;
                textBoxFirstNickname.Text = "";
                comboBoxGroupChoose.Text = "MY";
                comboBoxGroupChoose.Text = "";
                comboBoxGroupChoose.Enabled = false;
                textBoxFirstNickname.Enabled = false;
                textBoxMemo.Enabled = false;
                buttonSave.Enabled = true;
                return;
            }
            else
            {
                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(new NickName_Tracker_DB_set().GetstrConn()))
                    {
                        conn.Open(); //DB 연결

                        string sqlCommand = "SELECT * FROM `Friend nickname` WHERE `access ID` =\"" + treeView1.SelectedNode.Name + "\";";
                        using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                        {
                            using (SQLiteDataReader rdr = cmd.ExecuteReader())
                            {
                                rdr.Read();
                                textBoxMemo.Text = rdr["memo"].ToString();
                                textBoxFirstNickname.Text = rdr["first nickname"].ToString();
                                textBoxNickname.Text = rdr["user nickname"].ToString();
                                string groupNameTemp = rdr["group name"].ToString();

                                //기본 그룹이면 다르게 처리
                                if (groupNameTemp.Equals("DB System default group")) comboBoxGroupChoose.Text = StringLib.Text_1;
                                else comboBoxGroupChoose.Text = groupNameTemp;

                                comboBoxGroupChoose.Enabled = true;
                                textBoxMemo.Enabled = true;
                                buttonSave.Enabled = true;
                                textBoxFirstNickname.Enabled = true;
                            }
                        }
                        return;
                    }
                }catch (Exception)
                {
                    MessageBox.Show("오류");
                }
            }
        }

        private void buttonFriendAdd_Click(object sender, EventArgs e)
        {
            User_NickName_Add una = new User_NickName_Add();
            una.ShowDialog();
            userArray();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(new NickName_Tracker_DB_set().GetstrConn())) //새로운 유저의 ID로 교체
                {
                    conn.Open(); //DB 연결

                    string groupChooseTemp = comboBoxGroupChoose.Text;
                    if (groupChooseTemp.Equals(StringLib.Text_1)) groupChooseTemp = "DB System default group"; //만약 기본 그룹이면 맞게 변경
                    string sqlCommand = "UPDATE `Friend nickname` SET `memo`=\"" + textBoxMemo.Text + "\",`group name`=\"" + groupChooseTemp + "\" WHERE `access ID`=\"" + treeView1.SelectedNode.Name + "\";";
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

            userArray();
        }

        private void buttonGroupAdd_Click(object sender, EventArgs e)
        {
            Add_Group ag = new Add_Group();
            ag.ShowDialog();
            userArray();
        }
    }
}

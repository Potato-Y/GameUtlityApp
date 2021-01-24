using GameUtilityApp.Essential.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
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
            DB_Load();
            MyNameCheck();
        }

        private void DB_Load()
        {
            NickName_Tracker_DB_set ntds = new NickName_Tracker_DB_set();
            if (!ntds.DB_Check()) //만약에 false 라면~
            {
                MessageBox.Show("DB를 설정하는 도중 오류가 발생하였습니다.");
                this.Close(); //닫아버리기
            }

        }

        private void MyNameCheck()
        {
            string strConn = new NickName_Tracker_DB_set().GetstrConn();
            bool newUserCheck = false;
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
                            if(rdr["My access ID"].ToString().Equals("NULL")){
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
                Application.Exit();
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

        private void myCurrentNickname(string useraccessID)
        {
            
        }

        private void DataGet(bool type,string nickname, string accessID)
        {
            if (!type)
            {
                this.Close();
            }
            else
            {

            }
        }
    }
}

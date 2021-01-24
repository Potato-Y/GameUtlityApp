using GameUtilityApp.Essential.Class;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Function.KartRider.Nickname_Tracker
{
    class NickName_Tracker_DB_set
    {
        static ThisGET get = new ThisGET();
        static string path = get.FolderPath() + @"\KartRider";
        static string strFile = path + @"\NickName.db";
        static string strConn = @"Data Source=" + strFile;

        public bool DB_Check()
        {
            if (!DB_File_Check()) return false; //DB 파일이 존재하는지 확인
            if (!DB_Update_Check()) return false;

            return true;
        }

        public string GetstrConn()
        {
            return strConn;
        }
        private bool DB_File_Check()
        {
            try
            {
                DirectoryInfo Documents_App_Directory = new DirectoryInfo(path); //디렉토리에 폴더가 존재하는지 확인
                if (Documents_App_Directory.Exists == false) //폴더가 없으면
                {
                    Documents_App_Directory.Create(); //폴더 생성
                }

                SQLiteConnection.CreateFile(strFile); //DB 파일 생성

                using (SQLiteConnection conn = new SQLiteConnection(strConn))
                {
                    conn.Open(); //DB 연결

                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("GameUtilityApp.Function.KartRider.Nickname_Tracker.DB_Control.NewCreateTable.txt");
                    StreamReader reader = new StreamReader(stream);

                    string sqlCommand = reader.ReadToEnd();

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e); //저장 중 오류가 발생하였습니다.
                return false;
            }

            return true;
        }

        private bool DB_Update_Check() //DB 업데이트 확인
        {
            return true;
        }
    }
}

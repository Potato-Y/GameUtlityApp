using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace GameUtilityApp.Essential.DB_Control
{
    class Main_Setting_DB
    {
        string strConn = @"Data Source=" + Application.StartupPath + @"\MainSettings.db";
        string strFile = Application.StartupPath + @"\MainSettings.db";
        public void FileCheck() { 
            //파일 존재 유무 확인
            FileInfo file = new FileInfo(strFile);
            if (!file.Exists) //파일이 없으면 새로운 파일 등록
            {
                CreateFile(); //파일을 새로 만들기 시작
            }
        }

        private void CreateFile()
        {
            try
            {
                SQLiteConnection.CreateFile(strFile); //DB 파일 생성

                using (SQLiteConnection conn = new SQLiteConnection(strConn))
                {
                    conn.Open(); //DB 연결

                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("GameUtilityApp.Essential.DB_Control.MainSetting_SQL_Command.CreateTable.txt");
                    StreamReader reader = new StreamReader(stream);
                    
                    string sql = reader.ReadToEnd();

                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("오류가 발생하였습니다.\n\n" + e);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using GameUtilityApp.Essential.Language;

namespace GameUtilityApp.Essential.DB_Control
{
    class Main_Setting_DB
    {
        static string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\AppData\Local\Game Utility App";
        static string strFile = path + @"\MainSettings.db";
        static string strConn = @"Data Source=" + strFile;
        public void FileCheck() { 
            //파일 존재 유무 확인
            FileInfo file = new FileInfo(strFile);
            if (!file.Exists) //파일이 없으면 새로운 파일 등록
            {
                CreateFile(); //파일을 새로 만들기 시작
            }

            //만약 파일이 있으면 업데이트 확인 후 필요시 패치
            UpdateCheck();
        }

        private void CreateFile()
        {
            try
            {
                DirectoryInfo Documents_App_Directory = new DirectoryInfo(path);
                if (Documents_App_Directory.Exists == false)
                {
                    Documents_App_Directory.Create();
                }

                SQLiteConnection.CreateFile(strFile); //DB 파일 생성

                using (SQLiteConnection conn = new SQLiteConnection(strConn))
                {
                    conn.Open(); //DB 연결

                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("GameUtilityApp.Essential.DB_Control.MainSetting_SQL_Command.CreateTable.txt");
                    StreamReader reader = new StreamReader(stream);
                    
                    string sqlCommand = reader.ReadToEnd();

                    SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(StringLib.ERROR_1+e); //저장 중 오류가 발생하였습니다.
            }

        }

        private void UpdateCheck()
        {
            try
            {
                string sqlCommand = "SELECT * FROM MainSetting";
                using (SQLiteConnection conn = new SQLiteConnection(strConn))
                {
                    conn.Open(); //DB 연결

                    SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn);
                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    rdr.Read();
                    //MessageBox.Show(rdr["DB Version"].ToString());
                    

                    rdr.Close();
                    conn.Close();
                }

            }catch (Exception e)
            {
                MessageBox.Show(e+"");
            }
            
        }
    }
}

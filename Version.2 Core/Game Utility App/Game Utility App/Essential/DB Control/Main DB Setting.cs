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
using Microsoft.Win32;

namespace GameUtilityApp.Essential.DB_Control
{
    class Main_DB_Setting
    {
        static string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\AppData\Local\Game Utility App";
        static string strFile = path + @"\MainDB.db";
        static string strConn = @"Data Source=" + strFile;

        public string GetstrConn()
        {
            return strConn;
        }

        public string GetstrFile()
        {
            return strFile;
        }

        public bool FileCheck() { //비정상 작동이 있을 경우 false 반환
            //파일 존재 유무 확인
            FileInfo file = new FileInfo(strFile);
            if (!file.Exists) //파일이 없으면 새로운 파일 등록
            {
                if (!CreateFile()) return false;   //파일을 새로 만들기 시작              
            }

            //업데이트 확인 후 필요시 패치
            if (!UpdateCheck()) return false;

            return true; //모두 정상 작동
        }

        private bool CreateFile()
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

                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("GameUtilityApp.Essential.DB_Control.MainDB_SQL_Command.NewCreateTable.txt");
                    StreamReader reader = new StreamReader(stream);
                    
                    string sqlCommand = reader.ReadToEnd();

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    //레지 기본값 저장  sqlCommand 새로운 값 넣기

                    using (RegistryKey reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("KeyBoard"))
                    {
                        sqlCommand = "INSERT INTO `Past Registry` VALUES (" + Convert.ToString(reg.GetValue("InitialKeyboardIndicators", "")) + ", " + Convert.ToString(reg.GetValue("KeyboardDelay", "")) + ", " + Convert.ToString(reg.GetValue("KeyboardSpeed", "")) + ", ";
                        reg.Close();
                    }

                    using(RegistryKey reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("Keyboard Response"))
                    {
                        sqlCommand += Convert.ToString(reg.GetValue("AutoRepeatDelay", "")) + ", " + Convert.ToString(reg.GetValue("AutoRepeatRate", "")) + ", " + Convert.ToString(reg.GetValue("BounceTime", "")) + ", " + Convert.ToString(reg.GetValue("DelayBeforeAcceptance", "")) + ", " + Convert.ToString(reg.GetValue("Flags", "")) + ", " + Convert.ToString(reg.GetValue("Last BounceKey Setting", "")) + ", " + Convert.ToString(reg.GetValue("Last Valid Delay", "")) + ", " + Convert.ToString(reg.GetValue("Last Valid Repeat", "")) + ", " + Convert.ToString(reg.GetValue("Last Valid Wait", "")) + ", ";
                    }

                    using (RegistryKey reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("ToggleKeys"))
                    {
                        sqlCommand += Convert.ToString(reg.GetValue("Flags", ""));
                    }

                    sqlCommand += ");";

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
                MessageBox.Show(StringLib.ERROR_1 + "\n" + e); //저장 중 오류가 발생하였습니다.
                return false;
            }
            return true;
        }

        private bool UpdateCheck()
        {
            try
            {
                string sqlCommand = "SELECT * FROM `Main Setting`";
                using (SQLiteConnection conn = new SQLiteConnection(strConn))
                {
                    conn.Open(); //DB 연결

                    SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn);
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        rdr.Read();
                        //MessageBox.Show(rdr["DB Version"].ToString());
                        rdr.Close();
                    }
                    conn.Close();
                }

            }catch (Exception e)
            {
                MessageBox.Show(e+"");
                return false;
            }

            return true; //정상 작업 완료
            
        }
    }
}

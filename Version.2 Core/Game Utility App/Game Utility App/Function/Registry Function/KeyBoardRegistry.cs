using GameUtilityApp.Essential.DB_Control;
using GameUtilityApp.Function.Registry_Funtion;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Essential
{
    class KeyBoardRegistry
    {
        public bool Keyboard_Registry_Apply(int type, string regName,int value) //해당 부분 미완성. 뼈대만 만든 상태
        {
            try
            {
                using(RegistryKey reg = Registry.CurrentUser)
                {
                    if(type==1) //타입에 따라 값을 따로 저장
                    {
                        reg.OpenSubKey("Control Panel").OpenSubKey("KeyBoard", true);
                        reg.SetValue(regName, value);
                    }else if (type == 2)
                    {
                        reg.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("Keyboard Response", true);
                        reg.SetValue(regName, value);
                    }else if (type == 3)
                    {
                        reg.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("ToggleKeys", true);
                        reg.SetValue("Flags", value);
                    }
                    else
                    {
                        return false;
                    }

                    reg.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //키보드 레지스트리를 전부 저장
        public bool Keyboard_Registry_All_Apply(Int64 InitialKeyboardIndicators1, Int64 KeyboardDelay1, Int64 KeyboardSpeed1, Int64 AutoRepeatDelay2, Int64 AutoRepeatRate2, Int64 BounceTime2, Int64 DelayBeforeAcceptance2, Int64 Flags2, Int64 LastBounceKeySetting2, Int64 LastValidDelay2, Int64 LastValidRepeat2, Int64 LastValidWait2, Int64 Flags3)
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("KeyBoard", true))
                {
                    reg.SetValue("InitialKeyboardIndicators", InitialKeyboardIndicators1, RegistryValueKind.String);
                    reg.SetValue("KeyboardDelay", KeyboardDelay1, RegistryValueKind.String);
                    reg.SetValue("KeyboardSpeed", KeyboardSpeed1, RegistryValueKind.String);
                    reg.Close();
                }

                using (RegistryKey reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("Keyboard Response", true))
                {
                    reg.SetValue("AutoRepeatDelay", AutoRepeatDelay2, RegistryValueKind.String);
                    reg.SetValue("AutoRepeatRate", AutoRepeatRate2, RegistryValueKind.String);
                    reg.SetValue("BounceTime", BounceTime2, RegistryValueKind.String);
                    reg.SetValue("DelayBeforeAcceptance", DelayBeforeAcceptance2, RegistryValueKind.String);
                    reg.SetValue("Flags", Flags2, RegistryValueKind.String);
                    reg.SetValue("Last BounceKey Setting", LastBounceKeySetting2, RegistryValueKind.DWord);
                    reg.SetValue("Last Valid Delay", LastValidDelay2, RegistryValueKind.DWord);
                    reg.SetValue("Last Valid Repeat", LastValidRepeat2, RegistryValueKind.DWord);
                    reg.SetValue("Last Valid Wait", LastValidWait2, RegistryValueKind.DWord);
                    reg.Close();
                }

                using (RegistryKey reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("ToggleKeys", true))
                {
                    reg.SetValue("Flags", Flags3, RegistryValueKind.String);
                    reg.Close();
                }

                Main_DB_Setting msd = new Main_DB_Setting();
                string strConn = msd.GetstrConn();

                using (SQLiteConnection conn = new SQLiteConnection(strConn)) //마지막 레지스트리 저장
                {
                    conn.Open(); //DB 연결

                    string sqlCommand = "UPDATE `Past Registry` SET ";
                    sqlCommand += "`1_InitialKeyboardIndicators` = " + InitialKeyboardIndicators1+", ";
                    sqlCommand += "`1_KeyboardDelay` = " + KeyboardDelay1 + ", ";
                    sqlCommand += "`1_KeyboardSpeed` = " + KeyboardSpeed1 + ", ";
                    sqlCommand += "`2_AutoRepeatDelay` = " + AutoRepeatDelay2 + ", ";
                    sqlCommand += "`2_AutoRepeatRate` = " + AutoRepeatRate2 + ", ";
                    sqlCommand += "`2_BounceTime` = " + BounceTime2 + ", ";
                    sqlCommand += "`2_DelayBeforeAcceptance` = " + DelayBeforeAcceptance2 + ", ";
                    sqlCommand += "`2_Flags` = " + Flags2 + ", ";
                    sqlCommand += "`2_Last BounceKey Setting` = " + LastBounceKeySetting2 + ", ";
                    sqlCommand += "`2_Last Valid Delay` = " + LastValidDelay2 + ", ";
                    sqlCommand += "`2_Last Valid Repeat` = " + LastValidRepeat2 + ", ";
                    sqlCommand += "`2_Last Valid Wait` = " + LastValidWait2 + ", ";
                    sqlCommand += "`3_Flags` = " + Flags3 + ";";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }

            catch (Exception)
            {
                return false;
            }

            return true;
        }


        public bool StartingAutoSave()
        {

            Main_DB_Setting msd = new Main_DB_Setting();
            string strConn = msd.GetstrConn();  //strConn 주소 받아오기

            try
            {
                bool value=false;
                using (SQLiteConnection conn = new SQLiteConnection(strConn)) //만약에 사용자가 기능을 사용하지 않으면 바로 return
                {
                    conn.Open(); //DB 연결

                    string sqlCommand = "SELECT * FROM `Main Setting`";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            rdr.Read();
                            if (rdr["Apply registry at startup"].ToString().Equals("true")) value = true;
                        }
                    }
                    conn.Close();
                }
                if (value==true) {

                    Int64 v1;
                    Int64 v2;
                    Int64 v3;
                    Int64 v4;
                    Int64 v5;
                    Int64 v6;
                    Int64 v7;
                    Int64 v8;
                    Int64 v9;
                    Int64 v10;
                    Int64 v11;
                    Int64 v12;
                    Int64 v13;

                    try
                    {
                        string sqlCommand = "SELECT * FROM `Past Registry`";
                        using (SQLiteConnection conn = new SQLiteConnection(strConn))
                        {
                            conn.Open(); //DB 연결

                            Registry_Read_Num_Check rrnc = new Registry_Read_Num_Check();
                            SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn);
                            using (SQLiteDataReader rdr = cmd.ExecuteReader())
                            {
                                rdr.Read();
                                v1 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["1_InitialKeyboardIndicators"].ToString()));
                                v2 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["1_KeyboardDelay"].ToString()));
                                v3 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["1_KeyboardSpeed"].ToString()));
                                v4 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["2_AutoRepeatDelay"].ToString()));
                                v5 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["2_AutoRepeatRate"].ToString()));
                                v6 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["2_BounceTime"].ToString()));
                                v7 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["2_DelayBeforeAcceptance"].ToString()));
                                v8 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["2_Flags"].ToString()));
                                v9 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["2_Last BounceKey Setting"].ToString()));
                                v10 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["2_Last Valid Delay"].ToString()));
                                v11 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["2_Last Valid Repeat"].ToString()));
                                v12 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["2_Last Valid Wait"].ToString()));
                                v13 = Convert.ToInt64(rrnc.NumChackAndChange(rdr["3_Flags"].ToString()));
                                rdr.Close();
                            }
                            conn.Close();
                        }

                        KeyBoardRegistry kbr = new KeyBoardRegistry();
                        kbr.Keyboard_Registry_All_Apply(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13);
                        //MessageBox.Show("적용함");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex + "");
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("설정값을 불러오는 중 문제가 발생하였습니다.\n" + e);
                return false;
            }

           

            return true;
        }

        
    }
}

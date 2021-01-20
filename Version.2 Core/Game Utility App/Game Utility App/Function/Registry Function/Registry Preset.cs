using GameUtilityApp.Essential.DB_Control;
using GameUtilityApp.Function.Registry_Funtion;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Function
{
    public partial class Registry_Preset : Form
    {
        public Registry_Preset()
        {
            InitializeComponent();
        }

        private void Registry_Preset_Load(object sender, EventArgs e)
        {
            RegLoad();
            ComboBoxLoad();
            this.ActiveControl = presetChoiceComboBox;
        }

        private void ComboBoxLoad()
        {
            try
            {
                Main_Setting_DB msd = new Main_Setting_DB();
                string strConn = msd.GetstrConn();  //strConn 주소 받아오기

                string sqlCommand = "SELECT * FROM `Registry Default Preset`";
                using (SQLiteConnection conn = new SQLiteConnection(strConn))
                {
                    conn.Open(); //DB 연결

                    SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn);
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read()) //모든 항목들을 받아오기 위해 반복
                        {
                            presetChoiceComboBox.Items.Add(rdr["Name"].ToString()); //받아온 레지스트리의 이름 저장하기
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
            }
        }

        private void RegLoad()
        {
            try
            {
                RegistryKey reg;
                reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("KeyBoard");
                textBox1.Text = Convert.ToString(reg.GetValue("InitialKeyboardIndicators", ""));
                textBox2.Text = Convert.ToString(reg.GetValue("KeyboardDelay", ""));
                textBox3.Text = Convert.ToString(reg.GetValue("KeyboardSpeed", ""));
                reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("Keyboard Response");
                textBox4.Text = Convert.ToString(reg.GetValue("AutoRepeatDelay", ""));
                textBox5.Text = Convert.ToString(reg.GetValue("AutoRepeatRate", ""));
                textBox6.Text = Convert.ToString(reg.GetValue("BounceTime", ""));
                textBox7.Text = Convert.ToString(reg.GetValue("DelayBeforeAcceptance", ""));
                textBox8.Text = Convert.ToString(reg.GetValue("Flags", ""));
                textBox10.Text = Convert.ToString(reg.GetValue("Last BounceKey Setting", ""));
                textBox11.Text = Convert.ToString(reg.GetValue("Last Valid Delay", ""));
                textBox12.Text = Convert.ToString(reg.GetValue("Last Valid Repeat", ""));
                textBox13.Text = Convert.ToString(reg.GetValue("Last Valid Wait", ""));
                reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("ToggleKeys");
                textBox9.Text = Convert.ToString(reg.GetValue("Flags", ""));
                reg.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("레지스트리를 불러오는데 오류가 발생하였습니다.");
            }
        }

        private void key_Down(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                if (sender == textBox1)
                {
                    textBox2.Focus();
                }
                else if (sender == textBox2)
                {
                    textBox3.Focus();
                }
                else if (sender == textBox3)
                {
                    textBox4.Focus();
                }
                else if (sender == textBox4)
                {
                    textBox5.Focus();
                }
                else if (sender == textBox5)
                {
                    textBox6.Focus();
                }
                else if (sender == textBox6)
                {
                    textBox7.Focus();
                }
                else if (sender == textBox7)
                {
                    textBox8.Focus();
                }
                else if (sender == textBox8)
                {
                    textBox9.Focus();
                }
                else if (sender == textBox9)
                {
                    textBox10.Focus();
                }
                else if (sender == textBox10)
                {
                    textBox11.Focus();
                }
                else if (sender == textBox11)
                {
                    textBox12.Focus();
                }
                else if (sender == textBox12)
                {
                    textBox13.Focus();
                }
                else if (sender == textBox13)
                {
                    saveButton.Focus();
                }

            }
        }



        private void txtInterval_KeyPress(object sender, KeyPressEventArgs e) //색상 변경 및 숫자만 입력
        {

            if (sender == textBox1)
            {
                label1.ForeColor = Color.Blue;
            }
            else if (sender == textBox2)
            {
                label2.ForeColor = Color.Blue;
            }
            else if (sender == textBox3)
            {
                label3.ForeColor = Color.Blue;
            }
            else if (sender == textBox4)
            {
                label4.ForeColor = Color.Blue;
            }
            else if (sender == textBox5)
            {
                label5.ForeColor = Color.Blue;
            }
            else if (sender == textBox6)
            {
                label6.ForeColor = Color.Blue;
            }
            else if (sender == textBox7)
            {
                label7.ForeColor = Color.Blue;
            }
            else if (sender == textBox8)
            {
                label8.ForeColor = Color.Blue;
            }
            else if (sender == textBox9)
            {
                label9.ForeColor = Color.Blue;
            }
            else if (sender == textBox10)
            {
                label10.ForeColor = Color.Blue;
            }
            else if (sender == textBox11)
            {
                label11.ForeColor = Color.Blue;
            }
            else if (sender == textBox12)
            {
                label12.ForeColor = Color.Blue;
            }
            else if (sender == textBox13)
            {
                label13.ForeColor = Color.Blue;
            }


            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;
        }

        private void presetChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if(cb.SelectedIndex>-1)
            {
                try
                {
                    Main_Setting_DB msd = new Main_Setting_DB();
                    string strConn = msd.GetstrConn();  //strConn 주소 받아오기

                    string sqlCommand = "SELECT * FROM `Registry Default Preset` WHERE Name=\"" + presetChoiceComboBox.Text + "\"";
                    using (SQLiteConnection conn = new SQLiteConnection(strConn))
                    {
                        conn.Open(); //DB 연결

                        SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn);
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            rdr.Read();
                            Registry_Read_Num_Check rrnc = new Registry_Read_Num_Check();
                            textBox1.Text = rrnc.NumChackAndChange(rdr["1_InitialKeyboardIndicators"].ToString());
                            textBox2.Text = rrnc.NumChackAndChange(rdr["1_KeyboardDelay"].ToString());
                            textBox3.Text = rrnc.NumChackAndChange(rdr["1_KeyboardSpeed"].ToString());
                            textBox4.Text = rrnc.NumChackAndChange(rdr["2_AutoRepeatDelay"].ToString());
                            textBox5.Text = rrnc.NumChackAndChange(rdr["2_AutoRepeatRate"].ToString());
                            textBox6.Text = rrnc.NumChackAndChange(rdr["2_BounceTime"].ToString());
                            textBox7.Text = rrnc.NumChackAndChange(rdr["2_DelayBeforeAcceptance"].ToString());
                            textBox8.Text = rrnc.NumChackAndChange(rdr["2_Flags"].ToString());
                            textBox9.Text = rrnc.NumChackAndChange(rdr["2_Last BounceKey Setting"].ToString());
                            textBox10.Text = rrnc.NumChackAndChange(rdr["2_Last Valid Delay"].ToString());
                            textBox11.Text = rrnc.NumChackAndChange(rdr["2_Last Valid Repeat"].ToString());
                            textBox12.Text = rrnc.NumChackAndChange(rdr["2_Last Valid Wait"].ToString());
                            textBox13.Text = rrnc.NumChackAndChange(rdr["3_Flags"].ToString());
                            rdr.Close();
                        }
                        conn.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "");
                }
            }
        }

    }
}

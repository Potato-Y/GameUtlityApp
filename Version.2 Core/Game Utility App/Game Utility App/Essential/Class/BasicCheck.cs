using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameUtilityApp.Essential.DB_Control;
using GameUtilityApp.Essential.Language;
using System.Drawing.Text;
using System.Drawing;

namespace GameUtilityApp.Essential.Class
{
    class BasicCheck
    {

        public bool EssentialCheck()  //필수 확인 요소
        {
            if (!DB_Check()) return false; //DB 상태 체크 및 업데이트
            if (!FontCheck()) return false; //폰트 상태 체크 밑 설치 안내
            if (!RegistryStartingAutoSave()) return false; //레지스트리 자동 저장 기능 사용시 자동 저장

            return true;  //정상 작업 완료
        }

        public bool DB_Check()
        {
            Main_DB_Setting mainDB = new Main_DB_Setting();
            if (!mainDB.FileCheck()) return false;

            return true; //작업 정상 완료
        }

        public bool FontCheck()
        {
            if (IsFontInstalled("나눔고딕") == false) //폰트가 있는지 없는지 확인
            {
                
                if ((MessageBox.Show(StringLib.ERROR_2, StringLib.ERROR, MessageBoxButtons.YesNo) == DialogResult.Yes)) //폰트를 설치한다면 해당 프로그램을 실행 혹은 다운 후 실행합니다.
                {
                    while (!IsFontInstalled("나눔고딕"))
                    {
                        if(MessageBox.Show(StringLib.Message_1,"Font Error", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
                        {
                            return false;
                        } 
                    }
                }
                else //거부시 프로그램이 종료된다.
                {
                    return false;
                }

            }
            return true;
        }

       

        private bool IsFontInstalled(string fontName) //폰트가 있는지 확인하는 함수
        {
            InstalledFontCollection collection = new InstalledFontCollection();

            foreach (FontFamily fontFamily in collection.Families)
            {
                if (fontFamily.Name.Equals(fontName))
                {
                    return true;
                }
            }
            return false;
        }

        private bool RegistryStartingAutoSave()
        {
            KeyBoardRegistry kbr = new KeyBoardRegistry();
            if (!kbr.StartingAutoSave()) return false;
            return true;
        }
    }
}

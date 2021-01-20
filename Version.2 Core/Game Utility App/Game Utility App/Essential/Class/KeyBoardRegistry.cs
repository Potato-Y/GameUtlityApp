using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                using(RegistryKey reg=Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("KeyBoard", true))
                {
                    reg.SetValue("InitialKeyboardIndicators", InitialKeyboardIndicators1, RegistryValueKind.String);
                    reg.SetValue("KeyboardDelay", KeyboardDelay1, RegistryValueKind.String);
                    reg.SetValue("KeyboardSpeed", KeyboardSpeed1, RegistryValueKind.String);
                    reg.Close();
                }

                using(RegistryKey reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("Keyboard Response", true))
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

                using(RegistryKey reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("ToggleKeys", true))
                {
                    reg.SetValue("Flags", Flags3, RegistryValueKind.String);
                    reg.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}

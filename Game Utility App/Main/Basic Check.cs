using GameUtilityApp.Notice;
using GameUtilityApp.Properties;
using Microsoft.Win32;
using System;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GameUtilityApp
{
    class Basic_Check
    {
        int thisrelese = 20200817;

        /// <summary>
        /// 이곳은 네트워크 상태 및 버전 업데이트 관련 코드가 있는 영역입니다.
        /// </summary>
        public void NetworkCheck()
        {
            bool netstate = NetworkInterface.GetIsNetworkAvailable();//네트워크 상태 확인
            if (netstate == false)
            {
                MessageBox.Show("인터넷에 연결되어있지 않습니다.\r\n네트워크 상태를 다시 확인하고 실행해주세요.", "서버오류");
                Application.Exit();
            }
        }

        public int UpdateCheck()
        {
            try
            {
                int lastReleseVersion = LatestVersionCheck();
                int minimumReleseVersion = MinimumVersionCheck();

                if (thisrelese < lastReleseVersion)
                {
                    if (thisrelese < minimumReleseVersion)
                    {
                        if (MessageBox.Show("필수 업데이트가 있습니다. 업데이트를 하시겠습니까?\n아니요를 누르면 종료됩니다." + "\n\n" + "버전 정보\n" + "최신 릴리즈 날짜 : " + lastReleseVersion + "\n" + "최소 실행 릴리즈 날짜 : " + minimumReleseVersion + "\n본 앱 릴리즈 날짜 : " + thisrelese, "업데이트 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            AppUpadateForm newForm = new AppUpadateForm();
                            newForm.ShowDialog();
                        }
                        else
                        {
                            Application.Exit();
                        }

                    }
                    else if (minimumReleseVersion <= thisrelese)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("업데이트 확인 서버에 연결할 수 없습니다.\n\n홈페이지로 연결하시겠습니까?\n" + ex, "서버에 연결할 수 없습니다.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://cafe.naver.com/checkmateclub");
                    Application.Exit();
                    return 0;
                }
                else
                {
                    Application.Exit();
                    return 0;
                }
            }

        }
        string verCheckHtml = "";
        private void ServerVersionCheck()
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                var client = new HttpClient(); //웹으로부터 다운로드 받을 수 있는 클래스의 인스턴스를 제작 한다.
                var response = client.GetAsync("https://github.com/Potato-Y/Game-Utility-App/blob/master/release/release%20guide.md").Result; //웹으로부터 다운로드 
                verCheckHtml = response.Content.ReadAsStringAsync().Result; //다운로드 결과를 html 로 받아 온다. 
            }
            catch (Exception)
            {
                MessageBox.Show("서버에서 릴리즈 정보를 얻어올 수 없습니다.", "오류");
                Application.Exit();
            }
        }

        public int LatestVersionCheck() //최신 버전 체크
        {
            try
            {
                if (verCheckHtml == "")
                {
                    ServerVersionCheck();
                }
                var lastReleseCheckMatch = Regex.Match(verCheckHtml, "최신 버전 릴리즈 :.+?<"); //정규식을 사용해서 위의 문장과 동일한 패턴을 가져온다.
                string verCheckResult = lastReleseCheckMatch.Value; //캡쳐 된 내용을 가져온다.
                int lastReleseVer = Convert.ToInt32(verCheckResult.Substring(11, verCheckResult.Length - 12));
                return lastReleseVer;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("업데이트 확인 서버에 연결할 수 없습니다.\n\n홈페이지로 연결하시겠습니까?\n" + ex, "서버에 연결할 수 없습니다.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://cafe.naver.com/checkmateclub");
                    Application.Exit();
                    return 0;
                }
                else
                {
                    Application.Exit();
                    return 0;
                }
            }
        }

        public int MinimumVersionCheck()
        {
            try
            {
                if (verCheckHtml == "")
                {
                    ServerVersionCheck();
                }

                var minReleseCheckMatch = Regex.Match(verCheckHtml, "최소 실행 릴리즈 버전 :.+?<"); //정규식을 사용해서 위의 문장과 동일한 패턴을 가져온다.
                string minReleseCheckResult = minReleseCheckMatch.Value; //캡쳐 된 내용을 가져온다.
                int minReleseVer = Convert.ToInt32(minReleseCheckResult.Substring(14, minReleseCheckResult.Length - 15));
                return minReleseVer;
            }
            catch (Exception)
            {
                if (MessageBox.Show("업데이트 확인 서버에 연결할 수 없습니다.\n\n홈페이지로 연결하시겠습니까?\n", "서버에 연결할 수 없습니다.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://cafe.naver.com/checkmateclub");
                    Application.Exit();
                    return 0;
                }
                else
                {
                    Application.Exit();
                    return 0;
                }

            }
        }

        int check;
        public void NewUserCheck()
        {
            //새로운 유저인지 검색. 기존에 사용자인지, 버전을 확인하며 필요한 레지스트리 업데이트가 적용 합니다.
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE");
                if (reg.OpenSubKey("Game Utility App") == null || Convert.ToString(reg.OpenSubKey("Game Utility App").GetValue("ver release")) == "" || Convert.ToInt32(reg.OpenSubKey("Game Utility App").GetValue("ver release")) != thisrelese)
                {
                    reg = Registry.CurrentUser.CreateSubKey("SOFTWARE").CreateSubKey("Game Utility App", true);
                    reg.SetValue("ver release", thisrelese);
                }
                else
                {
                    check = Convert.ToInt32(reg.OpenSubKey("Game Utility App").GetValue("ver release"));
                }

                //dwm.exe Killer On Off check
                reg = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("Game Utility App", true);
                if (reg.OpenSubKey("setting") == null || Convert.ToString(reg.OpenSubKey("setting").GetValue("dwmKiller Start")) == "")
                {
                    reg.CreateSubKey("setting").SetValue("dwmKiller Start", 0); //0이면 작동 안함, 1이면 작동 함
                }
                else if(Convert.ToInt16(reg.OpenSubKey("setting").GetValue("dwmKiller Start")) == 1)
                {
                    dwmKiller_Start newCheck = new dwmKiller_Start();
                    newCheck.StartCheck();
                }
                reg.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("초기 설정을 하는데 오류가 발생하였습니다.\r\n개발자에게 문의하세요", "초기 설정 오류");
                Application.Exit();
            }

        }




        /// <summary>
        /// 이 곳은 넷 프레임 워크 확인 영역입니다.
        /// </summary>
        public void DotNetverCheck()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    string ver = CheckFor45PlusVersion((int)ndpKey.GetValue("Release"));
                    if (ver != "4.7.2")
                    {
                        if (ver != "4.8 or later")
                        {
                            MessageBox.Show(".NET Framework Version이 낮습니다. 업데이트 후 실행하세요.\n\n4.7.2 이상 버전하고 호환됩니다.", "NET Framework 업데이트 필요");
                            try
                            {
                                NetVerUpdate newForm = new NetVerUpdate();
                                newForm.ShowDialog();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("가이드가 실행되지 않습니다.\nError code : " + ex, "Error");
                                Application.Exit();

                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(".NET Framework Version 이 감지되지 않습니다.\n.NET Framework를 설치(업데이트) 후 실행 부탁드립니다.", "NET Framework 업데이트 필요");
                    try
                    {
                        NetVerUpdate newForm = new NetVerUpdate();
                        newForm.ShowDialog();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("업데이트 가이드를 실행하는 중 문제가 발생하였습니다.", "Error");
                        Application.Exit();
                    }
                }
            }

            // Checking the version using >= enables forward compatibility.
            string CheckFor45PlusVersion(int releaseKey)
            {
                if (releaseKey >= 528040)
                    return "4.8 or later";
                if (releaseKey >= 461808)
                    return "4.7.2";
                if (releaseKey >= 461308)
                    return "4.7.1";
                if (releaseKey >= 460798)
                    return "4.7";
                if (releaseKey >= 394802)
                    return "4.6.2";
                if (releaseKey >= 394254)
                    return "4.6.1";
                if (releaseKey >= 393295)
                    return "4.6";
                if (releaseKey >= 379893)
                    return "4.5.2";
                if (releaseKey >= 378675)
                    return "4.5.1";
                if (releaseKey >= 378389)
                    return "4.5";
                // This code should never execute. A non-null release key should mean
                // that 4.5 or later is installed.
                return "No 4.5 or later version detected";
            }
        }

        /// <summary>
        /// 사용자 카운터 영역
        /// </summary>

        string UserCountHomepageHtml;

        //서버에서 정보 가져오기
        private void GetUserCountData()
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                var client = new HttpClient(); //웹으로부터 다운로드 받을 수 있는 클래스의 인스턴스를 제작 한다.
                var response = client.GetAsync("http://potatoystudio.pe.kr/?device=mobile").Result; //웹으로부터 다운로드 
                UserCountHomepageHtml = response.Content.ReadAsStringAsync().Result; //다운로드 결과를 html 로 받아 온다.
            }
            catch (Exception)
            {

            }
        }

        public string GetNowUserCountData()
        {
            GetUserCountData();
            try
            {
                var now_match = Regex.Match(UserCountHomepageHtml, "<span>.+?</span>"); //정규식을 사용해서 위의 문장과 동일한 패턴을 가져온다. 
                string now_result = now_match.Value; //캡쳐 된 내용을 가져온다.
                return now_result.Substring(6, now_result.Length - 13);
            }
            catch (Exception)
            {
                MessageBox.Show("유저 데이터를 가져오는데 오류가 발생하였습니다.");
                return "0";
            }

        }

        public string GetTodayCountData()
        {
            try
            {
                var today_match = Regex.Match(UserCountHomepageHtml, @"<dt>오늘</dt>\n        <dd>.+?</dd>"); //정규식을 사용해서 위의 문장과 동일한 패턴을 가져온다. 
                string today_result = today_match.Value; //캡쳐 된 내용을 가져온다.
                return today_result.Substring(24, today_result.Length - 29);
            }
            catch (Exception)
            {
                MessageBox.Show("유저 데이터를 가져오는데 오류가 발생하였습니다.");
                return "0";
            }
        }

        public string GetTotalCountData()
        {
            try
            {
                var total_match = Regex.Match(UserCountHomepageHtml, @"<dt>전체</dt>\n        <dd>.+?</dd>"); //정규식을 사용해서 위의 문장과 동일한 패턴을 가져온다. 
                string total_result = total_match.Value; //캡쳐 된 내용을 가져온다.
                return total_result.Substring(24, total_result.Length - 29);
            }
            catch (Exception)
            {
                MessageBox.Show("유저 데이터를 가져오는데 오류가 발생하였습니다.");
                return "0";
            }
        }
    }
}

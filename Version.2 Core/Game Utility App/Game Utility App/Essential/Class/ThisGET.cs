using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameUtilityApp.Essential.Class
{
    class ThisGET
    {
        public string FolderPath()
        {
            return @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\AppData\Local\Game Utility App";
        }

        public string OpenApiKeyURL()
        {
            return @"C:\Users\cg235\Documents\key.html"; //key 값은 개발자 임의로 넣기
        }

        public string OpenApiKey()
        {
            string responseText = "";
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                responseText = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(OpenApiKeyURL());
                request.Method = "GET";
                request.Timeout = 10 * 1000;

                using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
                {
                    Stream respStream = resp.GetResponseStream();
                    using (StreamReader sr = new StreamReader(respStream))
                    {
                        responseText = sr.ReadToEnd();
                    }
                }

            }
            catch (InvalidCastException) //링크가 pc일 경우 테스트용 파일을 불러온다.
            {
                try
                {
                    responseText = System.IO.File.ReadAllText(OpenApiKeyURL());

                }
                catch (Exception)
                {

                }
            }
            catch (Exception)
            {
                return "ERROR";
            }

            var capture = Regex.Match(responseText, "<number>.+?</number>");
            int number = Convert.ToInt32(capture.Value.Replace("<number>", "").Replace("</number>", ""));

            Random random = new Random();
            number = random.Next(1, number + 1);

            var keyCapture = Regex.Match(responseText, "<key" + number + ">.+?</key" + number + ">");
            string key = keyCapture.Value.Replace("<key" + number + ">", "").Replace("</key" + number + ">", "");


            return key;
        }
    }
}

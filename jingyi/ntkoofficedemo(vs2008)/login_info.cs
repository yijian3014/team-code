using System;
using System.Web;
using System.Net;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ntkoofficedemo_vs2008_
{

    public class login_info
    {
        public Dictionary<string, string> kv = new Dictionary<string, string>();
        public string USER_NAME, USER_ID,USER_ID_ALIAS, USER_PASSWORD, USER_DEPT, USER_STATU,USER_ROLE;

        public static string PostData(string url, string indata, CookieContainer myCookieContainer)
        {
            string outdata = "";
            Uri lgcheck = new Uri("http://10.11.10.178:8099/logincheck.php");
            outdata = "/?";
            foreach (Cookie ck in myCookieContainer.GetCookies(lgcheck))
            {
                outdata += ck.Name;
                outdata += "=";
                outdata += ck.Value;
                outdata += "&";
            }
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url+outdata);
            //myHttpWebRequest.ContentType = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, */*";
            myHttpWebRequest.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, */*";           
            myHttpWebRequest.Method = "GET";
            myHttpWebRequest.KeepAlive = true;      
            myHttpWebRequest.Headers["Accept-Language"] = "zh-CN";
            myHttpWebRequest.Headers["Location"] = "/general";
            myHttpWebRequest.Referer = "http://ltc:8099/general/ipanel/";
            myHttpWebRequest.Headers["Accept-Encoding"] = "gzip,delflate";
            myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/6.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; .NET CLR 1.1.4322; InfoPath.3)";
            myHttpWebRequest.AllowAutoRedirect = true;
            HttpWebResponse hwp = (HttpWebResponse)myHttpWebRequest.GetResponse();
            Stream rep_stream = hwp.GetResponseStream();
            outdata = "";
            StreamReader stream_r = new StreamReader(rep_stream, Encoding.GetEncoding("gb2312"));
            outdata = stream_r.ReadToEnd();
            stream_r.Close();
            rep_stream.Close();
            //  outdata = outdata.Substring(1898, outdata.IndexOf('分'));
            //int i = outdata.IndexOf("id=\"on_status\"")+36;
            //int j = outdata.IndexOf("id=\"my_info\"")-i-9;
            outdata = outdata.Substring(outdata.IndexOf("id=\"on_status\"") + 36, outdata.IndexOf("id=\"my_info\"") - (outdata.IndexOf("id=\"on_status\"") + 36) - 11);
            return outdata;
        }
        public bool login(string name, string password)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            string user_info = "";
            CookieContainer ui = new CookieContainer();
            try
            {
                CookieContainer cc = new CookieContainer();
                request = (HttpWebRequest)WebRequest.Create("http://10.11.10.178:8099/logincheck.php");

                request.Method = "POST"; ;
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] postdatabyte = Encoding.UTF8.GetBytes("UNAME=" + name + "&PASSWORD=" + password);
                request.ContentLength = postdatabyte.Length;
                request.AllowAutoRedirect = true;
                request.CookieContainer = cc;
                request.KeepAlive = true;



                //提交请求

                Stream stream;
                stream = request.GetRequestStream();
                stream.Write(postdatabyte, 0, postdatabyte.Length);
                stream.Close();

                //接收响应               
                response = (HttpWebResponse)request.GetResponse();

                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);

                CookieCollection cook = response.Cookies;
                //Cookie字符串格式              
                //   String strcrook = request.CookieContainer.GetCookieHeader(request.RequestUri);

                USER_STATU = "";
                foreach (Cookie ck in cook)
                {
                    if (ck.Name == "USER_NAME_COOKIE" && ck.Value == name)
                    {
                        USER_ID_ALIAS = ck.Value;
                    }
                    if (ck.Name == "OA_USER_ID")
                    {
                        USER_ID = ck.Value;

                    }
                }

                ui.Add(cook);
                string s1 = "";
                s1 = "ISPIRIT=";
                user_info = PostData("http://ltc:8099/general/ipanel/pheader.php", s1, ui);
                //下面部分用于取得用户名USER_NAME和部门、角色等信息
                //< div id = "on_status" class="small" title="姓名：王春芳 部门：软件组 角色：OA 管理员 在线：1387小时55分">

                string[] kks = { "", "" };
                string[] sArray = Regex.Split(user_info, "\n", RegexOptions.IgnoreCase);
                foreach (string i in sArray)
                { kks = Regex.Split(i, "：", RegexOptions.IgnoreCase);
                if (kks[0] == "姓名")
                    USER_NAME = kks[1];
                    if (kks[0] == "部门")
                        USER_DEPT = kks[1];
                    if (kks[0] == "角色")
                        USER_ROLE = kks[1];
            }



                if (USER_ID_ALIAS != null && USER_ID != null)
                {
                    
                        return true;
                }
                return false;
            }

            catch (Exception er)
            {
                return false;
            }

        }
        //public void get_login_info()
        //{
        //    try
        //    {
        //        kv.Clear();
        //        SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
        //        //  ShellBrowserWindowClass shellWindows = new ShellBrowserWindowClass();

        //        string filename;
        //        // int a = shellWindows.Count;



        //        string[] str_cookie = null;
        //        string str_key, str_value;
        //        int S;

        //        foreach (SHDocVw.InternetExplorer ie in shellWindows)
        //        {

        //            filename = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
        //            if (filename.Equals("iexplore"))
        //            {
        //                if (ie.LocationURL == "http://10.11.10.178:8099/general/" || ie.LocationURL == "http://ltc:8099/general/")
        //                {
        //                    //  kv.Clear();
        //                    mshtml.IHTMLDocument2 htmlDoc = ie.Document as mshtml.IHTMLDocument2;
        //                    str_cookie = htmlDoc.cookie.Split(';');
        //                    for (int i = 0; i < str_cookie.Length; i++)
        //                    {
        //                        S = str_cookie[i].IndexOf('=');
        //                        str_key = str_cookie[i].Substring(0, S).Trim();
        //                        str_value = str_cookie[i].Substring(S + 1, str_cookie[i].Length - S - 1).Trim();

        //                        kv.Add(str_key, str_value);
        //                        //htmlDoc.cookie = 
        //                        //"USER_NAME_COOKIE=jgg; 
        //                        //SID_300 = 853cbf49;
        //                        //UI_COOKIE = 0;  
        //                        //PHPSESSID = c33f60354d3ac0dc0f6abf9ab16537f7;
        //                        //OA_USER_ID = 313131233213"
        //                    }
        //                    return kv[key];

        //                }

        //            }

        //        }


        //        Response.Write("<script>alert('错误：OA登陆帐号失效 请用IE打开OA网站重新登陆')</script>");

        //        return null;


        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message.ToString());
        //        return null;
        //    }
        //}
    //}
    //public bool loginout()
    //{
    //    return true;
    //}
}
}

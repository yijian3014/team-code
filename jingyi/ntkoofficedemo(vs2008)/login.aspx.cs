using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using mshtml;
using SHDocVw;
using System.Threading;
using System.Data.SqlClient;

namespace ntkoofficedemo_vs2008_
{

    public partial class login : System.Web.UI.Page
    {
        ntko_class db = new ntko_class();
        public static  Dictionary<string, string> kv = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
         if (TextBox1.Text !="")
                this.Page.SetFocus(TextBox2);
            else
            {
                this.Page.SetFocus(TextBox1);
            }
           
            
              
          


        }
  //      public string get_cookies(string key)
  //      {
  //try {
  //              kv.Clear();
  //              SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
                

  //          string filename;
  //            // int a = shellWindows.Count;
                


  //          string[] str_cookie = null;
  //          string str_key, str_value;
  //          int S;

  //              foreach (SHDocVw.InternetExplorer ie in shellWindows)
  //              {

  //                  filename = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
  //                  if (filename.Equals("iexplore"))
  //                  {
  //                      if (ie.LocationURL == "http://10.11.10.178:8099/general/" || ie.LocationURL == "http://ltc:8099/general/")
  //                      {
  //                          //  kv.Clear();
  //                          mshtml.IHTMLDocument2 htmlDoc = ie.Document as mshtml.IHTMLDocument2;
  //                          str_cookie = htmlDoc.cookie.Split(';');
  //                          for (int i = 0; i < str_cookie.Length; i++)
  //                          {
  //                              S = str_cookie[i].IndexOf('=');
  //                              str_key = str_cookie[i].Substring(0, S).Trim();
  //                              str_value = str_cookie[i].Substring(S + 1, str_cookie[i].Length - S - 1).Trim();

  //                              kv.Add(str_key, str_value);
  //                              //htmlDoc.cookie = 
  //                              //"USER_NAME_COOKIE=jgg; 
  //                              //SID_300 = 853cbf49;
  //                              //UI_COOKIE = 0;  
  //                              //PHPSESSID = c33f60354d3ac0dc0f6abf9ab16537f7;
  //                              //OA_USER_ID = 313131233213"
  //                          }
  //                          return kv[key];
                            
                           
  //                      }

  //                  }

  //              }

            
  //          Response.Write("<script>alert('错误：OA登陆帐号失效 请用IE打开OA网站重新登陆')</script>");

  //          return null;


  //      }
  //          catch (Exception ex)
  //          {
  //              Response.Write(ex.Message.ToString());
  //              return null;
  //          }
  //      }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            login_info lg = new login_info();
            if (lg.login(TextBox1.Text.Trim(), TextBox2.Text.Trim())&& TextBox1.Text.Trim()!="")
            {
                //存在错误，用户基本处于失控状态，因为之前登陆的用户会话都被清了。
                if (Session != null)
                    Session.RemoveAll();
                else
                    Response.Write("<script>alert('需要用铁厂OA帐号登陆')</script>");


                //判断数据库中是否有该 用户信息，如有，更新登陆时间，如没有，插入新记录，
                ntko_class db = new ntko_class();
                string que_user_str = "select top 1 * From [dzsw].[dbo].user_info WHERE oa_id='" + lg.USER_ID+"'";
                //string inst_user_str = "insert into [dzsw].[dbo].[user_info] values('" + lg.USER_ID + "','" + lg.USER_ID_ALIAS + "','"+lg.USER_NAME+"','" + TextBox2.Text.Trim() + "','" +lg.USER_DEPT +"','"+lg.USER_ROLE+"','"+DateTime.Now + "')";
                string inst_user_str = "insert into [dzsw].[dbo].[user_info] values('" + lg.USER_ID + "','" + lg.USER_ID_ALIAS + "','" + lg.USER_NAME + "','','" + lg.USER_DEPT + "','" + lg.USER_ROLE + "','" + DateTime.Now + "')";
                string update_user_str = "update  [dzsw].[dbo].[user_info] set oa_id_alias='"+lg.USER_ID_ALIAS+"', last_login_time='" + DateTime.Now + "' WHERE oa_id = '" + lg.USER_ID+"'" ;
                db.open();
                SqlDataReader dr = db.datareader(que_user_str);
                
                if (dr.Read())
                    Session.Add("user_stu", "  欢迎老朋友回来！");

                else
                {
                    dr.Close();
                    db.execsql(inst_user_str);                  
                    Session.Add("user_stu", "  欢迎新朋友！");                  
                }
                if (dr != null) dr.Close();
                Session.Add("user_id", lg.USER_ID);              
                Session.Add("user_name", lg.USER_NAME);
                Session.Add("user_dep", lg.USER_DEPT);
                Session.Add("user_role", lg.USER_ROLE);
               
                db.execsql(update_user_str);
                Response.Redirect("/default.aspx");
            }
            else
            {
                Response.Write("<script>alert('需要用铁厂OA帐号登陆')</script>");
            }
        }

        
    }
}
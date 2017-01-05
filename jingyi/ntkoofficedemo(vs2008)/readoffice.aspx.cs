using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
namespace ntkoofficedemo_vs2008_
{
    public partial class readoffice : System.Web.UI.Page
    {

        public string title, attachpath, url, newofficetype;
        public string fileid, filetitle, filename, fileother,is_hotfile;//定义表单数据
        public ftp_jy ftp_file = new ftp_jy();
        ntko_class db = new ntko_class();//实例ntko_class类

        protected void Page_Load(object sender, EventArgs e)
        {
            string local_path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + System.Configuration.ConfigurationManager.AppSettings["officePath"].ToString().Trim() + "\\";

            title = db.getdemotitle();
            attachpath = db.getattachpath();
            url = Request.QueryString["url"];
            newofficetype = Request.QueryString["newofficetype"];
            
            if (url != null && url != "")
            {
                SqlDataReader dr = db.datareader("select * from [dzsw].[dbo].[JY_BookInfo] where fileNo=" + url);
                try
                {
                    if (dr.Read())
                    {
                        fileid = dr["fileNo"].ToString().Trim();
                        filetitle = dr["fileNa"].ToString().Trim();
                        fileother = dr["fileFormats"].ToString().Trim();
                        filename = dr["fileNo"].ToString().Trim() + dr["fileNa"].ToString().Trim();
                        is_hotfile = dr["hotSpot"].ToString().Trim();
                 
                    }
                    else
                    {
                        Response.Write("<script>alert('错误：数据库数据信息错误！')</script>");
                    }
                    if (!ftp_file.FileExist(fileid,filetitle,fileother,is_hotfile))
                    {
                        Response.Write("<script>alert('错误：FTP文件服务器故障！')</script>");
                    }
                    //else
                    //    string upd_file_str = "update   dzsw.dbo.cache_files set last_login_time='" + DateTime.Now + "',access_count=access_count+1";
                    //SqlCommand udp_file = new SqlCommand(upd_file_str, db.connstr);
                    //udp_file.ExecuteNonQuery();
                    //udp_file.Dispose();

                }
                catch (Exception er)
                {
                    Response.Redirect("err404.aspx");
                }
                finally
                {
                    if (dr != null) db.close();
                }
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            string fileName = "OfficeControlSetup.exe";//客户端保存的文件名
            string filePath = Server.MapPath("officecontrol/OfficeControlSetup.exe");//路径

            //以字符流的形式下载文件
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();

        }
    }
}

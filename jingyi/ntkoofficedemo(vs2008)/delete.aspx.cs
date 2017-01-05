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


namespace ntkoofficedemo_vs2008_
{
    public partial class delete : System.Web.UI.Page
    {
        ntko_class db = new ntko_class();//实例ntko class数据类
        public string title, id, officepath, htmlpath, pdfpath, savetype;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["url"].ToString();
            savetype = Request.QueryString["savetype"].ToString();
            officepath = db.getofficepath();
            htmlpath = db.gethtmlpath();
            pdfpath = db.getpdfpath();
            title = db.getdemotitle();

            //根据文档保存的类型执行相应删除操作
            switch (savetype)
            {
                case "1":
                    DeleteOffice();
                    break;
                case "2":
                    DeleteHtml();
                    break;
                case "3":
                    DeletePdf();
                    break;
                default:
                    Response.Write("没有可执行的删除操作");
                    break;
            }
        }
        ///<summary>
        ///删除office文件
        /// </summary>
        //删除OFFICE文件
        public void DeleteOffice()
        {
            string fname = "";
            string delsql = "Delete From files WHERE fid=" + id;
            string getcmd = "select * from files WHERE fid=" + id;

            try
            {
                db.open();
                SqlDataReader dr = db.datareader(getcmd);
                while (dr.Read())
                {
                    fname = dr["fname"].ToString();
                }
                dr.Close();
                officepath = Server.MapPath(officepath).ToString();
                SqlCommand command = new SqlCommand(delsql, db.connstr);
                command.ExecuteNonQuery();
                System.IO.File.Delete(officepath + @"\" + fname);
            }
            catch (Exception e) { Response.Write(e.Message); }
            finally
            {
                Response.Write("成功删除文件:" + fname);
                db.close();
            }
        }

        ///<summary>
        ///删除html文件
        ///</summary>
        //删除HTML文件
        public void DeleteHtml()
        {
            string fname = "";
            string htmpath = "";
            string delsql = "Delete From htmls WHERE hid=" + id;
            string getcmd = "select * from htmls WHERE hid=" + id;

            try
            {
                db.open();
                SqlDataReader dr = db.datareader(getcmd);
                while (dr.Read())
                {
                    fname = dr["hname"].ToString();
                    htmpath = dr["hpath"].ToString();
                }
                dr.Close();
                if (htmpath != "")
                {
                    htmpath = Server.MapPath(htmpath).ToString();
                    System.IO.Directory.Delete(htmpath, true);
                    SqlCommand command = new SqlCommand(delsql, db.connstr);
                    command.ExecuteNonQuery();
                }
                else
                {
                    Response.Write("文件已经不存在;");
                }
            }
            catch (Exception e) { Response.Write(e.Message); }
            finally
            {
                Response.Write("成功删除文件:" + fname);
                db.close();
            }
        }

        ///<summary>
        ///删除pdf文件
        /// </summary>
        //删除pdf文件
        public void DeletePdf()
        {
            string fname = "";
            string delsql = "Delete From pdfs WHERE pid=" + id;
            string getcmd = "select * from pdfs WHERE pid=" + id;

            try
            {
                db.open();
                SqlDataReader dr = db.datareader(getcmd);
                while (dr.Read())
                {
                    fname = dr["pname"].ToString();
                }
                dr.Close();
                if (fname != "")
                {
                    officepath = Server.MapPath(pdfpath).ToString();
                    System.IO.File.Delete(officepath + @"\" + fname);
                    SqlCommand command = new SqlCommand(delsql, db.connstr);
                    command.ExecuteNonQuery();
                }
                else
                {
                    Response.Write("文件已经不存在!");
                }
            }
            catch (Exception e) { Response.Write(e.Message); }
            finally
            {
                Response.Write("成功删除文件:" + fname);
                db.close();
            }
        }
    }
}

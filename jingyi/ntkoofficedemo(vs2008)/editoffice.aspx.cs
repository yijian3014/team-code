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
    public partial class editoffice : System.Web.UI.Page
    {
        public string title, attachpath, url, newofficetype;
        public string fileid, filetitle, filename, fileother;//定义表单数据

        ntko_class db = new ntko_class();//实例ntko_class类
        protected void Page_Load(object sender, EventArgs e)
        {
            title = db.getdemotitle();
            attachpath = db.getattachpath();
            url = Request.QueryString["url"];
            newofficetype = Request.QueryString["newofficetype"];

            if (url != null && url != "")
            {
                SqlDataReader dr = db.datareader("select * from [files] where fid=" + url);
                try
                {
                    if (dr.Read())
                    {
                        fileid = dr["fid"].ToString();
                        filetitle = dr["ftitle"].ToString();
                        fileother = dr["fother"].ToString();
                        filename = dr["fname"].ToString();
                    }
                }
                catch (Exception err) { }
                finally
                {
                    if (dr != null) db.close();
                }
            }
        }
        //获取表单附件数据
        public string getAttaches()
        {
            string attRes = "";
            string aid, aname, alink;

            if (url != null && url != "")
            {
                SqlDataReader adr = db.datareader("select * from attachs where fid=" + url);
                try
                {
                    while (adr.Read())
                    {
                        aid = adr["aid"].ToString();
                        aname = adr["aname"].ToString();
                        alink = adr["apath"].ToString();
                        attRes += @"<a href=""" + alink + "/" + aname + @""" target=_blank>" + aname + @"</a>"
                            + @"<input id=""delattach"" type=""checkbox"" name=""delattach"" value=""" + aid + @"""/>&nbsp;";
                    }
                    attRes += "&nbsp;选中附件将删除!";
                }
                finally
                {
                    db.close();
                }
            }
            else
            {
                attRes = "没有附件文件!";
            }
            return attRes;
        }
    }
}

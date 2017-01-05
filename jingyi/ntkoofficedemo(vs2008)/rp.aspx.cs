using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace ntkoofficedemo_vs2008_
{
    public partial class rp : System.Web.UI.Page
    {
        public string title, attachpath, url, newofficetype, stream_serv;
        public string fileid, filetitle, filename, fileother;
        ntko_class db = new ntko_class();//实例ntko_class类
        protected void Page_Load(object sender, EventArgs e)
        {
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
                        fileid = dr["fileNo"].ToString();
                        filetitle = dr["fileNa"].ToString();
                        fileother = dr["fileFormats"].ToString();
                        filename = dr["fileNa"].ToString().Trim();
                        stream_serv =System.Configuration.ConfigurationManager.AppSettings["video_protocol_rtsp"]+System.Configuration.ConfigurationManager.AppSettings["video_srv_ip"] + System.Configuration.ConfigurationManager.AppSettings["video_srv_port"] +"/";

                    }
                }
                catch (Exception err) { }
                finally
                {
                    if (dr != null) db.close();
                }
            }
        }
    }
}
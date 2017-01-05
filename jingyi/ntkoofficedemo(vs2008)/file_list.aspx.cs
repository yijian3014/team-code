using System;
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
    public partial class file_list : System.Web.UI.Page
    {
        public string title, htmlpath, pdfpath, str_where;

        ntko_class db = new ntko_class();

        protected void Page_Load(object sender, EventArgs e)
        {
            title = db.getdemotitle();
            htmlpath = db.gethtmlpath();
            pdfpath = db.getpdfpath();

            if (Application["str_where"].ToString() != "")
            {
                Application.Lock();
                str_where = Application["str_where"].ToString();
                Application.UnLock();
            }
            else
                str_where = "";
        }


        //获取数据库文件列表
        public string getFilesList()
        {
            string sRet = "";
            SqlDataReader dr = db.datareader("  select  top 20 * from [dzsw].[dbo].[JY_BookInfo] where fileFormats in ('.docx', '.doc', '.xls', '.xlsx','.pptx','.ppt' ) " + Application["str_where"].ToString() + " ORDER BY hotspot desc");

            try
            {

                while (dr.Read())
                {

                    string fid = dr["fileNo"].ToString();
                     //sRet += "<tr onmouseover='this.className=\"mouseover\"' onmouseout='this.className=\"mouseout\"'><td width='40%'>"+
                     //      dr["fileNa"] + "</td><td width='30%'>" 
                     //      + dr["updateDate"] + "</td><td width='20%'>" 
                     //      + dr["fileFormats"] + " </td><td width='30%'>"
                     //     + "<a href=\"editoffice.aspx?officetype=" + dr["fileFormats"].ToString().Trim() + "&url=" + fid+ "\" target=_blank>&nbsp;编  辑&nbsp;</a>"
                     //    +"<a href=\"readoffice.aspx\" target=_blank>&nbsp;阅  读&nbsp;</a>"
                     //     + "<a href=\"delete.aspx?savetype=1&url=" + fid + "\" target=_blank>&nbsp;删  除&nbsp;</a>"
                     //     + "</td></tr>";

                     sRet += "<tr onmouseover='this.className=\"mouseover\"' onmouseout='this.className=\"mouseout\"'><td width='60%'>" 
                        + dr["fileNa"] + " </td><td width='20%'>" +dr["fileFormats"]+ " </td><td width='20%'>"
                        + "<a href=\"readoffice.aspx?officetype=1&url=" + fid
                        + "\"  target=_blank>&nbsp;阅  读&nbsp;</a>" + "</td></tr>";

                  
                }

            }
            finally
            {
                if (dr != null) db.close();

            }
            return sRet;
        }
        //获取数据库中视频文件列表

        public string getHtmlList()
        {
            string sRet = "";
            SqlDataReader dr = db.datareader("select top 20 * from[dzsw].[dbo].[JY_BookInfo] where fileFormats in ('.rmvb','.wmv','.rm','.avi') " + Application["str_where"].ToString() + " ORDER BY hotspot desc");
            try
            {
                while (dr.Read())
                {
                    if (dr["fileFormats"].ToString().Trim() == "rmvb")
                    {
                        string fid = dr["fileNo"].ToString();
                       // sRet += "<tr onmouseover='this.className=\"mouseover\"' onmouseout='this.className=\"mouseout\"'><td width='25%'>" 
                       //     + dr["fileNa"] + "</td><td width='30%'>" + dr["updateDate"] + "</td><td width='20%'>" + dr["fileFormats"] 
                       //     + " </td><td width='25%'>" + "<a href=\"rp.aspx?officetype=" + dr["fileFormats"].ToString().Trim() + "&url=" 
                       //     + fid + "\" target=_blank>&nbsp;观  看&nbsp;</a>"
                       ////    + "<a href=\"delete.aspx?savetype=1&url=" + fid + "\" target=_blank>&nbsp;删  除&nbsp;</a>"
                       //+ "</td></tr>";                       ;
                      
                        sRet += "<tr onmouseover='this.className=\"mouseover\"' onmouseout='this.className=\"mouseout\"'><td width='60%'>" 
                        + dr["fileNa"] + "</td><td width='20%'>" + dr["fileFormats"] + " </td><td width='20%'>"
                        + "<a href=\"rp.aspx?officetype=1&url=" + fid + "\" target =_blank>&nbsp;观  看&nbsp;</a>" + "</td></tr> ";


                    }
                    if (dr["fileFormats"].ToString().Trim() == "wmv")
                    {
                        string fid = dr["fileNo"].ToString();
                        //sRet += "<tr onmouseover='this.className=\"mouseover\"' onmouseout='this.className=\"mouseout\"'><td width='25%'>" 
                        //    + dr["fileNa"] + "</td><td width='30%'>" + dr["updateDate"] + "</td><td width='20%'>" + dr["fileFormats"]
                        //    + " </td><td width='25%'>" + "<a href=\"wmp.aspx?officetype=" + dr["fileFormats"].ToString().Trim() 
                        //    + "&url=" + fid + "\" target=_blank>&nbsp;观  看&nbsp;</a>" + "</td></tr>";
                        ///*+ "<a href=\"delete.aspx?savetype=1&url=" + fid + "\" target=_blank>&nbsp;删  除&nbsp;</a>" */
                         sRet += "<tr onmouseover='this.className=\"mouseover\"' onmouseout='this.className=\"mouseout\"'><td width='60%'>" 
                        + dr["fileNa"] + "</td><td width='20%'>" + dr["fileFormats"] + " </td><td width='20%'>" 
                        + "<a href=\"wmp.aspx?officetype=1&url=" + fid + "\" target=_blank>&nbsp;观  看&nbsp;</a>" + "</td></tr>";


                    }
                }
            }
            finally
            {
                if (dr != null) db.close();
            }
            return sRet;
        }
        //获取数据库中pdf文件列表
        /*      public string getPdfList()
             {
                 string sRet = "";
                 SqlDataReader dr = db.datareader("select * from pdfs ORDER BY pid");
                 try
                 {
                     while (dr.Read())
                     {
                         string pid = dr["pid"].ToString();
                         sRet += "<tr onmouseover='this.className=\"mouseover\"' onmouseout='this.className=\"mouseout\"'><td width='25%'>" + dr["ptitle"] + "</td><td width='30%'>" + dr["ptime"] + "</td><td width='20%'>" + dr["psize"] + " Bytes</td><td width='25%'>"
                             + "<a href=\"" + pdfpath + "/" + dr["pname"] + "\" target=_blank>&nbsp;阅  读&nbsp;</a>"
                                 + "<a href=\"delete.aspx?savetype=3&url=" + pid + "\" target=_blank>&nbsp;删  除&nbsp;</a>" + "</td></tr>";
                     }
                 }
                 finally
                 {
                     if (dr != null) db.close();
                 }
                 return sRet;
             }
             */

    }
}
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
using System.IO;

namespace ntkoofficedemo_vs2008_
{
    public partial class espedit : System.Web.UI.Page
    {
        public string title, esppath;
        ntko_class db = new ntko_class();
        protected void Page_Load(object sender, EventArgs e)
        {
            title = db.getdemotitle();
            esppath = Server.MapPath("esp");
        }
        //获取印章文件列表
        public string getEspList()
        {
            string sRet = "";
            string filename = "", filetime = "", filesize = "", fileexten = "";
            DirectoryInfo FilesInfo = new DirectoryInfo(esppath);
            FileInfo[] Files = FilesInfo.GetFiles();
            foreach (FileInfo file in Files)
            {
                filename = file.FullName.ToString();
                filename = Path.GetFileName(filename);
                fileexten = Path.GetExtension(filename).ToString();
                if (".esp" == fileexten)
                {
                    filename = filename.Replace(" ", "%20").Replace("#", "%23");
                    filetime = file.LastWriteTime.ToString();
                    filesize = file.Length.ToString();
                    sRet += "<tr onmouseover='this.className=\"mouseover\"' onmouseout='this.className=\"mouseout\"'><td width='25%'>" + filename + "</td><td width='30%'>" + filetime + "</td><td width='20%'>" + filesize + " Bytes</td><td width='25%'>"
                        + "<a onclick='editesp(\"esp/" + filename + "\");'>&nbsp;编  辑&nbsp;</a></td></tr>";
                }
            }
            return sRet;
        }
    }
}

using System;
using System.Collections;
using System.Configuration;
using System.Data;
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
    public partial class editwps : System.Web.UI.Page
    {
        public string title, fileUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            ntko_class gettitle = new ntko_class();
            title = gettitle.getdemotitle();
            fileUrl = Request.QueryString["id"];
        }
    }
}

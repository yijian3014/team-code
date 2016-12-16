using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class GDFK : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        BaseClass ds = new BaseClass();       
        GridView1.DataSource= ds.GetDataSet("select * from SJ2B_KH_KaoHe_info", "SJ2B_KH_KaoHe_info");
        GridView1.DataBind();
        
      
    }
}
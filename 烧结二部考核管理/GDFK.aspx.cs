using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class GDFK : System.Web.UI.Page
{

    public string sel_string = "select * from SJ2B_KH_KaoHe_info";  
 BaseClass ds = new BaseClass();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        GridView1.DataSource = ds.GetDataSet(sel_string, "SJ2B_KH_KaoHe_info" );
        GridView1.DataBind();
        
      
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(rbl_cx.SelectedIndex==0)
        sel_string = "select * from SJ2B_KH_KaoHe_info";
        if (rbl_cx.SelectedIndex == 1)
            sel_string = "select * from SJ2B_KH_KaoHe_info where flow_state=2";
        if (rbl_cx.SelectedIndex == 2)
            sel_string = "select * from SJ2B_KH_KaoHe_info where flow_state<>2 and cotime<>null";
        GridView1.DataSource = ds.GetDataSet(sel_string, "SJ2B_KH_KaoHe_info");
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
     
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
    }
}
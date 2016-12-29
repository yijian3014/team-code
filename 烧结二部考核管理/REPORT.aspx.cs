using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Reporting.WebForms;

public partial class REPORT : System.Web.UI.Page
{
    public static string sel_string = "select * from SJ2B_KH_KaoHe_info";
    BaseClass ds = new BaseClass();
    public DataSet ds1 = new DataSet();
    DataTable dt1 = new DataTable();
    SqlDataReader dr;
    public static string lb;
    ReportDataSource res = new ReportDataSource();

    protected void Page_Load(object sender, EventArgs e)
    { 
       if(!IsPostBack)
        { 

        tbx_bg_date.Text = DateTime.Now.Date.AddMonths(-1).ToShortDateString();
        tbx_ed_date.Text = DateTime.Now.Date.ToShortDateString();
            string ss = ObjectDataSource1.SelectMethod;

}

    }
    
    protected void btn_bg_date_Click(object sender, EventArgs e)
    {
        
        pnl_bg_date.Visible = true;

    }

    protected void btn_ed_time_Click(object sender, EventArgs e)
    {
        pnl_ed_date.Visible = true;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        //设置开始时间
        pnl_bg_date.Visible = false;
        tbx_bg_date.Text = cld_bg_date.SelectedDate.Date.ToShortDateString();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        //设置结束时间
        pnl_ed_date.Visible = false;
        tbx_ed_date.Text = cld_ed_date.SelectedDate.Date.ToShortDateString();
    }



    protected void btn_cx_Click(object sender, EventArgs e)
    {

    }
}
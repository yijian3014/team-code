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
using System.IO;

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
            btn_cx_Click(sender,e);

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
        btn_cx_Click(sender, e);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        //设置结束时间
        pnl_ed_date.Visible = false;
        tbx_ed_date.Text = cld_ed_date.SelectedDate.Date.ToShortDateString();
        btn_cx_Click(sender, e);
    }



    protected void btn_cx_Click(object sender, EventArgs e)
    {
        string lclb = "";
        string lczt = "";
        if (ddl_lclb.Text != "全部")
            lclb = " and AppraiseClass='" + ddl_lclb.Text + "'";
        if (ddl_lczt.Text != "全部")
            lczt = "  and Flow_State='" + ddl_lczt.Text + "'";
        if (ddl_lczt.Text == "其它")
            lczt = "  and Flow_State<>'完成' and Flow_State<>'废除'  ";

        sel_string = "SELECT AppraiseID, Flow_State, UserID, UserName, tc_DateTime, AppraiseClass, AppraiseTime, AppraiseGroup, AppraiseContent, DJ_ReturnTime, ClassState, ClassObjection, COTime, ChargehandOpinion, ChargehandState, Leader_1_Opinion, Leader_1_State, Leader_2_Opinion, Leader_2_State, Leader_3_Opinion, Leader_3_State FROM [dzsw].[dbo].SJ2B_KH_KaoHe_info WHERE AppraiseTime BETWEEN '"
            + tbx_bg_date.Text.Trim() + "' AND '" + tbx_ed_date.Text.Trim() + "'"
            + lczt + lclb
            + " order by AppraiseTime ,UserName";
  //ds1 = ds.GetDataSet(sel_string, "SJ2B_KH_KaoHe_info");
        SqlDataSource1.SelectCommand = sel_string;
      

        //res.DataSourceId = "ds1";

        ReportViewer1.LocalReport.DataSources.Clear();
        string path = Path.Combine(Server.MapPath(@"\"), "Report1.rdlc");
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = path;  
        ReportDataSource rptDataSource = new ReportDataSource("ds1", SqlDataSource1);
        ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
        
        ReportViewer1.LocalReport.Refresh();

    }



    protected void ddl_lczt_SelectedIndexChanged(object sender, EventArgs e)
    {
        btn_cx_Click(sender, e);
    }

    protected void ddl_lclb_SelectedIndexChanged(object sender, EventArgs e)
    {
        btn_cx_Click(sender, e);
    }

    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}
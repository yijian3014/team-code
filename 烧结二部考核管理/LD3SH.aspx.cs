using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class LD3SH : System.Web.UI.Page
{
    public static string sel_string = "select * from SJ2B_KH_KaoHe_info  order by AppraiseClass desc ,UserName";
    BaseClass ds = new BaseClass();
    public DataSet ds1 = new DataSet();
    DataTable dt1 = new DataTable();
    SqlDataReader dr;
    public static string lb;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GridView1.DataSource = ds.GetDataSet(sel_string, "SJ2B_KH_KaoHe_info");
            GridView1.DataBind();
            login_user.Text = Session["UserRName"].ToString();

            //switch (Convert.ToInt16(Session["UserID"].ToString()))
            //{
            //    case 4001:
            //        lb = "生产";
            //        break;
            //    case 4002:
            //        lb = "设备";
            //        break;
            //}
        }
        GDFK_BanLi.Visible = false;
        if (rbl_cx.SelectedIndex == 1)
        {
            BTN_BLLC.Visible = true;
        }
        else
            BTN_BLLC.Visible = false;
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbl_cx.SelectedIndex == 0)
        {
            sel_string = "select * from SJ2B_KH_KaoHe_info where flow_state<>0  order by AppraiseClass desc ,UserName";
            BTN_BLLC.Visible = false;
        }
        if (rbl_cx.SelectedIndex == 1)
        {
            sel_string = "select * from SJ2B_KH_KaoHe_info where flow_state=6";
            BTN_BLLC.Visible = true;
        }
        if (rbl_cx.SelectedIndex == 2)
        {
            sel_string = "select * from SJ2B_KH_KaoHe_info where flow_state<>6 and flow_state<>0 and Leader_3_State<>''";
            BTN_BLLC.Visible = false;
        }
        ds1 = ds.GetDataSet(sel_string, "SJ2B_KH_KaoHe_info");
        GridView1.DataSource = ds1;

        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {


        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridView1.Rows[i].BackColor = System.Drawing.Color.White;

        }
        if (GridView1.SelectedIndex >= 0)
        //表格表头索引是-1，要屏蔽
        {
            GridView1.Rows[GridView1.SelectedIndex].BackColor = System.Drawing.Color.Blue;

            // Response.Write("<script>alert(" + GridView1.Rows[GridView1.SelectedIndex].Cells.Count + ")</script>");

            //下面字段与序号一致，数据库表变，该序号应做相应调整
            //  [ID] 0
            //,[AppraiseID] 1
            //,[Flow_State] 2
            //,[UserID] 3
            //,[UserName] 4 
            //,[tc_DateTime] 5
            //,[AppraiseClass] 6 
            //,[AppraiseTime] 7
            //,[AppraiseGroup] 8
            //,[AppraiseContent] 9
            //,[DJ_ReturnTime] 10 
            //,[ClassState] 11
            //,[ClassObjection] 12
            //,[COTime] 13
            //,[ChargehandOpinion] 14
            //,[ChargehandState] 15
            //,[Leader_1_Opinion] 16
            //,[Leader_1_State] 17
            //,[Leader_2_Opinion] 18
            //,[Leader_2_State] 19
            //,[Leader_3_Opinion] 20
            //,[Leader_3_State] 21

            AppraiseID.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
            Flow_State.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text;
            UserName.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[4].Text;
            tc_DataTime.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[5].Text;
            AppraiseClass.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[6].Text;
            AppraiseTime.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[7].Text;
            AppraiseGroup.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[8].Text;
            AppraiseContent.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[9].Text;
            DJ_ReturnTime.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[10].Text;
            ClassState.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[11].Text;
            COTime1.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[12].Text;

            ClassObjection.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[13].Text;
            ChargehandOpinion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[14].Text;
            ChargehandState.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[15].Text;
            Leader_1_Opinion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[16].Text;
            Leader_1_State.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[17].Text;
            Leader_2_Opinion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[18].Text;
            Leader_2_State.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[19].Text;
            Leader_3_Opinion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[20].Text;
            Leader_3_State.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[21].Text;

        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string sqlstr_update = "";
        string next_step = "";

        if (ddl1_ld3sp_zt.SelectedIndex == 0)

            next_step = "7";

        else next_step = "0";
        if (GridView1.Rows[GridView1.SelectedIndex].Cells[13].Text == "&nbsp;")
        //判断是否是第一次办理，只记录第一次办里时间。
        {

            sqlstr_update = "update SJ2B_KH_KaoHe_info set [Leader_3_Opinion] = '" + tb1_ld3sp_yj.Text + "',[Leader_3_State]='"
                      + ddl1_ld3sp_zt.Text + "',flow_state = " + next_step
            + " where AppraiseID=" + GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.Trim();
        }
        else
        {
            sqlstr_update = "update SJ2B_KH_KaoHe_info set [Leader_3_Opinion] = '" + tb1_ld3sp_yj.Text
                 + "',[Leader_3_State]='" + ddl1_ld3sp_zt.Text + "',flow_state= " + next_step
                 + " where  AppraiseID=" + GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.Trim();
        }


        ds.ExecSQL(sqlstr_update);

        GridView1.DataSource = ds.GetDataSet(sel_string, "SJ2B_KH_KaoHe_info");
        GridView1.DataBind();

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        PostBackOptions myPostBackOptions = new PostBackOptions(this);
        myPostBackOptions.AutoPostBack = false;
        myPostBackOptions.RequiresJavaScriptProtocol = true;
        myPostBackOptions.PerformValidation = false;

        String evt = Page.ClientScript.GetPostBackClientHyperlink(sender as GridView, "Select$" + e.Row.RowIndex.ToString());
        e.Row.Attributes.Add("onclick", evt);

    }

    protected void BTN_BLLC_Click(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count > 0)
        {
            //办理流程：用于初始化待办流程窗体
            GDFK_BanLi.Visible = true;
            if (Leader_3_Opinion.Text != "&nbsp;")
                tb1_ld3sp_yj.Text = Leader_3_Opinion.Text;
            else
                tb1_ld3sp_yj.Text = "";

            if (Leader_3_State.Text == "同意" || Leader_3_State.Text == "&nbsp;")
                ddl1_ld3sp_zt.SelectedIndex = 0;
            else
                ddl1_ld3sp_zt.SelectedIndex = 1;
        }
        else
            Response.Write("<script>alert('无待办项')</script>");




    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.Cells.Count == 22)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[18].Visible = false;
            e.Row.Cells[20].Visible = false;


        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GDFK_BanLi.Visible = false;
    }
}
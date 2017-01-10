using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// ///小作更新不作数
/// </summary>
public partial class GDFK : System.Web.UI.Page
{

    public static  string sel_string = "select * from SJ2B_KH_KaoHe_info  order by AppraiseClass desc ,UserName";  
 BaseClass ds = new BaseClass();
   public  DataSet ds1 = new DataSet();
    DataTable dt1 = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack )
        {
            
            GridView1.DataSource = ds.GetDataSet(sel_string, "SJ2B_KH_KaoHe_info" );
        GridView1.DataBind();
            login_user.Text = Session["UserRName"].ToString();
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
        if(rbl_cx.SelectedIndex==0)
        { 
        sel_string = "select * from [dzsw].[dbo].SJ2B_KH_KaoHe_info  order by AppraiseClass desc ,UserName ";
            BTN_BLLC.Visible = false;
        }
        if (rbl_cx.SelectedIndex == 1)
        { 
            sel_string = "select * from [dzsw].[dbo].SJ2B_KH_KaoHe_info where flow_state='被考核人' and AppraiseGroupID='" + Session["UserID"].ToString() + "'";
            BTN_BLLC.Visible = true;
        }
        if (rbl_cx.SelectedIndex == 2)
        { 
            sel_string = "select * from [dzsw].[dbo].SJ2B_KH_KaoHe_info where (AppraiseGroupID='" 
                + Session["UserID"].ToString() +"' or UserId='" + Session["UserID"].ToString()
                + "') and flow_state<>'被考核人' and cotime<>''";
            BTN_BLLC.Visible = false;
        }
       ds1 =ds.GetDataSet(sel_string, "SJ2B_KH_KaoHe_info");
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        //Response.Write("<script> alert(" +ds1.Tables[0].Columns[0].ColumnName.ToString() + ")</script>");             
    }

    protected string get_shenhe_info()
    {

        return "";

      }
    protected string get_banli_info()
    {

        SqlDataReader dr = ds.datareader(sel_string);

        return "";
    }
    protected void get_sing_rec(string sel_rec)
    {
        SqlDataReader dr = ds.datareader(sel_rec);
        try
        {
            while (dr.Read())
            {


                string ID_ = dr["ID"].ToString();
                string AppraiseID_ = dr["AppraiseID"].ToString();
                string Flow_State_ = dr["Flow_State"].ToString();
                string UserID_ = dr["UserID"].ToString();
                string UserName_ = dr["UserName"].ToString();
                string tc_DateTime_ = dr["tc_DateTime"].ToString();
                string AppraiseClass_ = dr["AppraiseClass"].ToString();
                string AppraiseTime_ = dr["AppraiseTime"].ToString();
                string AppraiseGroup_ = dr["AppraiseGroup"].ToString();
                string AppraiseGroupID_ = dr["AppraiseGroupID"].ToString();
                string AppraiseContent_ = dr["AppraiseContent"].ToString();
                string kh_jiner_ = dr["kh_jiner"].ToString();
                string DJ_ReturnTime_ = dr["DJ_ReturnTime"].ToString();
                string ClassState_ = dr["ClassState"].ToString();
                string ClassObjection_ = dr["ClassObjection"].ToString();
                string COTime_ = dr["COTime"].ToString();
                string ChargehandOpinion_ = dr["ChargehandOpinion"].ToString();
                string ChargehandState_ = dr["ChargehandState"].ToString();
                string Leader_1_Opinion_ = dr["Leader_1_Opinion"].ToString();
                string Leader_1_State_ = dr["Leader_1_State"].ToString();
                string Leader_2_Opinion_ = dr["Leader_2_Opinion"].ToString();
                string Leader_2_State_ = dr["Leader_2_State"].ToString();
                string Leader_3_Opinion_ = dr["Leader_3_Opinion"].ToString();
                string Leader_3_State_ = dr["Leader_3_State"].ToString();
                //直接将数据DR值转STRING肤质给LABEL.TEXT会报类型错误，所以用带_的由名字符变量中转一下。
                AppraiseID.Text = AppraiseID_;
                Flow_State.Text = Flow_State_;
                UserName.Text = UserName_;
                lb_tcr_usrid.Text = UserID_;
                tc_DataTime.Text = tc_DateTime_;
                AppraiseClass.Text = AppraiseClass_;
                AppraiseTime.Text = AppraiseTime_;
                AppraiseGroup.Text = AppraiseGroup_;
                lb_AppraiseGroupID.Text = AppraiseGroupID_;
                AppraiseContent.Text = AppraiseContent_;
                tbx_kh_jiner.Text = kh_jiner_;
                DJ_ReturnTime.Text = DJ_ReturnTime_;
                ClassState.Text = ClassState_;
                COTime1.Text = COTime_;
                COTime.Text = COTime1.Text;
                ClassObjection.Text = ClassObjection_;
                ChargehandOpinion.Text = ChargehandOpinion_;
                ChargehandState.Text = ChargehandState_;
                Leader_1_Opinion.Text = Leader_1_Opinion_;
                Leader_1_State.Text = Leader_1_State_;
                Leader_2_Opinion.Text = Leader_2_Opinion_;
                Leader_2_State.Text = Leader_2_State_;
                Leader_3_Opinion.Text = Leader_3_Opinion_;
                Leader_3_State.Text = Leader_3_State_;
            }
        }
        catch (Exception er)
        {

            Response.Write (er.Message.ToString());

        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {


        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridView1.Rows[i].BackColor = System.Drawing.Color.White;
        
        }
        if (GridView1.SelectedIndex >=0)
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

            //AppraiseID.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
            //Flow_State.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text;
            //UserName.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[4].Text;

            //tc_DataTime.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[5].Text;
            //AppraiseClass.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[6].Text;
            //AppraiseTime.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[7].Text;
            //AppraiseGroup.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[8].Text;
            //AppraiseContent.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[9].Text;
            //DJ_ReturnTime.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[10].Text;
            //ClassState.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[11].Text;
            //COTime1.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[12].Text;
            //COTime.Text = COTime1.Text;
            //ClassObjection.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[13].Text;
            //ChargehandOpinion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[14].Text;
            //ChargehandState.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[15].Text;
            //Leader_1_Opinion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[16].Text;
            //Leader_1_State.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[17].Text;
            //Leader_2_Opinion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[18].Text;
            //Leader_2_State.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[19].Text;
            //Leader_3_Opinion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[20].Text;
            //Leader_3_State.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[21].Text;
            string sel_rec = "";
            sel_rec = "select * from SJ2B_KH_KaoHe_info where AppraiseID="+ GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
            get_sing_rec(sel_rec);

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //办理流程
        //0、废除
        //1、考核人
        //2、被考核人
        //3、组长
        //4、主管领导
        //5、书记
        //6、主任
        //7、完成
        //说明：任何人都可以发起考核。
        //但所遵守的原则是审核得要它的上级来进行。同意则由更上级审核，不同意则打回考核提出人。
        string sqlstr_update = "";
        string next_step = "";
        if (ddl1_gdfk_zt.SelectedIndex == 0)
        {
            if (AppraiseClass.Text == "设备" || AppraiseClass.Text == "生产")
                next_step = "组长";//默认提出人IDConvert.ToInt16(lb_tcr_usrid.Text) / 1000 = 1是点检时，则提交第三步

            else
                next_step = "书记";//其它选项转到第五步书记
            if (Convert.ToInt16(lb_tcr_usrid.Text) / 1000 > 1)
                switch (Convert.ToInt16(lb_tcr_usrid.Text) / 1000)
                {
                    case 3:
                        next_step = "主管领导";
                        break;
                    case 4:
                        next_step = "主任";
                        break;
                    case 5:
                        next_step = "主任";
                        break;
                    case 6:
                        next_step = "完成";
                        break;
                }
        }
        else
            next_step = "考核人";//选择不同意，转到第一步考核人


        if (ClassObjection.Text == "&nbsp;")
         //判断是否是第一次办理，只记录第一次办里时间。
        {

            sqlstr_update = "update SJ2B_KH_KaoHe_info set [ClassObjection] = '" + tb1_gdfk_yj.Text + 
                "',kh_jiner= '"+Convert.ToDecimal(tbx_kh_jiner.Text)+
                "[COTime]=getdate(),ClassState='"+ ddl1_gdfk_zt.Text +"',flow_state ='" + next_step
                  + " nextstep_usr_id='" + ddl_next_step.SelectedValue
            + "' where AppraiseGroup='" + Session["UserRName"].ToString() + "'"
            + " and AppraiseID="+ GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.Trim();
        }
        else
        {
            sqlstr_update = "update SJ2B_KH_KaoHe_info set [ClassObjection] = '" + tb1_gdfk_yj.Text
               + "',kh_jiner= '" + Convert.ToDecimal(tbx_kh_jiner.Text)
                 + "',ClassState='" + ddl1_gdfk_zt.Text + "',flow_state= '" + next_step
                 + " nextstep_usr_id='" + ddl_next_step.SelectedValue
                 + "' where AppraiseGroup='" + Session["UserRName"].ToString() + "'"
                 + " and AppraiseID=" + GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.Trim();
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
        //办理流程：用于初始化待办流程窗体
        if (GridView1.Rows.Count > 0)
        {
            GDFK_BanLi.Visible = true;
            if (ClassObjection.Text != "&nbsp;")
                tb1_gdfk_yj.Text = ClassObjection.Text;
            else
                tb1_gdfk_yj.Text = "";

            if (ClassState.Text == "同意" || ClassState.Text == "&nbsp;")
                ddl1_gdfk_zt.SelectedIndex = 0;
            else
                ddl1_gdfk_zt.SelectedIndex = 1;
            if (COTime.Text == "&nbsp;")
                COTime.Text = DateTime.Now.ToString();
            }
        else
            Response.Write("<script>alert('无待办项')</script>");
        //string sel_usr_inf = "select *  FROM [dzsw].[dbo].[SJ2B_KH_User] where userid='"+lb_tcr_usrid.Text
        //    +"' or userid/1000= '"+(Convert.ToInt16( Session["userid"].ToString())/1000+1)+"' or userid/1000=5";
        //ddl_next_step.DataSource= ds.GetDataSet(sel_usr_inf, "SJ2B_KH_User");
        //ddl_next_step.DataValueField = "UserId";
        //ddl_next_step.DataTextField = "UserRName";
        //ddl_next_step.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        GDFK_BanLi.Visible = false;
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
            if(e.Row.Cells.Count==22)
        {
            //e.Row.Cells[0].Visible = false;
            //e.Row.Cells[3].Visible = false;
            //e.Row.Cells[9].Visible = false;
            //  e.Row.Cells[13].Visible = false;
            //e.Row.Cells[14].Visible = false;
            //e.Row.Cells[16].Visible = false;
            //e.Row.Cells[18].Visible = false;
            //e.Row.Cells[20].Visible = false;
            

        }
    }

    protected void btn_acc_mgr_Click(object sender, EventArgs e)
    {
        Session["parent_page"] = System.IO.Path.GetFileName(Request.Path).ToString();
        Response.Redirect("user_mgr.aspx");
    }

    protected void btn_exit_Click(object sender, EventArgs e)
    {
        Session["UserID"] = "";
        Session["UserName"] = "";
        Session["UserRName"] = "";
        Session["UserRule"] = "";

        Response.Redirect("login.aspx");
    }

    protected void btn_tckh_Click(object sender, EventArgs e)
    {
        Session["parent_page"] = System.IO.Path.GetFileName(Request.Path).ToString();
        Response.Redirect("KHLR.aspx");
    }
}
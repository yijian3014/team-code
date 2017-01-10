using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class USER_MGR : System.Web.UI.Page
{
    public static string sel_string = "";
    static string mtd = "";
    BaseClass ds = new BaseClass();
    public DataSet ds1 = new DataSet();
    DataTable dt1 = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt16(Session["userid"].ToString().Trim()) / 1000 == 6)
            {
                btn_usr_add.Visible = true;
                btn_usr_del.Visible = true; 
                sel_string = "select * from [dzsw].[dbo].[SJ2B_KH_User] where userid<2000 order by UserID";              
              }
            else
            {
                btn_usr_add.Visible = false;
                btn_usr_del.Visible = false;
               sel_string = "select * from [dzsw].[dbo].[SJ2B_KH_User] where userid= " + Convert.ToInt16(Session["userid"].ToString().Trim()) +" order by UserID";
                
             }
           login_user.Text = Session["UserRName"].ToString();
        }
        GridView1.DataSource = ds.GetDataSet(sel_string, "SJ2B_KH_User");
        GridView1.DataBind();
        btn_usr_edt.Visible = true;
        if (Convert.ToInt16(Session["userid"].ToString().Trim()) / 1000 == 6)
        {
            btn_usr_add.Visible = true;
            btn_usr_del.Visible = true;
            
        }
        else
        {
            btn_usr_add.Visible = false;
            btn_usr_del.Visible = false;
        }
        GDFK_BanLi.Visible = false;
        
    }

    protected void get_sing_rec(string sel_rec)
    {
        SqlDataReader dr = ds.datareader(sel_rec);
        try
        {
            
            while (dr.Read())
            {
      //          [id]
      //,[UserId]
      //,[UserName]
      //,[UserPassWord]
      //,[UserRName]
      //,[UserRole]
    string usr_id_ = dr["UserId"].ToString();
                string usr_acc_ = dr["UserName"].ToString();
                string usr_name_ = dr["UserRName"].ToString();
                string usr_pas_ = dr["UserPassWord"].ToString();
                string usr_rul_ = "1";
               
                tbx_usr_acc.Text = usr_acc_;
                tbx_usr_name.Text = usr_name_;
                ddl_usr_rule.SelectedValue =usr_rul_;
                tbx_usr_pas.Text = usr_pas_;
                lb_usr_id.Text = usr_id_;
            }
        }
        catch (Exception er)
        {

            Response.Write(er.Message.ToString());

        }
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
            string sel_rec = "";
            sel_rec = "select * from [dzsw].[dbo].[SJ2B_KH_User] where  UserID=" + GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
            get_sing_rec(sel_rec);

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //确定修改
        try
        {
            string sqlString;
            string sql;
            sqlString = "server=DBCLUSERVER;uid=ssc;pwd=scadmin;database=dzsw";
            sql = "SJ2B_KH_UserInfoChange";
            SqlConnection sqlCon = new SqlConnection(sqlString);
            SqlCommand sqlCmd = new SqlCommand(sql, sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            //@UsId int, @UsNa Nvarchar(20),@UsPas Nvarchar(50), @UsRNa Nvarchar(20), @UsRo int, @n nvarchar(10)

            sqlCmd.Parameters.Add("@UsId", SqlDbType.Int, 20).Value = lb_usr_id.Text;
            sqlCmd.Parameters.Add("@UsNa", SqlDbType.NVarChar, 20).Value = tbx_usr_acc.Text;
            sqlCmd.Parameters.Add("@UsPas ", SqlDbType.NVarChar, 20).Value = tbx_usr_pas.Text;
            sqlCmd.Parameters.Add("@UsRNa", SqlDbType.NVarChar, 20).Value = tbx_usr_name.Text;
            sqlCmd.Parameters.Add("@UsRo", SqlDbType.Int, 20).Value = "1";
            sqlCmd.Parameters.Add("@Method", SqlDbType.NVarChar, 20).Value = mtd;

            sqlCon.Open();
            if (sqlCmd.ExecuteNonQuery() != 0)
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('信息更新成功。');</script>");       //提交成功后提示。
                sqlCon.Close();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('信息更新失败。');</script>");       //提交成功后提示。
                sqlCon.Close();
            }


            if (Convert.ToInt16(Session["userid"].ToString().Trim()) / 1000 == 6)
            {
                btn_usr_add.Visible = true;
                btn_usr_del.Visible = true;
                sel_string = "select * from [dzsw].[dbo].[SJ2B_KH_User] where userid<2000 order by UserID";
                GridView1.DataSource = ds.GetDataSet(sel_string, "SJ2B_KH_User");
                GridView1.DataBind();
            }
            else
            {
                btn_usr_add.Visible = false;
                btn_usr_del.Visible = false;
                sel_string = "select * from [dzsw].[dbo].[SJ2B_KH_User] where userid= " + Convert.ToInt16(Session["userid"].ToString().Trim()) + " order by UserID";
                GridView1.DataSource = ds.GetDataSet(sel_string, "SJ2B_KH_User");
                GridView1.DataBind();
            }
        }
        catch (Exception er)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('信息更新失败。"+er.Message.ToString()+"');</script>");       //提交成功后提示。

        }
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

  

    protected void Button2_Click(object sender, EventArgs e)
    {
        GDFK_BanLi.Visible = false;
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.Cells.Count == 22)
        {
           //可用于隐藏不想显示的列
        }
    }

    protected void btn_usr_add_Click(object sender, EventArgs e)
    {
        GDFK_BanLi.Visible = true;
        mtd = "Add";
        if (Convert.ToInt16(Session["userid"].ToString().Trim()) / 1000 == 6)
        {
            tbx_usr_acc.Enabled = true;
            tbx_usr_name.Enabled = true; ;
            ddl_usr_rule.Enabled = true;
            tbx_usr_pas.Enabled = true;
        }
        tbx_usr_acc.Text = "";
            tbx_usr_name.Text ="";
        ddl_usr_rule.SelectedIndex = 0;
        tbx_usr_pas.Text = "";
        lb_usr_id.Text = "0";

    }

    protected void btn_usr_edt_Click(object sender, EventArgs e)
    {
        GDFK_BanLi.Visible = true;
        mtd = "Change";
        if (Convert.ToInt16(Session["userid"].ToString().Trim()) / 1000 == 6)
        {
            tbx_usr_acc.Enabled = true;
            tbx_usr_name.Enabled = true;
            ddl_usr_rule.Enabled = true;
          
        }
        else
        {
            tbx_usr_acc.Enabled = false;
            tbx_usr_name.Enabled = false;
            ddl_usr_rule.Enabled = false;
          
        }
  tbx_usr_pas.Enabled = true;
    }

    protected void btn_usr_del_Click(object sender, EventArgs e)
    {
        GDFK_BanLi.Visible = true;
        mtd = "Dele";
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect(Session["parent_page"].ToString());
    }
}

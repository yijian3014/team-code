using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;

public partial class KHLR : System.Web.UI.Page
{
    public int UserID;
    public string ID;
    BaseClass bc = new BaseClass();    //调用数据库方法，在App_Code中的ljsjk.cs中。
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserID"] == "" || Session["UserID"] == null)        //判断是否已经登录,若未登录则弹出提示框并返回登录界面.
        {
            Response.Write("<script language='javascript'>alert('您尚未登陆或登陆超时');location.href='Login.aspx';</script>");
            Response.End();
        }
        if (!IsPostBack)
        {

        }
        UserID = Convert.ToInt32(Session["UserID"]);


    }


    protected void BtAdd_Click(object sender, EventArgs e)
    {

        string UserName = TBUserName.Text;
        int AppClass = Convert.ToInt32(DropDownList1.SelectedValue);
        int AppGroup = Convert.ToInt32(DropDownList2.SelectedValue);
         string AppContent = TBContent.Text;
        if (AppContent.Length <= 200)
        {
            string sqlString;
            string sql;
            sqlString = "server=DBCLUSERVER;uid=ssc;pwd=scadmin;database=dzsw";
            sql = "SJ2B_KH_Add";
            SqlConnection sqlCon = new SqlConnection(sqlString);
            SqlCommand sqlCmd = new SqlCommand(sql, sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@UserID", SqlDbType.VarChar, 20).Value = UserID;
            sqlCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 20).Value = UserName;
            sqlCmd.Parameters.Add("@DataTime", SqlDbType.VarChar, 20).Value = DateTime.Now;
            sqlCmd.Parameters.Add("@AppClass", SqlDbType.VarChar, 20).Value = AppClass;
            sqlCmd.Parameters.Add("@AppTime", SqlDbType.VarChar, 20).Value = Calendar1.SelectedDate;
            sqlCmd.Parameters.Add("@AppGroup", SqlDbType.VarChar, 20).Value = AppGroup;
            sqlCmd.Parameters.Add("@AppContent", SqlDbType.VarChar, 200).Value = AppContent;


            sqlCon.Open();
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Response.Write("<script language='javascript'>alert('添加成功。');</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('字数超过限制，请控制在200字以内。');</script>");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        this.MultiView1.ActiveViewIndex = 0;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        this.MultiView1.ActiveViewIndex = 1;
        RFrashTable();
        VisF();

    }

    void RFrashTable()
    {
        GridView1.DataSource = bc.GetDataSet("Select * From SJ2B_KH_KaoHe_info where Flow_State=1 and ClassState='不同意' and UserID=" + UserID + " and tc_DateTime+30>='" + DateTime.Now.ToString() + "' Order by UserName", "SJ2B_KH_KaoHe_info");
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
    }


    //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //this.GridView1.EditIndex = Convert.ToInt32(e.CommandSource);
    //    //    Response.Write("<script language='javascript'>alert('选择成功。');</script>");
    //    int a = this.GridView1.SelectedIndex;
    //}
    //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    this.GridView1.EditIndex = e.NewEditIndex;
    //    RFrashTable();
    //}
    //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    string ID=GridView1.DataKeys[e.RowIndex].Value.ToString();

    //}
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        VisT();
        ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        Label15.Text = ID;
        string CO = (bc.SelectSQLReturnObject("select ClassObjection from SJ2B_KH_KaoHe_info where ID=" + ID, "SJ2B_KH_KaoHe_info")).ToString();
        string AC = (bc.SelectSQLReturnObject("select AppraiseContent from SJ2B_KH_KaoHe_info where ID=" + ID, "SJ2B_KH_KaoHe_info")).ToString();
        TextBox3.Text = CO;
        TextBox4.Text = AC;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string SQLstr = "update SJ2B_KH_KaoHe_info set AppraiseContent='" + TextBox4.Text + "' where ID="+Label15.Text;
        
        if (bc.ExecSQL(SQLstr))
        {
            Response.Write("<script language='javascript'>alert('修改成功。');</script>");
            SQLstr = "update SJ2B_KH_KaoHe_info set Flow_State=3 where ID=" + Label15.Text;
            bc.ExecSQL(SQLstr);

        }
        VisF();
        RFrashTable();

    }
    void VisF()
    {
        Label12.Visible = false;
        Label14.Visible = false;
        TextBox3.Visible = false;
        TextBox4.Visible = false;
        Button1.Visible = false;
        Button2.Visible = false;
        Button3.Visible = false;
        GridView1.Visible = true;
    }
    void VisT()
    {
        Label12.Visible = true;
        Label14.Visible = true;
        TextBox3.Visible = true;
        TextBox4.Visible = true;
        Button1.Visible = true;
        Button2.Visible = true;
        Button3.Visible = true;
        GridView1.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string SQLstr = "update SJ2B_KH_KaoHe_info set Flow_State=0 where ID=" + Label15.Text;

        if (bc.ExecSQL(SQLstr))
        {
            Response.Write("<script language='javascript'>alert('该考核已删除。');</script>");
            VisF();

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        VisF();
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        this.MultiView1.ActiveViewIndex = 2;
        GridView2.DataSource = bc.GetDataSet("Select * From SJ2B_KH_KaoHe_info where  tc_DateTime+30>='" + DateTime.Now.ToString() + "' Order by AppraiseClass desc,UserName", "SJ2B_KH_KaoHe_info");
        GridView2.DataKeyNames = new string[] { "ID" };
        GridView2.DataBind();

    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ID = GridView2.DataKeys[e.RowIndex].Value.ToString();
        string AC = (bc.SelectSQLReturnObject("select AppraiseContent from SJ2B_KH_KaoHe_info where ID=" + ID, "SJ2B_KH_KaoHe_info")).ToString();
        Response.Write("<script language='javascript'>alert('考核内容为："+AC+"');</script>");
    }
}

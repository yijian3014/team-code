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
//--------------------------------声明方法
    void VisF() // 在考核反馈页面中使修改考核内容模块消失，并显示反馈信息表。
    {
        Label12.Visible = false;
        Label14.Visible = false;
        TextBox3.Visible = false;
        TextBox4.Visible = false;
        Button1.Visible = false;
        Button2.Visible = false;
        Button3.Visible = false;
        GridView1.Visible = true;
        //---------------------占位Label无实际异议，只为调整页面控件位置。
        Label16.Visible = false;
        Label17.Visible = false;
        Label18.Visible = false;
        Label19.Visible = false;
        Label20.Visible = false;
        Label21.Visible = false;
        Label22.Visible = false;
        Label23.Visible = false;
        Label26.Visible = false;
        Label27.Visible = false;
        Label28.Visible = false;
        Label29.Visible = false;
        //----------------------

    }
    void VisT() //在考核反馈模块中使反馈信息表消失，并显示修改考核内容模块。
    {
        Label12.Visible = true;
        Label14.Visible = true;
        TextBox3.Visible = true;
        TextBox4.Visible = true;
        Button1.Visible = true;
        Button2.Visible = true;
        Button3.Visible = true;
        GridView1.Visible = false;
        //---------------------占位Label无实际异议，只为调整页面控件位置。
        Label16.Visible = true;
        Label17.Visible = true;
        Label18.Visible = true;
        Label19.Visible = true;
        Label20.Visible = true;
        Label21.Visible = true;
        Label22.Visible = true;
        Label23.Visible = true;
        Label26.Visible = true;
        Label27.Visible = true;
        Label28.Visible = true;
        Label29.Visible = true;
        //----------------------
    }
    void RFrashTable()      //刷新工段反馈表。
    {
        GridView1.DataSource = bc.GetDataSet("Select * From SJ2B_KH_KaoHe_info where Flow_State=1 and ClassState='不同意' and UserID=" + UserID + " and tc_DateTime+30>='" + DateTime.Now.ToString() + "' Order by UserName", "SJ2B_KH_KaoHe_info");
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
    }
//--------------------------------
//--------------------------------按钮事件。
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)     //转换至View1---提交考核页面。
    {
        this.MultiView1.ActiveViewIndex = 0;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)     //转换至View2---工段反馈页面。
    {
        this.MultiView1.ActiveViewIndex = 1;
        RFrashTable();      //刷新工段反馈表。
        VisF();             //将修改考核模块隐藏。

    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)     //转换至View3---考核总览页面。
    {
        this.MultiView1.ActiveViewIndex = 2;

        //拴心考核总览表，并以考核类别，及考核提出人排序。
        GridView2.DataSource = bc.GetDataSet("Select * From SJ2B_KH_KaoHe_info where  tc_DateTime+30>='" + DateTime.Now.ToString() + "' Order by AppraiseClass desc,UserName", "SJ2B_KH_KaoHe_info");
        GridView2.DataKeyNames = new string[] { "ID" };
        GridView2.DataBind();

    }
        protected void BtAdd_Click(object sender, EventArgs e)  //提交考核。-----View1
    {
       
        
        

        string UserName = TBUserName.Text;
        string AppContent = TBContent.Text;
        if (UserName != string.Empty && AppContent != string.Empty)     //判断考核提出人及考核内容是否为空
        {
            //将考核类别及被考核工段转换为数字并分别给变量赋值。
            int AppClass = Convert.ToInt32(DropDownList1.SelectedValue);
            int AppGroup = Convert.ToInt32(DropDownList2.SelectedValue);

            if (AppContent.Length <= 200)   //判断考核内容是否超过200字。
            {
                //为变量赋值，并调用存储过程。
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
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('考核提交成功。');</script>");       //提交成功后提示。
                
                //提交成功后将考核提出人以及考核内容的文本框赋值为空。
                TBUserName.Text = string.Empty;
                TBContent.Text = string.Empty;
            }
            else
            {
                Response.Write("<script language='javascript'>alert('字数超过限制，请控制在200字以内。');</script>");  //考核内容超过限制提示。
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请将考核提出人及考核内容填写完整。');</script>");//内容不完整提示。
        }
    }

    protected void Button1_Click(object sender, EventArgs e)        //提交修改后的考核内容并将考核强行流转至组长当考核类别为其它时直接流转至书记---View2
    {
        string SQLstr = "update SJ2B_KH_KaoHe_info set AppraiseContent='" + TextBox4.Text + "' where ID=" + Label15.Text;

        if (bc.ExecSQL(SQLstr))
        {

            string AppClass = (bc.SelectSQLReturnObject("select AppraiseClass from SJ2B_KH_KaoHe_info where ID=" + Label15.Text, "SJ2B_KH_KaoHe_info")).ToString();
            if (AppClass == "其它")
            {
                SQLstr = "update SJ2B_KH_KaoHe_info set Flow_State=5 where ID=" + Label15.Text;
            }
            else
            {
                SQLstr = "update SJ2B_KH_KaoHe_info set Flow_State=3 where ID=" + Label15.Text;
            }

            bc.ExecSQL(SQLstr);
            Response.Write("<script language='javascript'>alert('修改成功。');</script>");
        }
        VisF();
        RFrashTable();

    }

//--------------------------------

  

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)      //借用GridView的删除事件显示工段反馈功能并将工段反馈及考核内容赋值至TextBox中。
    {
        VisT();
        ID = GridView1.DataKeys[e.RowIndex].Value.ToString();       //将所选行的主键赋值给全局变量ID。
        Label15.Text = ID;                                          //为了在其它功能中使用此ID，将ID赋值给Label15（该Label是隐藏的）。
        string CO = (bc.SelectSQLReturnObject("select ClassObjection from SJ2B_KH_KaoHe_info where ID=" + ID, "SJ2B_KH_KaoHe_info")).ToString();
        string AC = (bc.SelectSQLReturnObject("select AppraiseContent from SJ2B_KH_KaoHe_info where ID=" + ID, "SJ2B_KH_KaoHe_info")).ToString();
        TextBox3.Text = CO;
        TextBox4.Text = AC;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        string SQLstr = "delete from SJ2b_KH_KaoHe_info where ID=" + Label15.Text;

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

    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        ID = GridView2.DataKeys[e.RowIndex].Value.ToString();
        string AC = (bc.SelectSQLReturnObject("select AppraiseContent from SJ2B_KH_KaoHe_info where ID=" + ID, "SJ2B_KH_KaoHe_info")).ToString();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('考核内容为："+AC+"');</script>");

        //Response.Write("<script language='javascript'>alert('考核内容为："+AC+"');</script>");
    }
    protected void View1_Load(object sender, EventArgs e)
    {
        Calendar1.SelectedDate = DateTime.Today;
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        if (Calendar1.SelectedDate > DateTime.Today)

        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('注意：所选日期已超过今天！！！');</script>");
        }
    }
}

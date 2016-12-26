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

        string UserName= TBUserName.Text;
        int AppClass=Convert.ToInt32(DropDownList1.SelectedValue);
        int AppGroup=Convert.ToInt32(DropDownList2.SelectedValue);
        string AppContent=TBContent.Text;

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
        sqlCmd.Parameters.Add("@AppContent", SqlDbType.VarChar, 20).Value = AppContent;


        sqlCon.Open();
        sqlCmd.ExecuteNonQuery();
        sqlCon.Close();
        Response.Write("<script language='javascript'>alert('添加成功。');</script>");
    }
}
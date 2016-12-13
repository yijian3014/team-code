using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    BaseClass bc = new BaseClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string sql = "select * from SJ2b_KH_User where UserName='" + TextBoxName.Text.Trim() + "' and UserPassWord='" + TextBoxPassWord.Text.Trim() + "'";
        //Boolean bl = bc.ExecSQL("select * from JY_user where uid='" + DropDownList1.Text.Trim() + "' and upass='" + TextBox2.Text.Trim() + "'");
        //if (bl)
        int count = Convert.ToInt32(bc.SelectSQLReturnObject(sql, "SJ2b_KH_User"));
        if (count > 0)
        {
            int UserID = Convert.ToInt32(bc.SelectSQLReturnObject("select UserID from SJ2b_KH_User where UserName='" + TextBoxName.Text.Trim() + "' and UserPassWord='" + TextBoxPassWord.Text.Trim() + "'", "SJ2b_KH_User")); //。
            Session["UserName"] = UserID;
            //Session["UserName"] = TextBoxName.Text.Trim();
            switch (UserID/1000)
            {
                case 1: Response.Redirect("KHLR.aspx"); break;
                case 2: Response.Redirect("GDFK.aspx"); break; 
            }
            Response.Write("<script> alert('登录成功！"+UserID+"')</script>");
            //Response.Redirect("Main.aspx");
        }
        else
        {
            Response.Write("<script> alert('用户名或密码不正确！')</script>");
        }
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBoxName.Text=null;
        TextBoxPassWord.Text = null;
    }
}
﻿using System;
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
            Session["UserID"] = UserID;
            Session["UserName"] = TextBoxName.Text.Trim();
            Session["UserRName"] =bc.SelectSQLReturnObject("select [UserRName] from SJ2b_KH_User where UserName='" + TextBoxName.Text.Trim() + "' and UserPassWord='" + TextBoxPassWord.Text.Trim() + "'", "SJ2b_KH_User");
            Session["UserRule"] = bc.SelectSQLReturnObject("select [UserRole] from SJ2b_KH_User where UserName='" + TextBoxName.Text.Trim() + "' and UserPassWord='" + TextBoxPassWord.Text.Trim() + "'", "SJ2b_KH_User");
            string sqlString;

            sqlString = "server=DBCLUSERVER;uid=ssc;pwd=scadmin;database=dzsw";
            sql = "SJ2B_KH_CSZJ";
            SqlConnection sqlCon = new SqlConnection(sqlString);
            SqlCommand sqlCmd = new SqlCommand(sql, sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCon.Open();
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            switch (UserID/1000)
            {
                case 1: Response.Redirect("DJSH.aspx"); break;
                case 2: Response.Redirect("GDFK.aspx"); break;
                case 3: Response.Redirect("ZZSH.aspx"); break;
                case 4: Response.Redirect("LD1SH.aspx"); break;
                case 5: Response.Redirect("LD2SH.aspx"); break;
                case 6: Response.Redirect("LD3SH.aspx"); break;


            }

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

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("report.aspx");
    }

}
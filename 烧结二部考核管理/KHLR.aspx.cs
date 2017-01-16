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
            UserID = Convert.ToInt32(Session["UserID"]);
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
        Label32.Visible = false;
        TextBox5.Visible = false;
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
        Label30.Visible = false;
        Label31.Visible = false;
        Label33.Visible = false;
        Label34.Visible = false;
        Label35.Visible = false;
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
        Label32.Visible = true;
        TextBox5.Visible = true;
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
        Label30.Visible = true;
        Label31.Visible = true;
        Label33.Visible = true;
        Label34.Visible = true;
        Label35.Visible = true;
        //----------------------
    }
    void RFrashTable()      //刷新考核反馈表。
    {
        GridView1.DataSource = bc.GetDataSet("Select * From SJ2B_KH_KaoHe_info where Flow_State='考核人' and UserID=" + UserID + " and tc_DateTime+30>='" + DateTime.Now.ToString() + "' Order by UserName", "SJ2B_KH_KaoHe_info");
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
    }
    void RFDDL2()
    {
        //刷新DropDawnList2，将组长及组长一下所有人的真实名称和UserID加入其中。
        string sql = "select UserID,UserRName from SJ2B_KH_User where UserRole<=3 ";
        this.DropDownList2.DataSource = bc.GetDataSet(sql, "SJ2B_KH_User");
        this.DropDownList2.DataTextField = "UserRName";
        this.DropDownList2.DataValueField = "UserID";
        this.DropDownList2.DataBind();

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
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)     //转换至View3---考核用户工作查看页面。
    {
        switch (UserID / 1000)  //根据UserID判断需要跳转的页面。
        {
            case 1: Response.Redirect("DJSH.aspx"); break;  //点检。
            case 2: Response.Redirect("GDFK.aspx"); break;  //工段。
            case 3: Response.Redirect("ZZSH.aspx"); break;  //组长。
            case 4: Response.Redirect("LD1SH.aspx"); break; //主管领导。
            case 5: Response.Redirect("LD2SH.aspx"); break; //书记。
            case 6: Response.Redirect("LD3SH.aspx"); break; //主任。

        }
        //此ImageButten原来为跳转至考核 
        //this.MultiView1.ActiveViewIndex = 2;
        ////刷心考核总览表，并以考核类别，及考核提出人排序。
        //GridView2.DataSource = bc.GetDataSet("Select * From SJ2B_KH_KaoHe_info where  tc_DateTime+30>='" + DateTime.Now.ToString() + "' Order by AppraiseClass desc,UserName", "SJ2B_KH_KaoHe_info");
        //GridView2.DataKeyNames = new string[] { "ID" };
        //GridView2.DataBind();

    }
        protected void BtAdd_Click(object sender, EventArgs e)  //提交考核。-----View1
    {




        string UserRName = Session["UserRName"].ToString(); //提取Session值中的UserRname（用户实际姓名）。

        string KH_JinE = TBJinE.Text.ToString();            //提取文本框中的考核金额。

        string AppGID = DropDownList2.SelectedValue.ToString(); //提取DropDawnList

        string AppContent = TBContent.Text;     //提取考核内容。

        double a;   //用于判断输入字符是否为数字

        //if 1+++
        if (double.TryParse(TBJinE.Text, out a))    //判断TBJinE.Text是否可以转换为double型的a。
        {

            //if2+++
            if (AppContent != string.Empty)     //判断考核提出人及考核内容是否为空
            {
                //将考核类别及被考核工段转换为数字并分别给变量赋值。
                int AppClass = Convert.ToInt32(DropDownList1.SelectedValue);

                string AppGroup = DropDownList2.SelectedItem.ToString();

                //if 3———
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
                    sqlCmd.Parameters.Add("@UserID", SqlDbType.VarChar, 20).Value = UserID; //考核提出人ID。

                    sqlCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 20).Value = UserRName;    //考核提出人真实姓名

                    sqlCmd.Parameters.Add("@DataTime", SqlDbType.VarChar, 20).Value = DateTime.Now; //考核提出时间。

                    sqlCmd.Parameters.Add("@AppClass", SqlDbType.VarChar, 20).Value = AppClass;     //考核类别。

                    sqlCmd.Parameters.Add("@AppTime", SqlDbType.VarChar, 20).Value = Calendar1.SelectedDate;    //考核事件发生时间。

                    sqlCmd.Parameters.Add("@AppGroup", SqlDbType.VarChar, 20).Value = AppGroup; // 被考核人真实姓名。

                    sqlCmd.Parameters.Add("@AppGID", SqlDbType.VarChar, 20).Value = AppGID; //被考核人ID。

                    sqlCmd.Parameters.Add("@AppContent", SqlDbType.VarChar, 200).Value = AppContent;    //考核内容。

                    sqlCmd.Parameters.Add("@AppMoney", SqlDbType.VarChar, 20).Value = KH_JinE;  //考核金额。


                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('考核提交成功。');</script>");       //提交成功后提示。

                    //提交成功后将考核提出人以及考核内容的文本框赋值为空。
                    TBJinE.Text = string.Empty;
                    TBContent.Text = string.Empty;


                }

                //else 3———
                else
                {
                    Response.Write("<script language='javascript'>alert('字数超过限制，请控制在200字以内。');</script>");  //考核内容超过限制提示。

                }//if 3及其else结束———
            } 

            //else 2===
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请将考核提出人及考核内容填写完整。');</script>");//内容不完整提示。
            }//if 2及其else结束===
        }

        //else 1+++
        else
        { 
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('`考核金额必须为数字，请重新输入。');</script>");
        TBJinE.Text = null;
        }//if 1及其else结束+++
    }

    protected void Button1_Click(object sender, EventArgs e)        //提交修改后的考核内容并将考核强行流转至考核提出人的上一级，当考核类别为其它时直接流转至书记或主任---View2
    {
        double a;
        if (double.TryParse(TextBox5.Text, out a))
        {
            string SQLstr = "update SJ2B_KH_KaoHe_info set AppraiseContent='" + TextBox4.Text + "' where ID=" + Label15.Text;
            string SQLstr1 = "update SJ2B_KH_KaoHe_info set kh_jiner='" + TextBox5.Text + "' where ID=" + Label15.Text;
            int AppID = UserID / 1000;
            string F_State;
            switch (AppID)
            {
                case 1: F_State = "组长"; break;
                case 3: F_State = "主管领导"; break;
                case 4: F_State = "书记"; break;
                case 5: F_State = "主任"; break;
                case 6: F_State = "完成"; break;
                default: F_State = null; break;

            }
            if (bc.ExecSQL(SQLstr)&&bc.ExecSQL(SQLstr1))
            {
                SQLstr = "update SJ2B_KH_KaoHe_info set AppraiseContent='" + TextBox5.Text + "' where ID=" + Label15.Text;
                SQLstr = "update SJ2B_KH_KaoHe_info set DJ_ReturnTime='" + DateTime.Now.ToString() + "' where ID=" + Label15.Text;
                bc.ExecSQL(SQLstr);
                string AppClass = (bc.SelectSQLReturnObject("select AppraiseClass from SJ2B_KH_KaoHe_info where ID=" + Label15.Text, "SJ2B_KH_KaoHe_info")).ToString();
                if (AppClass == "其它")
                {
                    if (AppID == 6)
                    {
                        SQLstr = "update SJ2B_KH_KaoHe_info set Flow_State='考核完成' where ID=" + Label15.Text;
                    }
                    else if (AppID == 5)
                    {
                        SQLstr = "update SJ2B_KH_KaoHe_info set Flow_State='主任' where ID=" + Label15.Text;
                    }
                    else
                    {
                        SQLstr = "update SJ2B_KH_KaoHe_info set Flow_State='书记' where ID=" + Label15.Text;
                    }

                }
                else
                {
                    SQLstr = "update SJ2B_KH_KaoHe_info set Flow_State='" + F_State + "' where ID=" + Label15.Text;
                }

                bc.ExecSQL(SQLstr);
                Response.Write("<script language='javascript'>alert('修改成功。');</script>");
            }
            VisF();
            RFrashTable();
        }
        else
        {
            Response.Write("<script language='javascript'>alert('考核金额只能为数字，请重新输入。');</script>");
        }

    }

//--------------------------------

  

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)      //借用GridView的删除事件显示工段反馈功能并将工段反馈及考核内容赋值至TextBox中。
    {
        VisT();
        ID = GridView1.DataKeys[e.RowIndex].Value.ToString();       //将所选行的主键赋值给全局变量ID。
        Label15.Text = ID;                                          //为了在其它功能中使用此ID，将ID赋值给Label15（该Label是隐藏的）。
        string FK = (bc.SelectSQLReturnObject("select KHFK_YJ from SJ2B_KH_KaoHe_info where ID=" + ID, "SJ2B_KH_KaoHe_info")).ToString();
        string AC = (bc.SelectSQLReturnObject("select AppraiseContent from SJ2B_KH_KaoHe_info where ID=" + ID, "SJ2B_KH_KaoHe_info")).ToString();
        string JE =(bc.SelectSQLReturnObject("select kh_jiner from SJ2B_KH_KaoHe_info where ID=" + ID, "SJ2B_KH_KaoHe_info")).ToString();
        TextBox3.Text = FK;
        TextBox4.Text = AC;
        TextBox5.Text = JE;


    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        string SQLstr = "delete from SJ2b_KH_KaoHe_info where ID=" + Label15.Text;

        if (bc.ExecSQL(SQLstr))
        {
            Response.Write("<script language='javascript'>alert('该考核已删除。');</script>");
           

            this.MultiView1.ActiveViewIndex = 1;
            RFrashTable();      //刷新工段反馈表。
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
        RFDDL2();
        Calendar1.SelectedDate = DateTime.Today;
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        if (Calendar1.SelectedDate > DateTime.Today)

        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('注意：所选日期已超过今天！！！');</script>");
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (UserID / 1000 <= Convert.ToInt32(DropDownList2.SelectedValue) / 1000&&Convert.ToInt32(DropDownList2.SelectedValue)/1000!=2)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('考核人级别应高于被考核人，请重新选择');</script>");
            RFDDL2();
        }

    }
    protected void tbx_check_Click(object sender, EventArgs e)
    {
        TextBox TBX = (TextBox)sender;
        TBX.Text.Replace("<", "<'");
        TBX.Text.Replace(">", "'>");
    }
}

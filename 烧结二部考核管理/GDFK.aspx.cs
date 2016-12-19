using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class GDFK : System.Web.UI.Page
{

    public string sel_string = "select * from SJ2B_KH_KaoHe_info";  
 BaseClass ds = new BaseClass();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack )
        {
        GridView1.DataSource = ds.GetDataSet(sel_string, "SJ2B_KH_KaoHe_info" );
        GridView1.DataBind();
         }
        GDFK_BanLi.Visible = false;
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(rbl_cx.SelectedIndex==0)
        sel_string = "select * from SJ2B_KH_KaoHe_info";
        if (rbl_cx.SelectedIndex == 1)
            sel_string = "select * from SJ2B_KH_KaoHe_info where flow_state=2";
        if (rbl_cx.SelectedIndex == 2)
            sel_string = "select * from SJ2B_KH_KaoHe_info where flow_state<>2 and cotime<>null";
        GridView1.DataSource = ds.GetDataSet(sel_string, "SJ2B_KH_KaoHe_info");
        GridView1.DataBind();
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
    protected string get_huizhong_info()
    {
        string sRet = "";
        SqlDataReader dr = ds.datareader(sel_string);
        try
        {
            while (dr.Read())
            {

                string ID = dr["ID"].ToString();
                string AppraiseID = dr["AppraiseID"].ToString();
                string Flow_State = dr["Flow_State"].ToString();
                string UserID = dr["UserID"].ToString();
                string UserName = dr["UserName"].ToString();
                string tc_DateTime = dr["tc_DateTime"].ToString();
                string AppraiseClass = dr["AppraiseClass"].ToString();
                string AppraiseTime = dr["AppraiseTime"].ToString();
                string AppraiseGroup = dr["AppraiseGroup"].ToString();
                string AppraiseContent = dr["AppraiseContent"].ToString();
                string DJ_ReturnTime = dr["DJ_ReturnTime"].ToString();
                string ClassState = dr["ClassState"].ToString();
                string ClassObjection = dr["ClassObjection"].ToString();
                string COTime = dr["COTime"].ToString();
                string ChargehandOpinion = dr["ChargehandOpinion"].ToString();
                string ChargehandState = dr["ChargehandState"].ToString();
                string Leader_1_Opinion = dr["Leader_1_Opinion"].ToString();
                string Leader_1_State = dr["Leader_1_State"].ToString();
                string Leader_2_Opinion = dr["Leader_2_Opinion"].ToString();
                string Leader_2_State = dr["Leader_2_State"].ToString();
                string Leader_3_Opinion = dr["Leader_3_Opinion"].ToString();
                string Leader_3_State = dr["Leader_3_State"].ToString();
                sRet += "<div >" + UserName + AppraiseID + Flow_State + AppraiseClass + "</div>";
            }
        }
        catch (Exception er)
        {

            Response.Redirect(er.Message.ToString());

        }

        return sRet;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {


        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridView1.Rows[i].BackColor = System.Drawing.Color.White;
        }
        
        GridView1.Rows[GridView1.SelectedIndex].BackColor = System.Drawing.Color.Blue;

        
        AppraiseID.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text;
        Flow_State.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
        UserName.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text;
        tc_DataTime.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[3].Text;
        AppraiseClass.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[4].Text;
        AppraiseTime.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[5].Text;
        AppraiseGroup.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[6].Text;
        AppraiseContent.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[7].Text;
        IS_TimeOut.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[8].Text;
        ClassState.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[9].Text;
        ClassObjection.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[10].Text;
        COTime.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[11].Text;
        ChargehandOpinion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[12].Text;
        ChargehandState.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[13].Text;
        Leader_1_Opinion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[14].Text;
        Leader_1_State.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[15].Text;
        Leader_2_Opinion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[16].Text;
        Leader_2_State.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[17].Text;
        Leader_3_Opinion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[18].Text;
        Leader_3_State.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[19].Text;
    


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;

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
}
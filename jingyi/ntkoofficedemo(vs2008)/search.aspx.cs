using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ntkoofficedemo_vs2008_
{
    public partial class search : System.Web.UI.Page
    {
        public string title, htmlpath, pdfpath, s_where;
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();

        ntko_class db = new ntko_class();
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text.ToString().Trim() != "")
            {
                ds2 = db.dataset("select * from [dzsw].[dbo].[JY_Classinfo] where ClassLevel=2 and CompleteNo/1000="
                    + DropDownList1.SelectedItem.Value);
                this.DropDownList2.DataSource = ds2.Tables[0].DefaultView;
                this.DropDownList2.DataTextField = "ClassName";
                this.DropDownList2.DataValueField = "CompleteNo";
                this.DropDownList2.DataBind();

            }

        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedItem.Text.ToString().Trim() != "")
            {
                ds3 = db.dataset("select * from [dzsw].[dbo].[JY_Classinfo] where ClassLevel=3 and CompleteNo/1000="
                    + DropDownList2.SelectedItem.Value);

                this.DropDownList3.DataSource = ds3.Tables[0].DefaultView;
                this.DropDownList3.DataTextField = "ClassName";
                this.DropDownList3.DataValueField = "CompleteNo";
                this.DropDownList3.DataBind();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();
            DataSet ds4 = new DataSet();
            if (!this.IsPostBack)
            {
                ds1 = db.dataset("select * from [dzsw].[dbo].[JY_Classinfo] where ClassLevel=1");

                ds4 = db.dataset("select * from [dzsw].[dbo].[JY_BookTags]");

                try
                {


                    this.DropDownList1.DataSource = ds1.Tables[0].DefaultView;
                    this.DropDownList1.DataTextField = "ClassName";
                    this.DropDownList1.DataValueField = "CompleteNo";
                    this.DropDownList1.DataBind();
                    this.DropDownList1.Items.Insert(0, "");

                    this.DropDownList4.DataSource = ds4.Tables[0].DefaultView;
                    this.DropDownList4.DataTextField = "TagsName";
                    this.DropDownList4.DataValueField = "Id";
                    this.DropDownList4.DataBind();
                    this.DropDownList4.Items.Insert(0, "");

                    this.DropDownList2.Items.Insert(0, "");
                    this.DropDownList3.Items.Insert(0, "");

                }
                catch (Exception er)
                {
                    Response.Redirect(er.Message.ToString());
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            s_where = "";
            if (DropDownList1.SelectedItem.Text.ToString().Trim() != "")
                s_where += " and ClassOneNo='" + DropDownList1.SelectedItem.Value.ToString().Trim() + "'";
            if (DropDownList2.SelectedItem.Text.ToString().Trim() != "")
                s_where += " and  ClassTwoNo='" + DropDownList2.SelectedItem.Value.ToString().Trim() + "'";
            if (DropDownList3.SelectedItem.Text.ToString().Trim() != "")
                s_where += " and ClassThrNo='" + DropDownList3.SelectedItem.Value.ToString().Trim() + "'";

            if (DropDownList4.SelectedItem.Text.ToString().Trim() != "")
                s_where += " and ( TagsOne='" + DropDownList4.SelectedItem.Text.ToString().Trim() + "' or TagsTwo = '" + DropDownList4.SelectedItem.Text.ToString().Trim() + "' or TagsThr = '" + DropDownList4.SelectedItem.Text.ToString().Trim() + "')";
            if (TextBox1.Text != "")
                s_where += " and fileNa like '%" + TextBox1.Text.Trim() + "%'";

            Application["str_where"] = s_where;
            Server.Transfer("file_list.aspx", true);
        }
    }
}
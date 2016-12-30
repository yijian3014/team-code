<%@ Page Language="C#" AutoEventWireup="true" CodeFile="REPORT.aspx.cs" Inherits="REPORT" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 </head>
<body >
   
    <form id="form1" runat="server"  style="text-align:center;width:auto 95%;margin:0 auto;height:auto 65%;" >
        <div style="text-align:center;margin:0 auto;"  >
           
            <asp:TextBox ID="tbx_bg_date" runat="server" Enabled="False" Width="94px"></asp:TextBox> 
      
            <asp:Button ID="btn_bg_date" runat="server" Text="开始时间" OnClick="btn_bg_date_Click" />
              
           <asp:TextBox ID="tbx_ed_date" runat="server" Enabled="False" Width="94px"></asp:TextBox> 
            <asp:Button ID="btn_ed_time" runat="server" Text="结束时间" OnClick="btn_ed_time_Click" />
            <asp:Label ID="Label3" runat="server" Text="查找关键字：" Visible="False"></asp:Label>
            <asp:TextBox ID="tbx_gjz" runat="server" Visible="False"></asp:TextBox>
       
            <asp:Button ID="btn_cx" runat="server" OnClick="btn_cx_Click" Text="查询" Width="90px" Visible="False" />
       
            </div> 
        <div style="text-align:left;margin:0 auto;width:95%;float:none; height:50%;">
        <table style="text-align:left;margin:0 auto;float:none;width:30%">
            <tr>
                <td >
 <asp:Panel ID="pnl_bg_date" runat="server" Visible="False"  style="Z-INDEX: 140;width:269px;text-align:center;margin:0; POSITION: absolute; TOP:35px" HorizontalAlign="Center">
<asp:Calendar ID="cld_bg_date" runat="server" BackColor="White"  OnSelectionChanged="Button4_Click"></asp:Calendar>
             <asp:Button ID="Button4" runat="server" Text="确定" OnClick="Button4_Click" Visible="False" />
       </asp:Panel>  
                </td>
            </tr>
                  <tr>
                <td   >
   <asp:Panel ID="pnl_ed_date" runat="server" Visible="False" style="Z-INDEX: 141;width:269px;text-align:center;margin:0; POSITION: absolute; TOP: 35px" HorizontalAlign="Center">
  <asp:Calendar ID="cld_ed_date" runat="server" Visible="True" BackColor="White" OnSelectionChanged="Button3_Click"></asp:Calendar>
                <asp:Button ID="Button3" runat="server" Text="确定" OnClick="Button3_Click" Visible="False" />
            </asp:Panel>
                  
                </td>
            </tr>
            
        </table>
  </div>
         

    <div style="text-align:center;margin:0 auto;width:95%;float:none; height:50%;">
    
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="12pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="800px" ShowBackButton="False" ShowFindControls="False">
           <%-- <LocalReport ReportPath="Report1.rdlc">
                <DataSources>
                   <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>--%>
           
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="dzswDataSetTableAdapters.SJ2B_KH_KaoHe_infoTableAdapter"></asp:ObjectDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dzswConnectionString %>" SelectCommand="SELECT AppraiseID, Flow_State, UserID, UserName, tc_DateTime, AppraiseClass, AppraiseTime, AppraiseGroup, AppraiseContent, DJ_ReturnTime, ClassState, ClassObjection, COTime, ChargehandOpinion, ChargehandState, Leader_1_Opinion, Leader_1_State, Leader_2_Opinion, Leader_2_State, Leader_3_Opinion, Leader_3_State FROM SJ2B_KH_KaoHe_info WHERE (AppraiseTime BETWEEN @bg_date AND @ed_date)">
            <SelectParameters>
                <asp:ControlParameter ControlID="tbx_bg_date" Name="bg_date" PropertyName="Text" />
                <asp:ControlParameter ControlID="tbx_ed_date" Name="ed_date" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>

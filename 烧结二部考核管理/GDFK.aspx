<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GDFK.aspx.cs" Inherits="GDFK" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <style type="text/css">
        .auto-style2 {
            width: 12.5%;
            height: 36px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" style="width:950px";>
        <div style="width:80%;text-align:center;float:none;margin:0 auto;">
             <asp:Label ID="Label3" runat="server" Text="考核表单" Font-Bold="True" Font-Size="Larger"></asp:Label>
            <hr />

        </div>
      <%--  <div style="width:80%;text-align:center;float:none;margin:0 auto;">
             <%=get_shenhe_info() %>

        </div>

             <div style="width:80%;text-align:center;float:none;margin:0 auto;">
             <%=get_banli_info() %>

        </div>
             <div style="width:80%;text-align:center;float:none;margin:0 auto;">
             <%=get_huizhong_info() %>

        </div>--%>

<div style="width:80%;text-align:center;float:none;margin:0 auto;">
    <table style="width:100%;text-align:left;">
        <tr >
            <td style="text-align:left;" class="auto-style2">
<asp:Label ID="Label4" runat="server" Text="考核编号:"></asp:Label>
            </td>
            <td style="text-align:left;" class="auto-style2">
  <asp:Label ID="AppraiseID" runat="server" Text="空"></asp:Label>
            </td>
            <td style="text-align:left;" class="auto-style2">
  <asp:Label ID="Label5" runat="server" Text="程序流转状态:"></asp:Label>
            </td>
            <td style="text-align:left;" class="auto-style2">
   <asp:Label ID="Flow_State" runat="server" Text="空"></asp:Label>
            </td>
            <%--</tr>
        <tr>--%>
            <td style="text-align:left;" class="auto-style2">
 <asp:Label ID="Label6" runat="server" Text="用户名:"></asp:Label>
            </td>
             <td style="text-align:left;" class="auto-style2">
 <asp:Label ID="UserName" runat="server" Text="空"></asp:Label>
            </td>
             <td style="text-align:left;" class="auto-style2">
  <asp:Label ID="Label7" runat="server" Text="提出考核时间:"></asp:Label>
            </td>
             <td style="text-align:left;" class="auto-style2">
   <asp:Label ID="tc_DataTime" runat="server" Text="空"></asp:Label>
            </td>
        </tr>
        <tr>
             <td>
  <asp:Label ID="Label8" runat="server" Text="考核种类:"></asp:Label>
            </td>
             <td>
  <asp:Label ID="AppraiseClass" runat="server" Text="空"></asp:Label>
            </td> 
            <td>
  <asp:Label ID="Label9" runat="server" Text="考核发生时间:"></asp:Label>
            </td> 
            <td>
   <asp:Label ID="AppraiseTime" runat="server" Text="空"></asp:Label>
            </td>
      <%--  </tr>
        <tr>--%>
             <td>
 <asp:Label ID="Label12" runat="server" Text="被考核工段:"></asp:Label>
            </td>
             <td>
  <asp:Label ID="AppraiseGroup" runat="server" Text="空"></asp:Label>
            </td>
            </tr>
        </table>


    <table style="width:100%;text-align:left;">
        <tr>
             <td  style="width:100%;text-align:left;column-span:all;">
 <asp:Label ID="Label14" runat="server" Text="考核内容:"></asp:Label> 
            </td>
</tr>
        <tr>
             <td style="width:100%;column-span:all;">
  <asp:Label ID="AppraiseContent" runat="server" Text="空"></asp:Label>
            </td>
             

        </tr>
        </table>


    <table style="width:100%;text-align:left;">
        <tr>
<td>
 <asp:Label ID="Label15" runat="server" Text="点检操作是否超时:"></asp:Label>
            </td>
             <td>
  <asp:Label ID="IS_TimeOut" runat="server" Text="空"></asp:Label>
            </td>
             <td>
  <asp:Label ID="Label16" runat="server" Text="工段反馈状态:"></asp:Label>
            </td>
             <td>
 <asp:Label ID="ClassState" runat="server" Text="空"></asp:Label>
            </td>
             <td>
  <asp:Label ID="Label18" runat="server" Text="工段意见提出时间:"></asp:Label>
            </td> 
            <td>
<asp:Label ID="Label19" runat="server" Text="空"></asp:Label>

            </td>
        </tr>
        </table>
    <table style="width:100%;text-align:left;">
        <tr>
             <td style="width:100%;text-align:left;column-span:all;">
 <asp:Label ID="Label17" runat="server" Text="工段意见:"></asp:Label>
            </td>
            </tr>
        <tr>
             <td style="width:100%;text-align:left;column-span:all;">
  <asp:Label ID="ClassObjection" runat="server" Text="空"></asp:Label>
            </td>
            </tr>
          
        <tr>
            <td style="width:100%;text-align:left;column-span:all;">
   <asp:Label ID="Label20" runat="server" Text="组长审批意见:"></asp:Label>
            </td>
            </tr>
       <tr>
             <td style="width:100%;text-align:left;column-span:all;">
   <asp:Label ID="ChargehandOpinion" runat="server" Text="空"></asp:Label>
            </td>
           </tr>
       <tr>
           
             <td style="width:100%;text-align:left;column-span:all;">
   <asp:Label ID="Label21" runat="server" Text="组长审批状态:"></asp:Label>
            </td>
           </tr>
       <tr>
             <td style="width:100%;text-align:left;column-span:all;">
     <asp:Label ID="ChargehandState" runat="server" Text="空"></asp:Label>
            </td>
           </tr>
        <tr>
            <td style="width:100%;text-align:left;column-span:all;">
<asp:Label ID="Label22" runat="server" Text="主管领导审批意见:"></asp:Label>
            </td>
            </tr>
       <tr>
            <td style="width:100%;text-align:left;column-span:all;">
 <asp:Label ID="Leader_1_Opinion" runat="server" Text="空"></asp:Label>
            </td>
           </tr>
       <tr>
            <td style="width:100%;text-align:left;column-span:all;">
  <asp:Label ID="Label23" runat="server" Text="主管领导审批状态:"></asp:Label>
            </td>
           </tr>
       <tr>
            <td style="width:100%;text-align:left;column-span:all;">
 <asp:Label ID="Leader_1_State" runat="server" Text="空"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:100%;text-align:left;column-span:all;">
                <asp:Label ID="Label28" runat="server" Text="书记审批意见:"></asp:Label>
            </td>
            </tr>
       <tr>
            <td style="width:100%;text-align:left;column-span:all;">
                <asp:Label ID="Leader_2_Opinion" runat="server" Text="空"></asp:Label>
            </td>
           </tr>
       <tr>
            <td style="width:100%;text-align:left;column-span:all;">
                 <asp:Label ID="Label30" runat="server" Text="书记审批状态:"></asp:Label>
            </td>
           </tr>
       <tr>
            <td style="width:100%;text-align:left;column-span:all;">
<asp:Label ID="Leader_2_State" runat="server" Text="空"></asp:Label>
            </td>

        </tr>
        <tr>
            <td style="width:100%;text-align:left;column-span:all;">
                 <asp:Label ID="Label24" runat="server" Text="主任审批意见:"></asp:Label>
            </td>
            </tr>
       <tr>
            <td style="width:100%;text-align:left;column-span:all;">
                 <asp:Label ID="Leader_3_Opinion" runat="server" Text="空"></asp:Label>
            </td>
           </tr>
       <tr>
            <td style="width:100%;text-align:left;column-span:all;">
                 <asp:Label ID="Label32" runat="server" Text="主任审批状态:"></asp:Label>
            </td>
           </tr>
       <tr>
            <td style="width:100%;text-align:left;column-span:all;">
                   <asp:Label ID="Leader_3_State" runat="server" Text="空"></asp:Label>
            </td>
        </tr>
    </table>
 </div>



        
        <div id="GDFK_BanLi" runat="server" style="width:80%;text-align:center;float:none;margin:0 auto;">
    <asp:Label ID="Label1" runat="server" Text="工段反馈" Font-Bold="True" Font-Size="Larger"></asp:Label>
<hr />
            <table style="width:100%">
                <tr>
                    <td>
 <asp:Label ID="Label10" runat="server" Text="工段反馈状态:"></asp:Label>
          
                    </td>
                     <td>
  <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>同意</asp:ListItem>
                <asp:ListItem>不同意</asp:ListItem>
            </asp:DropDownList>
                    </td>
                    <td style="width:30%" >

                    </td>
                     <td>
    <asp:Label ID="Label11" runat="server" Text="工段意见提出时间:"></asp:Label>
                    </td>
                     <td>
  <asp:Label ID="COTime" runat="server" Text="工段意见提出时间"></asp:Label> 
                    </td>
                </tr>
            </table>
       <table style="width:100%">
           <tr>
               <td style="text-align:left;">
        <asp:Label ID="Label13" runat="server" Text="工段意见:" ></asp:Label>
               </td>
               </tr>
           <tr>
               <td colspan="3" >
            <asp:TextBox ID="TextBox1" runat="server" Height="225px" Width="100%" TextMode="MultiLine"></asp:TextBox>
               </td>
           </tr>
      <tr>
               <td colspan="3">  
            <asp:Button ID="Button1" runat="server" Text="确认" Width="99px" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="取消" Width="99px" />
</td> 
      </tr>
 </table>  
        </div>
        
<div style="text-align:center;margin:0 auto;width:80%;float:none;" >
    
        <asp:Label ID="Label2" runat="server" Text="相关考核汇总" Font-Bold="True" Font-Size="Larger"></asp:Label>
<hr  /> 

</div>
        <div style="text-align:right;margin:0 auto;float:none;width:80%;">
            <asp:RadioButtonList ID="rbl_cx" runat="server" RepeatDirection="Horizontal" TextAlign="Right" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" >
                <asp:ListItem Selected="True" Value="0">总览</asp:ListItem>
                <asp:ListItem Value="1">待办理</asp:ListItem>
                <asp:ListItem Value="2">已办结</asp:ListItem>
            </asp:RadioButtonList>

        </div>
          <div style="width:80%;text-align:center;float:none;margin:0 auto;overflow:auto">
         <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
        </asp:GridView>
       </div>
    </form>
</body>
</html>

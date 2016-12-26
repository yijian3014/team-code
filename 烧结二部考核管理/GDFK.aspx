<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GDFK.aspx.cs" Inherits="GDFK" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>


    <style type="text/css">
        .auto-style1 {
            width: 80%;
            float: none;
            overflow: auto;
        }
        .auto-style2 {
            width: 233px;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server" style="text-align:center;width:950px;margin:0 auto;" >
        <asp:Label ID="Label26" runat="server" Text="烧结二部考核管理" Font-Bold="True" Font-Size="Larger"></asp:Label> 
        <div style="text-align:right;">            
               <hr  />
        <asp:Label ID="Label25" runat="server" Text="用户名："></asp:Label>
        <asp:Label ID="login_user" runat="server" Text=""></asp:Label>

     
            </div>
        <div style="text-align:center;margin:0 auto;width:80%;float:none;" >
    
        <asp:Label ID="Label2" runat="server" Text="相关考核汇总" Font-Bold="False" Font-Size="Larger"></asp:Label>
<hr  /> 
</div>

        <div style="text-align:right;margin:0 auto;float:none;width:80%;">
            <table style="width:100%">
                <tr>
                    <td style="width:50%">
   <asp:RadioButtonList ID="rbl_cx" runat="server" RepeatDirection="Horizontal" TextAlign="Right" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" >
                <asp:ListItem Selected="True" Value="0">总览</asp:ListItem>
                <asp:ListItem Value="1">待办理</asp:ListItem>
                <asp:ListItem Value="2">已办结</asp:ListItem>
            </asp:RadioButtonList>
                    </td>
                    <td style="width:50%;text-align:right;">
                        <asp:Button ID="BTN_BLLC" runat="server" Text="办理流程" OnClick="BTN_BLLC_Click" />
                    </td>
                </tr>
            </table>
         

        </div>
          <div style="text-align:center;margin:0 auto;" class="auto-style1">
         <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" EnableModelValidation="True" OnRowCreated="GridView1_RowCreated">
             <Columns>
                 <asp:BoundField DataField="ID" HeaderText="ID" />
                 <asp:BoundField DataField="AppraiseID" HeaderText="考核ID" />
                 <asp:BoundField DataField="Flow_State" HeaderText="流程状态" />
                 <asp:BoundField DataField="UserId" HeaderText="用户ID" />
                 <asp:BoundField DataField="UserName" HeaderText="用户名" />
                 <asp:BoundField DataField="tc_DateTime" HeaderText="提出时间" />
                 <asp:BoundField DataField="AppraiseClass" HeaderText="考核类别" />
                 <asp:BoundField DataField="DJ_ReturnTime" HeaderText="点检反馈时间" SortExpression="DJ_ReturnTime" />
                 <asp:BoundField DataField="AppraiseGroup" HeaderText="考核班组" />
                 <asp:BoundField DataField="AppraiseContent" HeaderText="考核内容" />
                 <asp:BoundField DataField="ClassState" HeaderText="班组意见" SortExpression="ClassState" />
                 <asp:BoundField DataField="AppraiseTime" HeaderText="发生时间" />
                 <asp:BoundField DataField="ClassObjection" HeaderText="班组反馈" SortExpression="ClassObjection" />
                 <asp:BoundField DataField="COTime" HeaderText="班组反馈时间" />
                 <asp:BoundField DataField="ChargehandOpinion" HeaderText="工段长审批" />
                 <asp:BoundField DataField="ChargehandState" HeaderText="工段长意见" />
                 <asp:BoundField DataField="Leader_1_Opinion" HeaderText="主管审批" />
                 <asp:BoundField DataField="Leader_1_State" HeaderText="主管意见" />
                 <asp:BoundField DataField="Leader_2_Opinion" HeaderText="书记审批" />
                 <asp:BoundField DataField="Leader_2_State" HeaderText="书记意见" />
                 <asp:BoundField DataField="Leader_3_Opinion" HeaderText="主任审批" />
                 <asp:BoundField DataField="Leader_3_State" HeaderText="主任意见" />
             </Columns>
         </asp:GridView>
       </div>
        <div style="width:80%;text-align:center;float:none;margin:0 auto;overflow:auto;">
             <asp:Label ID="Label3" runat="server" Text="考核表单" Font-Bold="False" Font-Size="Larger"></asp:Label>
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

<div style="width:80%;height:auto;text-align:center;float:none;margin:0 auto;">
    <table style="width:100%;text-align:left;">
        <tr >
            <td style="text-align:left;">
<asp:Label ID="Label4" runat="server" Text="考核编号:"></asp:Label>
            </td>
            <td style="text-align:left;">
  <asp:Label ID="AppraiseID" runat="server" Text="空"></asp:Label>
            </td>
            <td style="text-align:left;">
  <asp:Label ID="Label5" runat="server" Text="程序流转状态:"></asp:Label>
            </td>
            <td style="text-align:left;">
   <asp:Label ID="Flow_State" runat="server" Text="空"></asp:Label>
            </td>
            <td style="text-align:left;">
 <asp:Label ID="Label6" runat="server" Text="用户名:"></asp:Label>
            </td>
             <td style="text-align:left;">
 <asp:Label ID="UserName" runat="server" Text="空"></asp:Label>
            </td>
             <td style="text-align:left;">
  <asp:Label ID="Label7" runat="server" Text="提出考核时间:"></asp:Label>
            </td>
             <td style="text-align:left;">
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
             <td  style="width:20%;text-align:left;column-span:all;">
 <asp:Label ID="Label14" runat="server" Text="考核内容:"></asp:Label> 
            </td>

             <td style="width:80%;column-span:all;">
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
  <asp:Label ID="DJ_ReturnTime" runat="server" Text="空"></asp:Label>
            </td>
             <td>
  <asp:Label ID="Label16" runat="server" Text="工段反馈状态:"></asp:Label>
            </td>
             <td>
 <asp:Label ID="ClassState" runat="server" Text="空"></asp:Label>
            </td>
             <td class="auto-style2">
  <asp:Label ID="Label18" runat="server" Text="工段意见提出时间:"></asp:Label>
            </td> 
            <td>
<asp:Label ID="Label19" runat="server" Text="空"></asp:Label>

            </td>
        </tr>
        </table>
    <table style="width:100%;text-align:left;">
        <tr>
             <td style="width:20%;text-align:left;column-span:all;">
 <asp:Label ID="Label17" runat="server" Text="工段意见:"></asp:Label>
            </td>
        
             <td style="width:80%;text-align:left;column-span:all;">
  <asp:Label ID="ClassObjection" runat="server" Text="空"></asp:Label>
            </td>
            </tr>
          
        <tr>
            <td style="width:20%;text-align:left;column-span:all;">
   <asp:Label ID="Label20" runat="server" Text="组长审批意见:"></asp:Label>
            </td>
          
             <td style="width:80%;text-align:left;column-span:all;">
   <asp:Label ID="ChargehandOpinion" runat="server" Text="空"></asp:Label>
            </td>
           </tr>
       <tr>
           
             <td style="width:20%;text-align:left;column-span:all;">
   <asp:Label ID="Label21" runat="server" Text="组长审批状态:"></asp:Label>
            </td>
           <td style="width:80%;text-align:left;column-span:all;">
     <asp:Label ID="ChargehandState" runat="server" Text="空"></asp:Label>
            </td>
           </tr>
        <tr>
            <td style="width:20%;text-align:left;column-span:all;">
<asp:Label ID="Label22" runat="server" Text="主管领导审批意见:"></asp:Label>
            </td>
     
            <td style="width:80%;text-align:left;column-span:all;">
 <asp:Label ID="Leader_1_Opinion" runat="server" Text="空"></asp:Label>
            </td>
           </tr>
       <tr>
            <td style="width:20%;text-align:left;column-span:all;">
  <asp:Label ID="Label23" runat="server" Text="主管领导审批状态:"></asp:Label>
            </td>
           
            <td style="width:80%;text-align:left;column-span:all;">
 <asp:Label ID="Leader_1_State" runat="server" Text="空"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:20%;text-align:left;column-span:all;">
                <asp:Label ID="Label28" runat="server" Text="书记审批意见:"></asp:Label>
            </td>
         
            <td style="width:80%;text-align:left;column-span:all;">
                <asp:Label ID="Leader_2_Opinion" runat="server" Text="空"></asp:Label>
            </td>
           </tr>
       <tr>
            <td style="width:20%;text-align:left;column-span:all;">
                 <asp:Label ID="Label30" runat="server" Text="书记审批状态:"></asp:Label>
            </td>
         
            <td style="width:80%;text-align:left;column-span:all;">
<asp:Label ID="Leader_2_State" runat="server" Text="空"></asp:Label>
            </td>

        </tr>
        <tr>
            <td style="width:20%;text-align:left;column-span:all;">
                 <asp:Label ID="Label24" runat="server" Text="主任审批意见:"></asp:Label>
            </td>
      
            <td style="width:80%;text-align:left;column-span:all;">
                 <asp:Label ID="Leader_3_Opinion" runat="server" Text="空"></asp:Label>
            </td>
           </tr>
       <tr>
            <td style="width:20%;text-align:left;column-span:all;">
                 <asp:Label ID="Label32" runat="server" Text="主任审批状态:"></asp:Label>
            </td>
         
            <td style="width:80%;text-align:left;column-span:all;">
                   <asp:Label ID="Leader_3_State" runat="server" Text="空"></asp:Label>
            </td>
        </tr>
    </table>
 </div>       
        <div id="GDFK_BanLi" runat="server" style="width:80%;text-align:center;float:none;margin:0 auto;">
    <asp:Label ID="Label1" runat="server" Text="工段反馈" Font-Bold="False" Font-Size="Larger"></asp:Label>
<hr />
            <table style="width:100%">
                <tr>
                    <td>
 <asp:Label ID="Label10" runat="server" Text="工段反馈状态:"></asp:Label>
          
                    </td>
                     <td>
  <asp:DropDownList ID="ddl1_gdfkzt" runat="server">
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
            <asp:TextBox ID="tb1_gdfk_yj" runat="server" Height="225px" Width="100%" TextMode="MultiLine"></asp:TextBox>
               </td>
           </tr>
      <tr>
               <td colspan="3">  
            <asp:Button ID="Button1" runat="server" Text="确认" Width="99px" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="取消" Width="99px" OnClick="Button2_Click" />
</td> 
      </tr>
 </table>  
        </div>
        

    </form>
</body>
</html>

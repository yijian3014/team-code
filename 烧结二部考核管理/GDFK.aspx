<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GDFK.aspx.cs" Inherits="GDFK" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  

  
</head>
<body>
    <form id="form1" runat="server" style="text-align:center;margin:0 auto;width:950px"  >
        <asp:Label ID="Label26" runat="server" Text="烧结二部考核管理" Font-Bold="True" Font-Size="Larger"></asp:Label> 
        <div style="text-align:right;">            
               <hr  />
        <asp:Label ID="Label25" runat="server" Text="用户名："></asp:Label>
        <asp:Label ID="login_user" runat="server" Text=""></asp:Label>
             <asp:Button ID="btn_tckh" runat="server" Text="提出考核" OnClick="btn_tckh_Click" Visible="False" />
 <asp:Button ID="btn_acc_mgr" runat="server" Text="帐户管理" OnClick="btn_acc_mgr_Click" />
                  <asp:Button ID="btn_exit" runat="server" Text="退出" OnClick="btn_exit_Click" />
 </div>
        <div style="text-align:center;margin:0 auto;width:100%;float:none;" >
    
        <asp:Label ID="Label2" runat="server" Text="相关考核概览" Font-Bold="False" Font-Size="Larger"></asp:Label>
<hr  /> 
</div>

        <div style="text-align:right;margin:0 auto;" >
            <table style="width:100%">
                <tr>
                    <td style="width:50%;text-align:left;">
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
          <div style="text-align:center;margin:0 auto;width:100%;width:950px;height:100px auto;float:none;overflow:auto;">
         <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" EnableModelValidation="True" OnRowCreated="GridView1_RowCreated" Font-Size="Small">
             <Columns>
                 <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                 <asp:BoundField DataField="AppraiseID" HeaderText="考核ID" />
                 <asp:BoundField DataField="Flow_State" HeaderText="流程状态" />
                 <asp:BoundField DataField="UserId" HeaderText="用户ID" Visible="False" />
                 <asp:BoundField DataField="UserName" HeaderText="用户名" />
                 <asp:BoundField DataField="tc_DateTime" HeaderText="提出考核时间" />
                 <asp:BoundField DataField="AppraiseClass" HeaderText="考核种类" />
                 <asp:BoundField DataField="AppraiseTime" HeaderText="考核发生时间" />
                 <asp:BoundField DataField="AppraiseGroup" HeaderText="被考核工段" />
                 <asp:BoundField DataField="AppraiseGroupID" HeaderText="被考核工段ID" Visible="false" />
                 <asp:BoundField DataField="AppraiseContent" HeaderText="考核内容" />
                 <asp:BoundField DataField="kh_jiner" HeaderText="考核金额" />
                 <asp:BoundField DataField="DJ_ReturnTime" HeaderText="点检反馈时间" SortExpression="DJ_ReturnTime" Visible="False" />
                 <asp:BoundField DataField="ClassState" HeaderText="工段反馈状态" SortExpression="ClassState" />
                 <asp:BoundField DataField="COTime" HeaderText="工段意见提出时间" Visible="False" />
                 <asp:BoundField DataField="ClassObjection" HeaderText="工段意见" SortExpression="ClassObjection" Visible="False" />
                 <asp:BoundField DataField="ChargehandOpinion" HeaderText="组长审批意见" Visible="False" />
                 <asp:BoundField DataField="ChargehandState" HeaderText="组长审批状态" />
                 <asp:BoundField DataField="Leader_1_Opinion" HeaderText="主管领导审批意见" Visible="False" />
                 <asp:BoundField DataField="Leader_1_State" HeaderText="主管领导审批状态" />
                 <asp:BoundField DataField="Leader_2_Opinion" HeaderText="书记审批意见" Visible="False" />
                 <asp:BoundField DataField="Leader_2_State" HeaderText="书记审批状态" />
                 <asp:BoundField DataField="Leader_3_Opinion" HeaderText="主任审批意见" Visible="False" />
                 <asp:BoundField DataField="Leader_3_State" HeaderText="主任审批状态" />
             </Columns>
         </asp:GridView>
       </div>


<div ID="div_khxd" runat="server"  style="width:100%;height:auto;text-align:center;float:none;margin:0 auto;" >
      <asp:Label ID="Label3" runat="server" Text="考核表详单" Font-Bold="False" Font-Size="Larger"></asp:Label>
            <hr />

 
    <table style="width:100%;text-align:left;">
        <tr >
            <td style="text-align:left; width:15%">
<asp:Label ID="Label4" runat="server" Text="考核编号:"></asp:Label>
            </td>
            <td style="text-align:left;width:10%">
  <asp:Label ID="AppraiseID" runat="server" Text="空"></asp:Label>
            </td>
            <td style="text-align:left;width:12%">
  <asp:Label ID="Label5" runat="server" Text="程序流转状态:"></asp:Label>
            </td>
            <td  style="text-align:left;width:12%">
   <asp:Label ID="Flow_State" runat="server" Text="空"></asp:Label>
            </td>
            <td  style="text-align:left;width:12%">
 <asp:Label ID="Label6" runat="server" Text="提出考核用户:"></asp:Label>
            </td>
             <td  style="text-align:left;width:12%">
 <asp:Label ID="UserName" runat="server" Text="空"></asp:Label>
            </td>
             <td  style="text-align:left;width:12%">
  <asp:Label ID="Label7" runat="server" Text="提出考核时间:"></asp:Label>
            </td>
             <td  style="text-align:left;width:12%">
   <asp:Label ID="tc_DataTime" runat="server" Text="空"></asp:Label>
            </td>
        </tr>
        <tr>
             <td style="text-align:left; width:15%">
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
           
             <td>
 <asp:Label ID="Label12" runat="server" Text="被考核工段:"></asp:Label>
            </td>
             <td>
  <asp:Label ID="AppraiseGroup" runat="server" Text="空"></asp:Label>
            </td>
              <td style="width:15%">
 <asp:Label ID="Label19" runat="server" Text="考核金额:"></asp:Label>
            </td>
             <td>
  <asp:Label ID="lb_kh_jiner" runat="server" Text="空"></asp:Label>
            </td>
            </tr>
        </table>



     <table style="width:100%;text-align:left;" >
        <tr >
             <td  style="width:15%;text-align:left;">
 <asp:Label ID="Label16" runat="server" Text="考核内容:"></asp:Label> 
            </td>

             <td style="width:85%;text-align:left;">
                 <asp:TextBox ID="tbx_AppraiseContent" runat="server" Width="100%" Hight="auto" TextMode="MultiLine" ></asp:TextBox>
            </td>
             

        </tr>
        </table>
    <table style="width:100%;text-align:left;">
        <tr>
            <td  style="width:15%;text-align:left;column-span:all;">
   <asp:Label ID="Label35" runat="server" Text="考核反馈意见:"></asp:Label>
            </td>
          
             <td style="width:85%;text-align:left;column-span:all;">
                 <asp:TextBox ID="tbx_xd_khfk_yj" runat="server" Width="100%" Hight="auto" TextMode="MultiLine" ></asp:TextBox>
            </td>
           </tr>
       <tr>
           
             <td  style="width:15%;text-align:left;column-span:all;">
   <asp:Label ID="Label39" runat="server" Text="考核反馈状态:"></asp:Label>
            </td>
           <td style="width:85%;text-align:left;column-span:all;">
     <asp:Label ID="lb_khfk_zt" runat="server" Text="空"></asp:Label>
            </td>
           </tr>
        <tr>
              <td  style="width:15%">
  <asp:Label ID="Label17" runat="server" Text="工段反馈状态:"></asp:Label>
            </td>
             <td  style="width:15%">
 <asp:Label ID="ClassState" runat="server" Text="空"></asp:Label>
            </td>
            </tr>
       
        <tr>

             <td style="text-align:left;column-span:all;"" >
 <asp:Label ID="Label18" runat="server" Text="工段意见:"></asp:Label>
            </td>
        
             <td style="text-align:left;column-span:all;">
                 <asp:TextBox ID="tbx_ClassObjection" runat="server"  Width="100%" Hight="auto" TextMode="MultiLine" ></asp:TextBox>
            </td>
            </tr>
           <tr>
             <td  style="width:15%">
  <asp:Label ID="Label20" runat="server" Text="工段意见提出时间:"></asp:Label>
            </td> 
            <td  style="width:15%">
<asp:Label ID="COTime1" runat="server" Text="空"></asp:Label>

            </td>
        </tr>
        <tr>
            <td  style="width:15%;text-align:left;column-span:all;">
   <asp:Label ID="Label21" runat="server" Text="组长审批意见:"></asp:Label>
            </td>
          
             <td style="width:85%;text-align:left;column-span:all;">
                 <asp:TextBox ID="tbx_ChargehandOpinion" runat="server"  Width="100%" Hight="auto" TextMode="MultiLine" ></asp:TextBox>
            </td>
           </tr>
       <tr>
           
             <td  style="width:15%;text-align:left;column-span:all;">
   <asp:Label ID="Label22" runat="server" Text="组长审批状态:"></asp:Label>
            </td>
           <td style="width:85%;text-align:left;column-span:all;">
     <asp:Label ID="ChargehandState" runat="server" Text="空"></asp:Label>
            </td>
           </tr>
        <tr>
            <td style="width:15%;text-align:left;column-span:all;">
<asp:Label ID="Label23" runat="server" Text="主管领导审批意见:"></asp:Label>
            </td>
     
            <td style="width:85%;text-align:left;column-span:all;">
                <asp:TextBox ID="tbx_Leader_1_Opinion" runat="server"  Width="100%" Hight="auto" TextMode="MultiLine" ></asp:TextBox>
            </td>
           </tr>
       <tr>
            <td style="width:15%;text-align:left;column-span:all;">
  <asp:Label ID="Label24" runat="server" Text="主管领导审批状态:"></asp:Label>
            </td>
           
            <td style="width:85%;text-align:left;column-span:all;">
 <asp:Label ID="Leader_1_State" runat="server" Text="空"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:15%;text-align:left;column-span:all;">
                <asp:Label ID="Label28" runat="server" Text="书记审批意见:"></asp:Label>
            </td>
         
            <td style="width:85%;text-align:left;column-span:all;">
                <asp:TextBox ID="tbx_Leader_2_Opinion" runat="server"  Width="100%" Hight="auto" TextMode="MultiLine" ></asp:TextBox>
            </td>
           </tr>
       <tr>
            <td style="width:15%;text-align:left;column-span:all;">
                 <asp:Label ID="Label30" runat="server" Text="书记审批状态:"></asp:Label>
            </td>
         
            <td style="width:85%;text-align:left;column-span:all;">
<asp:Label ID="Leader_2_State" runat="server" Text="空"></asp:Label>
            </td>

        </tr>
        <tr>
            <td style="width:15%;text-align:left;column-span:all;">
                 <asp:Label ID="Label32" runat="server" Text="主任审批意见:"></asp:Label>
            </td>
      
            <td style="width:85%;text-align:left;column-span:all;">
                 <asp:TextBox ID="tbx_Leader_3_Opinion" runat="server"  Width="100%" Hight="auto" TextMode="MultiLine" ></asp:TextBox>
            </td>
           </tr>
       <tr>
            <td style="width:15%;text-align:left;column-span:all;">
                 <asp:Label ID="Label38" runat="server" Text="主任审批状态:"></asp:Label>
            </td>
         
            <td style="width:85%;text-align:left;column-span:all;">
                   <asp:Label ID="Leader_3_State" runat="server" Text="空"></asp:Label>
            </td>
        </tr>
    </table>
 </div>       
        <div id="GDFK_BanLi" runat="server" style="width:100%;text-align:center;float:none;margin:0 auto;">
    <asp:Label ID="Label1" runat="server" Text="工段审核" Font-Bold="False" Font-Size="Larger"></asp:Label>
<hr />
            <table style="width:100%;text-align:left;">
                <tr>
                    <td style="width:15%">
 <asp:Label ID="Label10" runat="server" Text="工段审核状态:"></asp:Label>
          
                    </td>
                     <td>
  <asp:DropDownList ID="ddl_gdsh_zt" runat="server">
                <asp:ListItem Selected="True">同意</asp:ListItem>
                <asp:ListItem>不同意</asp:ListItem>
            </asp:DropDownList>
                    </td>
                    
                     <td style="width:15%">
    <asp:Label ID="Label11" runat="server" Text="工段意见提出时间:"></asp:Label>
                    </td >
                     <td style="width:15%">
  <asp:Label ID="COTime" runat="server" Text="工段意见提出时间"></asp:Label> 
                    </td>
                    <td style="width:10%" >
                     <asp:Label ID="Label27" runat="server" Text="考核金额:"></asp:Label>   
                    </td>
                     <td style="width:15%" >
                           <asp:TextBox ID="tbx_gdsh_kh_jiner" runat="server" Height="16px" Width="100%" Enabled="False" ></asp:TextBox>
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
            <asp:TextBox ID="tbx_gdsh_yj" runat="server" Height="225px" Width="100%" TextMode="MultiLine"></asp:TextBox>
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
               <div id="dv_khfk_banli" runat="server" style="width:100%;text-align:center;float:none;margin:0 auto;" visible="false" >
    <asp:Label ID="Label31" runat="server" Text="考核反馈" Font-Bold="False" Font-Size="Larger"></asp:Label>
<hr />
            <table style="width:100%;text-align:left;">
                <tr>
                    <td style="width:15%">
 <asp:Label ID="Label33" runat="server" Text="反馈状态:"></asp:Label>
          
                    </td>
                     <td>
  <asp:DropDownList ID="ddl_khfk_zt" runat="server" Height="16px">
                <asp:ListItem Selected="True">同意</asp:ListItem>
                <asp:ListItem>不同意</asp:ListItem>
            </asp:DropDownList>
                    </td>
                    
                     <td style="width:15%">
    <asp:Label ID="Label34" runat="server" Text="意见提出时间:"></asp:Label>
                    </td >
                     <td style="width:15%">
  <asp:Label ID="lb_khfk_sj" runat="server" Text="意见提出时间"></asp:Label> 
                    </td>
                    <td style="width:10%" >
                     <asp:Label ID="Label36" runat="server" Text="考核金额:"></asp:Label>   
                    </td>
                     <td style="width:15%" >
                           <asp:TextBox ID="tbx_khfk_jiner" runat="server" Height="16px" Width="100%" Enabled="False" ></asp:TextBox>
                    </td>
                </tr>
            </table>
       <table style="width:100%">
           <tr>
               <td style="text-align:left;">
        <asp:Label ID="Label37" runat="server" Text="意见:" ></asp:Label>
               </td>
               </tr>
           <tr>
               <td colspan="3" >
            <asp:TextBox ID="tbx_khfk_yj" runat="server" Height="225px" Width="100%" TextMode="MultiLine"></asp:TextBox>
               </td>
           </tr>
      <tr>
               <td colspan="3">  

            <asp:Button ID="btn_khfk_ok" runat="server" Text="确认" Width="99px" OnClick="btn_khfk_ok_Click" />

                   
            <asp:Button ID="btn_khfk_cancel" runat="server" Text="取消" Width="99px" OnClick="btn_khfk_calcel_Click" />

</td> 
      </tr>
 </table>  
        </div>
       <div>
          <%--下面的字段全部为隐藏，主要用于前后台数据缓存--%>
          
 <asp:Label ID="Label29" runat="server" Text="被考核工段ID:" Visible="False"></asp:Label>
            
  <asp:Label ID="lb_AppraiseGroupID" runat="server" Text="空" Visible="False"></asp:Label>
           <asp:Label ID="lb_tcr_usrid" runat="server" Visible="False"></asp:Label>
          
 

 <asp:Label ID="Label15" runat="server" Text="点检操作是否超时:" Visible="False"></asp:Label>
            
  <asp:Label ID="DJ_ReturnTime" runat="server" Text="空" Visible="False"></asp:Label>
            
</div>    

    </form>
</body>
</html>

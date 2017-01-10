<%@ Page Language="C#" AutoEventWireup="true" CodeFile="USER_MGR.aspx.cs" Inherits="USER_MGR"  EnableEventValidation="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title></title>
</head>
<body>
      <form id="form1" runat="server" style="text-align:center;width:95%;margin:0 auto;" >
        <asp:Label ID="Label26" runat="server" Text="烧结二部考核管理" Font-Bold="True" Font-Size="Larger"></asp:Label> 
        <div style="text-align:right;">            
               <hr  />
        <asp:Label ID="Label25" runat="server" Text="用户名："></asp:Label>
             
        <asp:Label ID="login_user" runat="server" Text=""></asp:Label>
  <asp:Button ID="btn_back" runat="server" Text="返回审核页" OnClick="btn_back_Click" />
     
            </div>
        <div style="text-align:center;margin:0 auto;width:100%;float:none;" >
    
        <asp:Label ID="Label2" runat="server" Text="用户信息总览" Font-Bold="False" Font-Size="Larger"></asp:Label>
<hr  /> 
</div>

        <div style="text-align:right;margin:0 auto;float:none;width:100%;">
            <table style="width:100%">
                <tr>
                    <td style="width:50%;text-align:left;">
                        <asp:Button ID="btn_usr_add" runat="server" Text="添加用户" OnClick="btn_usr_add_Click" />
                         <asp:Button ID="btn_usr_del" runat="server" Text="删除用户" OnClick="btn_usr_del_Click" />
                         <asp:Button ID="btn_usr_edt" runat="server" Text="修改用户信息" OnClick="btn_usr_edt_Click" />
                    
                    
                    
                    </td>
                </tr>
            </table>
         

        </div>
          <div style="text-align:center;margin:0 auto;">
         <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" EnableModelValidation="True" Font-Size="Small">
             <Columns>
    <asp:BoundField DataField="Id" HeaderText="ID" Visible="false"/>
                 <asp:BoundField DataField="UserId" HeaderText="用户ID" />
                 <asp:BoundField DataField="UserName" HeaderText="帐号" />
                 <asp:BoundField DataField="UserRole" HeaderText="角色" />
                 <asp:BoundField DataField="UserRName" HeaderText="用户名" />
                 <asp:BoundField DataField="UserPassWord" HeaderText="用户密码" Visible="false" />
   
             </Columns>
         </asp:GridView>
       </div>
 
        <div id="GDFK_BanLi" runat="server" style="width:95%;text-align:center;float:none;margin:0 auto;">
    <asp:Label ID="Label1" runat="server" Text="用户信息编辑" Font-Bold="False" Font-Size="Larger"></asp:Label>
<hr />
            <table style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="用户帐号："></asp:Label>
                     </td>
                    <td>
                        <asp:TextBox ID="tbx_usr_acc" runat="server"></asp:TextBox>
                    </td>
                  
               
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="用户名："></asp:Label>
                     </td>  
                     <td>
                        <asp:TextBox ID="tbx_usr_name" runat="server"></asp:TextBox>
                    </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="用户角色："></asp:Label>
                     </td>  
                     <td>
                         <asp:DropDownList ID="ddl_usr_rule" runat="server" Height="16px" Width="145px">
                             <asp:ListItem Value="1">点检</asp:ListItem>
                             <asp:ListItem>2</asp:ListItem>
                         </asp:DropDownList>
                    </td>
                     <td>
                        <asp:Label ID="Label6" runat="server" Text="用户密码："></asp:Label>
                     </td>  
                     <td>
                        <asp:TextBox ID="tbx_usr_pas" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
       <table style="width:100%">
         
            <tr>
               <td colspan="3">  
            <asp:Button ID="Button1" runat="server" Text="确认" Width="99px" OnClick="Button1_Click" />
                   <asp:Label ID="lb_usr_id" runat="server" Text="0" Visible="False"></asp:Label>
            <asp:Button ID="Button2" runat="server" Text="取消" Width="99px" OnClick="Button2_Click" />
</td> 
      </tr>
 </table>  
        </div>
        

    </form>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .login_tb {
        width:980px;
        text-align:center;
  
    }
        .lb_nm_mm {
            text-align:right;
            
        }
           .tbx_nm_mm {
            text-align:left;
            
        }
  
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div >
    <table class="login_tb">

        <tr >
           
            <td colspan="4">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>考核</asp:ListItem>
                    <asp:ListItem>奖金</asp:ListItem>
                    <asp:ListItem>评价</asp:ListItem>
                    <asp:ListItem>员工</asp:ListItem>
                </asp:RadioButtonList>
             </td>     
        </tr>
             <tr >
            <td class="auto-style1" ></td>
            <td class="lb_nm_mm">
                <asp:Label ID="Label1" runat="server" Text="登陆名："></asp:Label>
                   </td>
            <td class="tbx_nm_mm" >
                 <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                 </td>
                <td class="auto-style1" ></td>
        </tr>
          <tr>
            <td ></td>
            <td class="lb_nm_mm">
                <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label>
                   </td>
            <td class="tbx_nm_mm">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
              </td>
            <td ></td>
             
        </tr>
             <tr>
           
            <td colspan="4" >
                <asp:Button ID="btn_login" runat="server" Text="登陆" />
                 </td>
        
           
        </tr>
        </table>
    </div>
    </form>
</body>
</html>

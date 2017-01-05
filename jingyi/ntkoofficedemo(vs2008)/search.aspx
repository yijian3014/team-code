<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="ntkoofficedemo_vs2008_.search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="width:800px;height:600px;text-align:center;float:none;margin:0 auto;">
    <form id="form1" runat="server">
    <div  >
      <table  style="width:100%;height:auto;text-align:center;">               
                <tr>
                    <td >
                        精益文档查阅系统
                     </td>
                      </tr>
                   <tr>
                    <td >
                        <div>
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="105px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="105px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="105px" AutoPostBack="True">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:DropDownList ID="DropDownList4" runat="server" Height="16px" Width="105px" AutoPostBack="True">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="搜索" Width="43px" OnClick="Button1_Click" />
                   </div>

                    </td>
                       </tr>
                    
                 </table>  </div>

    </form>
</body>
</html>


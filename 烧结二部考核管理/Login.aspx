<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta http-equiv="Content-Language" content="zh-CN" />
	<style type="text/css">
		body{background:#f6fafe;text-align:center;}
		div{width:900px;margin:0 auto;background:#fff;text-align:left;}
	</style>
</head>
<body style="height: 349px">
    <form id="form1" runat="server">
    <div style="height: 299px; width: 900px;text-align:center">
    
    &nbsp;<asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="烧结二部考核管理系统"></asp:Label>
        <br />
        <br />
        <br />
        <br />
&nbsp;<asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="用户名："></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBoxName" runat="server" Height="16px"></asp:TextBox>
        <br />
        <br />
        <br />
&nbsp;<asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="密　码："></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBoxPassWord" runat="server" Height="16px" TextMode="Password"></asp:TextBox>
        <br />
        <br />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="Button1" runat="server" Height="22px" OnClick="Button1_Click" Text="登录" Width="59px" />
    
        &nbsp;
        <asp:Button ID="Button2" runat="server" Height="22px" OnClick="Button2_Click" Text="重置" Width="59px" />
     &nbsp;
        <asp:Button ID="Button3" runat="server" Height="22px" OnClick="Button3_Click" Text="报表导出" Width="59px" />
     &nbsp;
        </div>
    </form>
</body>
</html>

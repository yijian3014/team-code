<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GDFK.aspx.cs" Inherits="GDFK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 80%;
            float: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:80%;text-align:center;float:none;margin:0 auto;">
    
        <asp:Label ID="Label1" runat="server" Text="工段反馈" Font-Bold="True" Font-Size="Larger"></asp:Label>
 </div>
        <div style="width:80%;text-align:center;">
        <asp:Label ID="Label10" runat="server" Text="工段反馈状态"></asp:Label>
        <asp:Label ID="ClassState" runat="server" Text="工段反馈状态"></asp:Label>
            <br />
        <asp:Label ID="Label13" runat="server" Text="工段意见"></asp:Label>
        <asp:Label ID="ClassObjection" runat="server" Text="工段意见"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
        <asp:Label ID="Label11" runat="server" Text="工段意见提出时间"></asp:Label>
        <asp:Label ID="COTime" runat="server" Text="工段意见提出时间"></asp:Label>
        </div>

      <div style="text-align:center;margin:0 auto;" class="auto-style1">
         <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center">
        </asp:GridView>

       </div>

    </form>
</body>
</html>

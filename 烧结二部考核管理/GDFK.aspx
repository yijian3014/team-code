<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GDFK.aspx.cs" Inherits="GDFK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:80%;text-align:center;float:none;margin:0 auto;">
    
        <asp:Label ID="Label1" runat="server" Text="工段反馈" Font-Bold="True" Font-Size="Larger"></asp:Label>
 </div>

        <div style="width:80%;text-align:center;float:none;margin:0 auto;"> 
        <asp:Label ID="Label2" runat="server" Text="考核编号:"></asp:Label>
        <asp:Label ID="AppraiseID" runat="server" Text="考核编号"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="程序流转状态:"></asp:Label>
        <asp:Label ID="State" runat="server" Text="程序流转状态"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="用户名:"></asp:Label>
        <asp:Label ID="UserID" runat="server" Text="用户名"></asp:Label>
        <asp:Label ID="Label5" runat="server" Text="提出考核时间:"></asp:Label>
        <asp:Label ID="DataTime" runat="server" Text="提出考核时间"></asp:Label>

        <asp:Label ID="Label6" runat="server" Text="考核种类:"></asp:Label>
        <asp:Label ID="AppraiseClass" runat="server" Text="考核种类"></asp:Label>
        <asp:Label ID="Label8" runat="server" Text="考核发生时间:"></asp:Label>
        <asp:Label ID="AppraiseTime" runat="server" Text="考核发生时间"></asp:Label>

        <asp:Label ID="Label9" runat="server" Text="被考核工段:"></asp:Label>
        <asp:Label ID="AppraiseGroup" runat="server" Text="被考核工段"></asp:Label>

       <asp:Label ID="Label7" runat="server" Text="考核内容:"></asp:Label> 
       <asp:Label ID="AppraiseContent" runat="server" Text="考核内容"></asp:Label>

        <asp:Label ID="Label10" runat="server" Text="点检操作是否超时:"></asp:Label>
        <asp:Label ID="IS_TimeOut" runat="server" Text="点检操作是否超时"></asp:Label>
        </div>

      <div style="width:80%;text-align:center;float:none;margin:0 auto;">
         <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center">
        </asp:GridView>

       </div> 

    </form>
</body>
</html>

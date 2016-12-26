<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KHLR.aspx.cs" Inherits="KHLR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    	<style type="text/css">
		body{background:#f6fafe;text-align:center;}
		div{width:900px;margin:0 auto;background:#fff;text-align:left;}
	</style>
    <title></title>
</head>
<body style="height: 511px">
    <form id="form1" runat="server">
    <div  style="height: 642px; width: 900px;">
    
        <asp:Label ID="Label1" runat="server" Text="考核提出人："></asp:Label>
        <asp:TextBox ID="TBUserName" runat="server" MaxLength="10"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="考核发生时间："></asp:Label>
        <br />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
        <br />
        <asp:Label ID="Label3" runat="server" Text="考核类别："></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="1">生产</asp:ListItem>
            <asp:ListItem Value="2">设备</asp:ListItem>
            <asp:ListItem Value="3">其它</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="被考核工段："></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem Value="1">甲班</asp:ListItem>
            <asp:ListItem Value="2">乙班</asp:ListItem>
            <asp:ListItem Value="3">丙班</asp:ListItem>
            <asp:ListItem Value="4">丁班</asp:ListItem>
            <asp:ListItem Value="5">白班</asp:ListItem>
            <asp:ListItem Value="6">车间</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="考核内容："></asp:Label>
    
        <br />
        <asp:TextBox ID="TBContent" runat="server" Height="153px" MaxLength="200" Width="244px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Button ID="BtAdd" runat="server" BorderStyle="Double" OnClick="BtAdd_Click" Text="提交考核" />
    
    </div>
    </form>
</body>
</html>

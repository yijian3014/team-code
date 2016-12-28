<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KHLR.aspx.cs" Inherits="KHLR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    	<style type="text/css">
		body{background:#f6fafe;text-align:center;}
		div{width:900px;margin:0 auto;background:#fff;text-align:left;
                height: 1px;
            }
	</style>
    <title></title>
</head>
<body style="height: 1550px">
    <form id="form1" runat="server">
    <div  style="height: 1283px; width: 900px;">
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/无标题.png" />
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Image/1.png" OnClick="ImageButton1_Click" />
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Image/2.png" OnClick="ImageButton2_Click" />
        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Image/2.png" OnClick="ImageButton3_Click" />
        <br />
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:Label ID="Label1" runat="server" Text="考核提出人："></asp:Label>
                <asp:TextBox ID="TBUserName" runat="server" MaxLength="10"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="考核发生时间："></asp:Label>
                <br />
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" SelectedDate="2016-12-21">
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
                <asp:TextBox ID="TBContent" runat="server" Height="153px" TextMode="MultiLine" Width="244px"></asp:TextBox>
                <br />
                <asp:Button ID="BtAdd" runat="server" BorderStyle="Double" OnClick="BtAdd_Click" Text="提交考核" />
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="AppraiseID" HeaderText="考核编号" />
                        <asp:BoundField DataField="UserName" HeaderText="考核提出人" />
                        <asp:BoundField DataField="AppraiseClass" HeaderText="考核类别" />
                        <asp:BoundField DataField="AppraiseGroup" HeaderText="被考核工段" />
                        <asp:BoundField DataField="AppraiseTime" HeaderText="考核事件发生日期" />
                        <asp:BoundField DataField="tc_DateTime" HeaderText="考核提出时间" />
                        <asp:CommandField DeleteText="详情" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="Label15" runat="server" Text="Label" Visible="False"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label12" runat="server" Text="工段反馈："></asp:Label>
                <br />
                <asp:TextBox ID="TextBox3" runat="server" Height="106px" ReadOnly="True" TextMode="MultiLine" Width="344px"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Label ID="Label14" runat="server" Text="考核内容："></asp:Label>
                <br />
                <asp:TextBox ID="TextBox4" runat="server" Height="106px" TextMode="MultiLine" Width="344px"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修改考核" Width="100px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="放弃考核" Width="100px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="取消" Width="100px" />
                <br />
                <br />
                <br />
                <br />
                <br />
            </asp:View>
            <asp:View ID="View3" runat="server">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" OnRowDeleting="GridView2_RowDeleting" Width="891px">
                    <Columns>
                                                <asp:BoundField DataField="AppraiseID" HeaderText="考核编号" />
                        <asp:BoundField DataField="UserName" HeaderText="考核提出人" />
                        <asp:BoundField DataField="tc_DateTime" HeaderText="考核提出时间" />
                        <asp:BoundField DataField="AppraiseClass" HeaderText="考核类别" />
                        <asp:BoundField DataField="AppraiseGroup" HeaderText="被考核工段" />
                        <asp:BoundField DataField="ClassState" HeaderText="工段意见" />
                        <asp:BoundField DataField="ChargehandState" HeaderText="组长意见" />
                        <asp:BoundField DataField="Leader_1_State" HeaderText="主管领导意见" />
                        <asp:BoundField DataField="Leader_2_State" HeaderText="书记意见" />
                        <asp:BoundField DataField="Leader_3_State" HeaderText="主任意见" />
                                                <asp:CommandField DeleteText="详情" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </asp:View>
            <br />
        </asp:MultiView>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>

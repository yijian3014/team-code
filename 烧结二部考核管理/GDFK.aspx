<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GDFK.aspx.cs" Inherits="GDFK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body>
    <form id="form1" runat="server" style="width:950px";>
    <div style="width:80%;text-align:center;float:none;margin:0 auto;">
    
        <asp:Label ID="Label1" runat="server" Text="工段反馈" Font-Bold="True" Font-Size="Larger"></asp:Label>
<hr />
 </div>
        
        <div style="width:80%;text-align:center;float:none;margin:0 auto;"">
            <table style="width:100%">
                <tr>
                    <td>
 <asp:Label ID="Label10" runat="server" Text="工段反馈状态:"></asp:Label>
          
                    </td>
                     <td>
  <asp:DropDownList ID="DropDownList1" runat="server">
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
            <asp:TextBox ID="TextBox1" runat="server" Height="225px" Width="100%" TextMode="MultiLine"></asp:TextBox>
               </td>
           </tr>
      <tr>
               <td colspan="3">  
            <asp:Button ID="Button1" runat="server" Text="确认" Width="99px" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="取消" Width="99px" />
</td> 
      </tr>
 </table>  
        </div>
        
<div style="text-align:center;margin:0 auto;width:80%;float:none;" >
    
        <asp:Label ID="Label2" runat="server" Text="相关考核汇总" Font-Bold="True" Font-Size="Larger"></asp:Label>
<hr  /> 

</div>
        <div style="text-align:right;margin:0 auto;float:none;width:80%;">
            <asp:RadioButtonList ID="rbl_cx" runat="server" RepeatDirection="Horizontal" TextAlign="Right" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" >
                <asp:ListItem Selected="True" Value="0">总览</asp:ListItem>
                <asp:ListItem Value="1">待办理</asp:ListItem>
                <asp:ListItem Value="2">已办结</asp:ListItem>
            </asp:RadioButtonList>

        </div>
          <div style="width:80%;text-align:center;float:none;margin:0 auto;overflow:auto">
         <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
       </div>
    </form>
</body>
</html>

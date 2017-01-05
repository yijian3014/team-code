<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ntkoofficedemo_vs2008_.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--<meta content="IE=7" http-equiv="X-UA-Compatible" />--%>
      <title></title>
</head>
 <body style="height:720px;width:980px; text-align:center;margin:auto;float:0;">
       
    <form id="form1" runat="server" >   
        
     <div style="height:150px"></div>     
        <hr style="background-color: #000000"  height: "2px" />     
 <div style="height:100px"></div>  
   <table style="margin:auto;background:url(images/background.jpg) no-repeat center ;width:980px;height:300px;text-align:center;vertical-align:baseline; vertical-align:middle;margin:auto;float:0;">
     <tr>
         <td>
    
<div >    
      <div style="width:auto;height:60px;vertical-align:middle;">
          <img src="images/login_user.jpg" width="45" height="40" style="margin-bottom:-15px;"/><asp:TextBox ID="TextBox1" runat="server" Width="148px" BackColor="White" BorderStyle="None" BorderWidth="0px" Height="38px" Font-Bold="True" Font-Size="Larger" Font-Strikeout="False"></asp:TextBox>
                      </div>
           
 <div style="width:auto;height:60px;vertical-align:middle;">
<img src="images/login_pass.jpg" width="45" height="40" style="margin-bottom:-15px;"/><asp:TextBox ID="TextBox2" runat="server"  TextMode="Password" Width="148px" BackColor="White" BorderStyle="None" BorderWidth="0px" Height="38px" Font-Bold="True" Font-Size="Larger"></asp:TextBox>

 </div>


<div style="height:50px"> 
    <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" Width="120px" ImageUrl="~/images/login_button.jpg" OnClick="ImageButton1_Click"  />

</div>
</div>
    </td>
</tr>
       </table>

 <div style="height:100px"></div>     
        <hr style="background-color: #000000"  height: "2px" />    
<div style="text-align:center;height:100px;vertical-align:top" aria-multiline="False">
    <asp:Label ID="Label1" runat="server" Text="精益资料查阅平台" Font-Bold="False" Font-Size="Large"></asp:Label>
  
   <br />
    <br />
     <asp:Label ID="Label2" runat="server" Text="自动化部(软件)" Font-Bold="False" Font-Size="Large"></asp:Label>
     
  <br />
</div>

    </form>
</body>
</html>

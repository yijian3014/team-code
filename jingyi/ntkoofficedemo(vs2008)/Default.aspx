<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ntkoofficedemo_vs2008_._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="IE=7" http-equiv="X-UA-Compatible" />
    <title><%=title%>&nbsp; 文件首页列表</title>
    <script language="javascript" type="text/javascript" src="ntko.js"></script>
    <style type="text/css" >
    a:link    { text-decoration: none;color:gray;}
a:visited { text-decoration: none;color:black;}
a:hover   { text-decoration:underline;color:red;}


    </style>
   
</head>
    <body style="width:980px;height:auto;text-align:center;float:none;margin:0 auto; "> 
     <form id="form1" runat="server">
         <div >
             <asp:Image ID="Image1" runat="server" ImageUrl="~/images/default_banner.jpg" />
         </div>
    
          <div style="height:30px;text-align:right;">
  
        <asp:Label ID="Label5" runat="server" Text="ID:"></asp:Label>
               <asp:Label ID="user_id" runat="server"></asp:Label>
               <asp:Label ID="Label3" runat="server" Text="  用户:"></asp:Label>
              <asp:Label ID="user_name" runat="server"></asp:Label>
              <asp:Label ID="Label6" runat="server" Text="  职务:"></asp:Label>
               <asp:Label ID="user_role" runat="server"></asp:Label>
              <asp:Label ID="Label4" runat="server" Text="  部门:"></asp:Label>
               <asp:Label ID="user_dep" runat="server"></asp:Label>

<asp:Label ID="user_stu" runat="server"></asp:Label> 
             
</div>
            <div  style="text-align:center;margin:0 auto;height:30px" >     
                    <span>文档检索</span>
                  &nbsp;&nbsp;
                <span>目录：</span>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="100px">
                            </asp:DropDownList>
                           
                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="100px">
                            </asp:DropDownList>
                           
                            <asp:DropDownList ID="DropDownList3" runat="server" Width="100px">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                <span>标签：</span>
                            <asp:DropDownList ID="DropDownList4" runat="server" Width="100px" OnSelectedIndexChanged="Button1_Click">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                        
                              &nbsp;
                <asp:Button ID="Button1" runat="server" Text="查找" OnClick="Button1_Click" Width="86px" Height="26px"/>
                 </div>

   
 <hr size="1" style="background-color: #000000" />   
     

<div id="file_list" style="width:980px;height:auto;text-align:left;float:none;margin:0 auto;top:0;">
    <table>
        <tr>
            <td style="text-align:left;">
                  <span>文档资料:</span>
            </td>
       
        </tr>
        <tr>
            <td>
<div  style="text-align:left;width:auto;height:400px;overflow:auto;">
     
           
                   <%=getFilesList() %>
    
         </div> 
            </td>
    
        </tr>
    </table>
</div>
        <div >
             <asp:Image ID="Image4" runat="server" ImageUrl="~/images/def_cont_slip.jpg" />
         </div>
          <div style="width:980px;height:auto;text-align:left;float:none;margin:0 auto;top:0;">
             <table>
                 <tr>
                     <td style="text-align:left;">
<span>热点推荐：</span>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <div  style="text-align:left;width:auto;height:400px;overflow:auto;">
                          <%=getHotFile() %>
                            

                             </div>
                     </td>
                 </tr>
             </table>

         </div>  
        <%--   <div >
             <asp:Image ID="Image2" runat="server" ImageUrl="~/images/def_cont_slip2.jpg" />
         </div>--%>
          
       <%--  <div style="width:980px;height:auto;text-align:left;float:none;margin:0 auto;top:0;">
             <table>
                 <tr>
                     <td style="text-align:left;">
<span>视频资料：</span>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <div  style="text-align:left;width:auto;height:400px;overflow:auto;">
                        <%=getHtmlList()%>
                             </div>
                     </td>
                 </tr>
             </table>

         </div>  --%>
                    <div >
             <asp:Image ID="Image3" runat="server" ImageUrl="~/images/def_cont_slip.jpg" />
         </div>       
         <%--<div >--%>
             <%--   <span>PDF文件列表:</span>
            <table class="tabletitle">
               <tr><td width="25%">文&nbsp;件&nbsp;标&nbsp;题</td><td width="30%">创&nbsp;建&nbsp;日&nbsp;期</td><td width="20%">文&nbsp;件&nbsp;大&nbsp;小</td><td width="25%">相&nbsp;关&nbsp;操&nbsp;作</td></tr>
           </table>
           <table>
               <!--PDF文件列表数据-->
                <%=getPdfList()%>
           </table>--%>
           <%--</div>--%>
   
       
        <%--<div ><iframe name="readpage" style="height:800px; width:900px"></iframe> </div>--%>
  <hr size="1" style="background-color: #000000" />   
     <div style="text-align:center;width:980px;height:100px;vertical-align:top;">
       
 <asp:Label ID="Label1" runat="server" Text="精益资料查阅平台" Font-Bold="False" Font-Size="Medium"></asp:Label>
  
    <br />
    <br />
     <asp:Label ID="Label2" runat="server" Text="自动化部(软件)" Font-Bold="False" Font-Size="Medium"></asp:Label>
     </div>
    
 

 </form>
 </body> 
</html>


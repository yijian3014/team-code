<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="file_list.aspx.cs" Inherits="ntkoofficedemo_vs2008_.file_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   
           
     <script language="javascript" type="text/javascript" src="ntko.js"></script>

 
</head>
<body style="width:800px;height:600px;text-align:center;float:none;margin:0 auto;">
    <form  id="form1" runat="server">
        
        <table style="width:800px;height:auto;text-align:center;">

       
                            
                  <tr>
                    <td >
              精益文档查阅系统
                     </td>
                 </tr>
     </table> 
   <div  style="text-align:left;">
       <span>OFFICE文件列表:</span>

       <table style="width:800px;height:auto;text-align:center;">          
                   <tr>
                       <td width="60%">文&nbsp;件&nbsp;标&nbsp;题</td>
                 
                       <td width="20%">文&nbsp;件&nbsp;类&nbsp;型</td>
                       <td width="20%">相&nbsp;关&nbsp;操&nbsp;作</td>

                   </tr>
               </table>
               <table style="width:800px;height:auto;text-align:left;">
                 <%=getFilesList() %>
               </table>
         </div> 
       <div  style="text-align:left;">
           <span>视频文件列表: </span>
                   <table style="width:800px;height:auto;text-align:center;" class="auto-style1" >
               <tr>
                   <td width="60%">文&nbsp;件&nbsp;标&nbsp;题</td>
                 <%--  <td width="30%">创&nbsp;建&nbsp;日&nbsp;期</td>--%>
                   <td width="20%">文&nbsp;件&nbsp;类&nbsp;型</td>
                   <td width="20%">相&nbsp;关&nbsp;操&nbsp;作</td>
               </tr>
           </table>
           <table style="width:800px;height:auto;text-align:left;">
                <!--HTML文件列表数据-->
                <%=getHtmlList()%>
           </table>
           </div>
         <div >
          <%--   <span>PDF文件列表:</span>
            <table class="tabletitle">
               <tr><td width="25%">文&nbsp;件&nbsp;标&nbsp;题</td><td width="30%">创&nbsp;建&nbsp;日&nbsp;期</td><td width="20%">文&nbsp;件&nbsp;大&nbsp;小</td><td width="25%">相&nbsp;关&nbsp;操&nbsp;作</td></tr>
           </table>
           <table>
               <!--PDF文件列表数据-->
                <%=getPdfList()%>
           </table>--%>
           </div>
   
         <%--<div>
               <iframe name="readpage" style="height:800px; width:900px"></iframe> </div>--%>
   
     <div style="text-align:center;">
         系统必备组件（最低版本）：OFFICE 2007 办公套件，IE8.0</div>
    </form>
    </body>  
</html>


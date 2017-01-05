<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rp.aspx.cs" Inherits="ntkoofficedemo_vs2008_.rp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="width: 1024px; height: 768px;text-align:center;position:static;float:none;margin:0 auto;" >
    <form id="form1" runat="server" style="width: 100%; height: 100%;text-align:center;float:inherit;">
         <div >
             <asp:Image ID="Image1" runat="server" ImageUrl="~/images/read_banner.jpg" />
         </div>
        <div  style="width: 100%; height: 100%;text-align:center;float:inherit;"> 


        
     <table style="width:100%; height:100%;float:inherit;text-align:center;float:inherit;">
    <tr>
        <td class="auto-style1">
            <h2> 视频点播系统</h2>
        </td>
    </tr>
    <tr>
        <td >
            <OBJECT ID="video1" CLASSID="clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA"style="width:800px;height:600px;text-align:center;">
<param name="_ExtentX" value="21167"/>
<param name="_ExtentY" value="15875"/>
<param name="AUTOSTART" value="1"/>
<param name="SHUFFLE" value="0"/>
                <%--拖拽--%>
<param name="PREFETCH" value="0"/>
                <%--预读取--%>
<param name="NOLABELS" value="0"/>
<param name="SRC" value="<%=stream_serv+filename %>"/>
<param name="CONTROLS" value="ImageWindow,ControlPanel"/>

<param name="CONSOLE" value="Clip1"/>
<param name="LOOP" value="0"/>
<param name="NUMLOOP" value="0"/>
<param name="CENTER" value="0"/>
<param name="MAINTAINASPECT" value="1"/>
                <%--保持长宽比--%>
<param name="BACKGROUNDCOLOR" value="#000000"/>
 <embed SRC type="audio/x-pn-realaudio-plugin" CONSOLE="Clip1" CONTROLS="ImageWindow" AUTOSTART="true"/>
</OBJECT>
        </td>
   </tr>
    <tr>
        <td>
            <asp:HyperLink ID="HyperLink2" runat="server" 
               NavigateUrl="http://10.11.10.159:1080/video_plus/RealPlayer_cn.exe">如果无法播放,请点击并安装RealPlayer播放器</asp:HyperLink>

        </td>
    </tr>
</table>
            </div>
 </form>
 </body>
</html>

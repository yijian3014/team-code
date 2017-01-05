<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wmp.aspx.cs" Inherits="ntkoofficedemo_vs2008_.wmp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="text-align: center">
    <div  style="width: 1024px; height: 768px;text-align:center;position:static;float:inherit;margin:0 auto;"> 

    
    <form id="form1" runat="server">
   <div >
             <asp:Image ID="Image1" runat="server" ImageUrl="~/images/read_banner.jpg" />
         </div>
        <table style="width:100%; height: 100%;text-align:center;position:static;float:inherit;margin:0 auto;">
            <tr>
                <td>
                    <h2> 视频点播系统 </h2>
                </td>
            </tr>
            <tr>
                <td>
                    <object ID="MediaPlayer1" align="top"classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6" 
            codebase="http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701" 
            standby="Loading" type="application/x-oleobject" style="text-align: center; margin-left: 0px; height: 599px; width: 75%; margin-top: 0px; margin-bottom: 0px;">
            <param name="URL" value="<%=stream_serv + filename %>"/>
            <param name="rate" value="1"/>
            <param name="balance" value="0"/> 
            <param name="currentPosition" value="-1"/>
            <param name="defaultFrame" value=""/>
            <param name="playCount" value="1"/>
            <param name="autoStart" value="1"/>
            <param name="currentMarker" value="0"/>
            <param name="invokeURLs" value="-1">
            <param name="baseURL" value=""/>
            <param name="volume" value="100"/> 
            <param name="mute" value="0"/>
            <param name="uiMode" value="full"/>
            <param name="stretchToFit" value="1"/> 
            <param name="windowlessVideo" value="0"/>
            <param name="enabled" value="-1"/>
            <param name="enableContextMenu" value="-1"/>
            <param name="fullScreen" value="0"/>
            <param name="SAMIStyle" value=""/>
            <param name="SAMILang" value=""/> 
            <param name="SAMIFilename" value=""/> 
            <param name="captioningID" value=""/> 
            <param name="enableErrorDialogs" value="0"/>
            <param name="_cx" value="9313"/> 
            <param name="_cy" value="8520"/>
        </object>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:HyperLink ID="HyperLink1" runat="server" 
               NavigateUrl="http://10.11.10.159:1080/video_plus/wmp11-windowsxp-x86-ZH-CN_11.0.5721.5262.1392692276.exe">WIN_XP用户如果无法播放,请点击并安装WindowsMediaPlayer播放器</asp:HyperLink>
                     
                </td>
            </tr>
        </table>
				 
        
    </form>

</div> 
 </body>
</html>

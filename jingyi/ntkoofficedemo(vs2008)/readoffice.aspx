<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="readoffice.aspx.cs" Inherits="ntkoofficedemo_vs2008_.readoffice" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
		<meta content="IE=7" http-equiv="X-UA-Compatible" />
    <title><%=title %>&nbsp;-文档阅读</title>
  
    <script language="javascript" type="text/javascript" src="ntko.js"></script>
       
<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {
        ntkoofficedemo_vs2008_.ftp_jy ftp_file = new ntkoofficedemo_vs2008_.ftp_jy();
        
        try
        {

            if (!ftp_file.FileExist(fileid,filetitle,fileother,is_hotfile))
            {
                
                ftp_file.down_file(@"uploadfile/", @"uploadfile/", filename);
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                Response.Redirect(Request.Url.ToString( ));
            }
        
        // Introducing delay for demonstration.
     
  
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());

        }
    }
    </script>
</head>
<body onload='editoffice("<%=url %>","<%=newofficetype %>");FormDisabled(true);'style="width:1000px;height:auto;margin:0 auto;float:none;text-align:center;"><%-- formdisabled用于控制NTKO控件的显示样式 --%>
    <form id="form1" runat="server">
       
            <div >
             <asp:Image ID="Image1" runat="server" ImageUrl="~/images/read_banner.jpg" />
         </div>
      
           <div id="editmain" class="editmain">
       
 <div id="editmain_middle" class="editmain_middle">
             <div id="editmain_left" class="editmain_left">
             <!--JS功能按钮开始位置-->
                 <%-- <div class="funbutton">
                    <ul class="ul">
                    <li class="listtile">界面设置:</li>  
                    <li onclick="TANGER_OCX_OBJ.Menubar=!TANGER_OCX_OBJ.Menubar;">菜单栏栏切换</li>
                    <li onclick="TANGER_OCX_OBJ.ToolBars=!TANGER_OCX_OBJ.ToolBars;">工具栏栏切换</li>
                    <li onclick="TANGER_OCX_OBJ.IsShowInsertMenu=!TANGER_OCX_OBJ.IsShowInsertMenu;">"插入"菜单切换</li>
                    <li onclick="TANGER_OCX_OBJ.IsShowEditMenu=!TANGER_OCX_OBJ.IsShowEditMenu;">"编辑"菜单切换</li>
                    <li onclick="TANGER_OCX_OBJ.IsShowToolMenu=!TANGER_OCX_OBJ.IsShowToolMenu;">"工具"菜单切换</li>
                    </ul>
                </div>
             <div class="funbutton">
                    <ul class="ul">
                    <li class="listtile">打印控制:</li>
                    <li onclick="setFilePrint(true);">允许打印</li>
                    <li onclick="setFilePrint(false);">禁止打印</li>
                    <li onclick="TANGER_OCX_OBJ.showDialog(5);">页面设置</li>
                    <li onclick="TANGER_OCX_OBJ.PrintPreview();">打印预览</li>
                    </ul>
                </div>
              
              
                <div class="funbutton">
                    <ul class="ul">
                    <li class="listtile">痕迹保留功能:</li>
                    <li onclick="SetReviewMode(true);">保留痕迹</li>
                    <li onclick="SetReviewMode(false);">取消留痕</li>
                    <li onclick="setShowRevisions(true);">显示痕迹</li>
                    <li onclick="setShowRevisions(false);">隐藏痕迹</li>
                    </ul>
                </div>
                <div class="funbutton">
                    <ul class="ul">
                    <li class="listtile">权限控制:</li>
                    <li onclick="TANGER_OCX_OBJ.SetReadOnly(true);">禁止编辑</li>
                    <li onclick="TANGER_OCX_OBJ.SetReadOnly(false);">允许编辑</li>
                    <li onclick="setFileNew(true);">允许新建</li>
                    <li onclick="setFileNew(false);">禁止新建</li>
                    <li onclick="setFileSaveAs(true);">允许另存</li>
                    <li onclick="setFileSaveAs(false);">禁止另存</li>
                    <li onclick="setIsNoCopy(false);">允许拷贝</li>
                    <li onclick="setIsNoCopy(true);">禁止拷贝</li>
                    </ul>
                </div>
             <!--JS功能按钮结束位置--> 
                 <asp:Label ID="Label1" runat="server" Text="文档所属分类："></asp:Label>--%>
            </div>
            <div id="editmain_right" class="editmain_right">
         
                    <table>
               
                        <tr>
                            <td width="7%" class="auto-style2"> 文&nbsp;件&nbsp;ID:</td>
                            <td width="20%" class="auto-style2"><input id="fileid" name="fileid" type="text" value="<%=fileid %>" disabled="disabled" /></td>
                            <td width="7%" class="auto-style2">文件标题:</td>
                            <td width="40%" class="auto-style2"><input id="filetitle" name="filetitle" type="text" value="<%=filetitle %>"/>
                             
                            <input id="filename" name="filename" type="text" value="<%=filename %>" style="display:none"/>
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="刷新" />
                            </td>
                           <%-- style="display:none"隐藏了文件窗口，上面INPUT触发了文件的更新--%>
                        </tr>
                        <%--  <tr>
                            <td>其它数据:</td>
                            <td><input id="fileother" name="fileother"  type="text" value="<%=fileother %>"/></td>
                            <td >上传文件:</td>
                            <td><input class="fileup" id="upattach" type="file" name="attach" /></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr><td colspan="5" >&nbsp;</td></tr>
                        <tr><td>其它附件:</td>
                            <td colspan="4">
                            <!--附件列表-->
                            <%=getAttaches() %>
                            </td>
                        </tr>--%>
                    </table>
     <span style="color:red">不能打开文档，显示NTKO控件过期时，请将您的系统时间调至2016年9月，关闭IE，重新登陆打开文档即可！</span>  

             
                <div id="officecontrol">
                    
               <!--引用NTKO OFFICE文档控件-->
                    <%--<object id="TANGER_OCX" classid="clsid:01DFB4B4-0E07-4e3f-8B7A-98FD6BFF153F"
codebase="/officecontrol/OfficeControl.cab#version=5,0,2,2" width="100%" height="100%">
 <param name="IsNoCopy" value="1"/>
<param name="FileSave" value="0"/>
<param name="FileSaveAs" value="0"/>
    <param name="FileOpen"value="0" />
    <param name="FileSaveAs" value="0"/>
    <param name="FileOpen"value="0" />
    <param name="FilePageSetup" value="0"/>
    <param name="FileClose"value="0" />
    <param name="FilePrint" value="0"/>
    <param name="FilePrintPreview"value="0" />
    <param name="FilePageSetup" value="0"/>
    <param name="FileProperties"value="0" />
   <param name="IsStrictNoCopy"value="1" />

<param name="FileNew" value="0"/>
<param name="Caption" value="Office 文档在线阅读"/>
<param name="BorderStyle" value="3"/>
<param name="BorderColor" value="14402205"/>
<param name="Titlebar" value="0"/>
<param name="TitlebarColor" value="14402205"/>
<param name="TitlebarTextColor" value="0"/>
<param name="Menubar" value="1"/>
<param name="MenubarColor" value="14402205"/>
<param name="MenuBarStyle" value="2"/>
<param name="MenuButtonFrameColor" value="102205"/>
<param name="ToolBars" value="1"/>
<param name="IsShowToolMenu" value="0"/>
<param name="IsHiddenOpenURL" value="0"/>
<param name="IsUseUTF8URL" value="-1"/>
<param name="MakerCaption" value="中国兵器工业信息中心通达科技"/>
<param name="MakerKey" value="EC38E00341678B7549B46F19D4CAF4D89866B164"/>
<param name="ProductCaption" value="Office Anywhere"/>
<param name="ProductKey" value="460655BF84C22ADA846B8AC7E4B3089882E368B3"/>
<span style="color:red">不能装载文档控件。请确认你可以连接网络或者检查浏览器的选项中安全设置。
    <a href="http://10.11.10.159:1080/officecontrol/OfficeControlSetup.exe">手动安装文档控件</a></span>  

</object>--%>

<object id="TANGER_OCX" classid="clsid:A39F1330-3322-4a1d-9BF0-0BA2BB90E970"    
codebase="/officecontrol/OfficeControl.cab#version=5,0,2,7" width="100%" height="100%">   
<param name="IsUseUTF8URL" value="-1"/> 
<%-- <param name="IsNoCopy" value="1"/>  --%>
   
<param name="FileSave" value="0"/>
<param name="FileSaveAs" value="0"/>
    <param name="FileNew"value="0" />
    <param name="FileSaveAs" value="0"/>
    <param name="FileOpen"value="0" />
    <param name="FilePageSetup" value="0"/>
    <param name="FileClose"value="0" />
    <param name="FilePrint" value="0"/>
    <param name="FilePrintPreview"value="0" />
    <param name="FilePageSetup" value="0"/>
    <param name="FileProperties"value="0" />
    <param name="Menubar"value="1" />
  <param name="IsStrictNoCopy"value="1" />
 
<param name="IsUseUTF8Data" value="-1"/>  
<param name="ToolBars" value="0"/> 
<param name="BorderStyle" value="1"/>   
<param name="BorderColor" value="14402205"/>   
<param name="TitlebarColor" value="15658734"/>   
<param name="TitlebarTextColor" value="0"/>   
<param name="MenubarColor" value="14402205"/>   
<param name="MenuButtonColor" value="16180947"/>   
<param name="MenuBarStyle" value="3"/>   
<param name="IsShowToolMenu" value="0"/>
<param name="MenuButtonStyle" value="7"/>   
<param name="WebUserName" value="自动化部 软件"/>   
<param name="Caption" value="自动化部 软件"/>   
<span style="color:red">不能装载文档控件。请确认你可以连接网络或者检查浏览器的选项中安全设置。
  <a href="http://10.11.10.159:1080/officecontrol/OfficeControlSetup.exe" name="手动安装文档控件">手动安装文档控件</a></span>       
</object>
      
  <!--控件事件代码开始-->
                <script type="text/javascript" language="JScript" for="TANGER_OCX" event="OnFileCommand(cmd,canceled);">
	                alert(cmd);
	                CancelLastCommand=true;
                </script>
                <script type="text/javascript" language="JScript" for="TANGER_OCX" event="OnDocumentClosed();">
	                setFileOpenedOrClosed(false);
                </script>
                <script type="text/javascript" language="JScript" for="TANGER_OCX" event="OnDocumentOpened(TANGER_OCX_str,TANGER_OCX_obj);">
	                //saved属性用来判断文档是否被修改过,文档打开的时候设置成ture,当文档被修改,自动被设置为false,该属性由office提供.
                   TANGER_OCX_OBJ.SetReadOnly(true);//文件只读保护,setreadonly方法
                    TANGER_OCX_OBJ.setIsNoCopy = true;//禁止拷贝
                    TANGER_OCX_OBJ.Menubar = true;
                </script>
                     <script  type="text/javascript" language="JScript" for="TANGER_OCX" event="OnPPTBeforeRightClick(TANGER_OCX_obj);">
                         TANGER_OCX.CancelPPTRightClick = true; //无效
                         TANGER_OCX.on
                </script>
	                <script  type="text/javascript" language="JScript" for="TANGER_OCX" event="BeforeOriginalMenuCommand(TANGER_OCX_str,TANGER_OCX_obj);">
	                alert("BeforeOriginalMenuCommand事件被触发");
                </script>
                <script type="text/javascript" language="JScript" for="TANGER_OCX" event="OnFileCommand(TANGER_OCX_str,TANGER_OCX_obj);">
	                if (TANGER_OCX_str == 3) 
	                {
		                alert("不能保存！");
		                CancelLastCommand = true;
	                }
                </script>
                <script language="JScript" for="TANGER_OCX" event="OnCustomMenuCmd2(menuPos,submenuPos,subsubmenuPos,menuCaption,menuID)">
		            //alert("第" + menuPos +","+ submenuPos +","+ subsubmenuPos +"个菜单项,menuID="+menuID+",菜单标题为\""+menuCaption+"\"的命令被执行.");
		            if("全网页查看"==menuCaption)objside();
		            if("恢复原大小"==menuCaption)objside2();
	            </script>
                    <a></a>
                <script type="text/javascript" language="JScript" for="TANGER_OCX" event="AfterPublishAsPDFToURL(result,code);">
	                result=trim(result);
	                document.all("statusBar").innerHTML="服务器返回信息:"+result;
	                if(result=="succeed")
	                {window.close();}
                </script>
                <!--控件事件代码结束-->
                </div>
            </div>
      </div>
        </div>    
    </form>
</body>
</html>

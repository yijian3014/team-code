<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editoffice.aspx.cs" Inherits="ntkoofficedemo_vs2008_.editoffice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
		<meta content="IE=7" http-equiv="X-UA-Compatible" />
    <title><%=title %>&nbsp;-文档编辑</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="ntko.js"></script>
</head>
<body onload='editoffice("<%=url %>","<%=newofficetype %>");' onunload="onPageClose();">
    <form id="form1" action="save.aspx" enctype="multipart/form-data">
    <div id="editmain" class="editmain">
        <div id="edittop" class="top">
        <img alt="重庆软航科技有限公司示例程序" src="images/edit_banner.jpg" />
        </div>
        <div id="editmain_top" class="editmain_top">
                <div id="edit_button_div" class="edit_button_div">
                <img alt="保存office文档" src="images/edit_save_office.gif" onclick="saveFileToUrl();" />
                <img alt="保存html文档" src="images/edit_save_html.gif" onclick="saveFileAsHtmlToUrl();"/>
                <img alt="保存PDF" src="images/edit_save_pdf.gif" onclick="saveFileAsPdfToUrl();"/>
                <img alt="示例程序帮助文档" src="images/demohelp.jpg" onclick="NtkoHelp();"/>
                </div>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td><img src="images/edit_main_top.jpg"  alt="文件列表上框" /></td>
                </tr>
                <tr>
                    <td class="edittablebackground"><!--示例标题--><%=title %></td>
                </tr>
            </table>
        </div>
        <div id="editmain_middle" class="editmain_middle">
            <div id="editmain_left" class="editmain_left">
            <!--JS功能按钮开始位置-->
                <div class="funbutton">
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
                    <li class="listtile">印章和图片功能:</li>
                    <li>
                    <select id="SignFileUrl" onchange="var signUrl=document.all('SignFileUrl').options[document.all('SignFileUrl').selectedIndex].value;if(signUrl==''){};else addServerSign(signUrl);">
                    <option value="" "selected">请选择服务器印章</option>
                    <option value="esp/hetong.esp">合同演示印章</option>
                    <option value="esp/caiwu.esp.esp">财务演示印章</option>
                    <option value="esp/xingzheng.esp">行政演示印章</option>
                    </select>
                    </li>
                    <li onclick="addLocalSign();">添加本地印章</li>
                    <li onclick="doHandSign();">手写签名</li>
                    <li onclick="TANGER_OCX_OBJ.SetReadOnly(true,'',1);">保护印章</li>
                    <li onclick="TANGER_OCX_OBJ.SetReadOnly(false);">取消保护</li>
                    <li onclick="DoCheckSign();">印章验证</li>
                    <li>
                    <select id="picFileUrl" onchange="var picUrl=document.all('picFileUrl').options[document.all('picFileUrl').selectedIndex].value;if(picUrl==''){};else addPicFromUrl(picUrl);">
                    <option value="" "selected">请选择服务器图片</option>
                    <option value="esp/smallattproduct.jpg">服务器图片1</option>
                    <option value="esp/smalldocproduct.jpg">服务器图片2</option>
                    <option value="esp/smallsgnproduct.jpg">服务器图片3</option>
                    <option value="esp/standard.gif">服务器图片4</option>
                    </select>
                    </li>
                    <li onclick="addPicFromLocal();">添加本地图片</li>
                    </ul>
                </div>
                <div class="funbutton">
                    <ul class="ul">
                    <li class="listtile">模板套红功能:</li>
                    <li onclick="TANGER_OCX_AddDocHeader('某某政府机关红头文件');">动态编程套红</li>
                    <li>
                    <select id="buttonsl" onchange="var headFileURL=document.all('buttonsl').options[document.all('buttonsl').selectedIndex].value;if(headFileURL==''){};else insertRedButtomFromUrl(headFileURL);">
                        <option value="" "selected">请选择结尾模板套文</option>
                        <option value="templateFile/ztc.doc">主题词</option>
                    </select>
                    <select id="redHeadTemplateFile" onchange="var headFileURL=document.all('redHeadTemplateFile').options[document.all('redHeadTemplateFile').selectedIndex].value;if(headFileURL==''){};else insertRedHeadFromUrl(headFileURL);">
                        <option value="" "selected">请选择模板进行套红</option>
                        <option value="templateFile/sendFileRedHead.doc">发送文件红头</option>
                        <option value="templateFile/receiveReadHead.doc">接收文件红头</option>
                        <option value="templateFile/archivesRedHead.doc">办公文件红头</option>
                    </select>
                    </li>
                    <li>
                    <select id="templateFile" onchange="var templateFileUrl=document.all('templateFile').options[document.all('templateFile').selectedIndex].value;if(templateFileUrl==''){};else openTemplateFileFromUrl(templateFileUrl);">
                    <option value="" "selected">请选择模板进行打开</option>
                        <option value="templateFile/elegantReportTemplate.doc">典雅型报告模板</option>
                        <option value="templateFile/elegantMemoTemplate.doc">典雅型备忘录模板</option>
                        <option value="templateFile/elegantCommunicationTemplate.doc">典雅型通讯模板</option>
                        <option value="templateFile/theNorthSTLimitedCompanyTemplate.doc">北方科技有限公司模板</option>
                    </select>
                    </li>
                    </ul>
                </div>
                <div class="funbutton">
                    <ul class="ul">
                    <li class="listtile">痕迹保留功能:</li>
                    <li onclick="SetReviewMode(true);">保留痕迹</li>
                    <li onclick="SetReviewMode(false);">取消留痕</li>
                    <li onclick="setShowRevisions(true);">显示痕迹</li>
                    <li onclick="setShowRevisions(false);">隐藏痕迹</li>
                    <li onclick="TANGER_OCX_AllRevisions(true);">接受修订</li>
                    <li onclick="TANGER_OCX_AllRevisions(false);">拒绝修订</li>
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
            </div>
            <div id="editmain_right" class="editmain_right">
                <div id="formtop">
                    <table>
                        <tr>
                            <td colspan="5"  class="edit_tabletitle">文件表单数据:</td>
                        </tr>
                        <tr>
                            <td colspan="5">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="7%"> 文&nbsp;件&nbsp;ID:</td>
                            <td width="20%"><input id="fileid" name="fileid" type="text" value="<%=fileid %>" disabled="disabled" /></td>
                            <td width="7%">文件标题:</td>
                            <td width="40%"><input id="filetitle" name="filetitle" type="text" value="<%=filetitle %>"/><input id="filename" name="filename" type="text" value="<%=filename %>" style="display:none"/></td>
                        </tr>
                        <tr>
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
                        </tr>
                    </table>
                </div>
                <div id="esptoolbar" class="esptoolbar">
                <span class="listtile">安全电子印章系统功能:</span>
                    <select id="secSignFileUrl">
                        <option value="esp/hetong.esp">合同演示印章</option>
                        <option value="esp/hetonge.esp">财务演示印章</option>
                        <option value="esp/xingzheng.esp">行政演示印章</option>
                    </select>
                    <div id="esptoolbutton" class="esptoolbutton">
                    <ul>
                        <li onclick="addServerSecSign();">加盖选择印章</li>
                        <li onclick="addEkeySecSign();">从EKEY盖章</li>
                        <li onclick="addLocalSecSign();">从本机盖章</li>
                        <li onclick="addHandSecSign();">手写签名</li>
                        <li onclick="window.open('espedit.aspx','')">服务器印章管理</li>
                    </ul>
                    </div>
                </div>
                <div id="officecontrol">
                <!--引用NTKO OFFICE文档控件-->
<SPAN STYLE="color:red">如果不能装载文档控件。请确认你可以连接网络或者检查浏览器的选项中安全设置。<a href="http://www.ntko.com/control/officecontrol/officecontrol.zip">下载演示产品</a></SPAN>
                <script language="javascript" type="text/javascript" src="http://www.ntko.com/control/officecontrol/ntkoofficecontrol.js"></script>
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
	                TANGER_OCX_OBJ.ActiveDocument.Saved = true;
	                if(2==TANGER_OCX_OBJ.DocType)
	                {
	                    try{
	                        TANGER_OCX_OBJ.ActiveDocument.Application.ActiveWorkbook.Saved=true;
	                    }catch(e)
	                    {
	                        alert("错误：" + err.number + ":" + err.description);
	                    }
	                 }
	                setFileOpenedOrClosed(true);//设置文档状态值
		            controlStyle();//插入控件样式自定义菜单
		            SetReviewMode(true);//设置文档在痕迹模式下编辑
                            setShowRevisions(true); //设置是否显示痕迹
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
                <script type="text/javascript" language="JScript" for="TANGER_OCX" event="AfterPublishAsPDFToURL(result,code);">
	                result=trim(result);
	                alert(result);
	                if(result=="succeed")
	                {window.close();}
                </script>
                <!--控件事件代码结束-->
                </div>
            </div>
        </div>
       <div id="edit_bottom" class="edit_bottom">
       <img alt="" src="images/edit_main_nether.jpg" />
           <div id="conmpanyinfo" class="conmpanyinfo">
            <img alt="重庆软航科技有限公司" src="images/Companyinfo.jpg" />
            <p>技术支持详见公司网站www.ntko.com “联系我们”</p>
            <p>公司网站:WWW.NTKO.COM&nbsp;&nbsp;&nbsp;技术支持开发网站:DEV.NTKO.COM</p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
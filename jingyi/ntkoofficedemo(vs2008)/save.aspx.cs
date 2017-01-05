using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ntkoofficedemo_vs2008_
{
    public partial class save : System.Web.UI.Page
    {
        ntko_class db = new ntko_class();//实例ntko_class类
        //参数savetype定义要另存的文档格式office,html,pdf
        //参数filetype定义要保存的文档的文件内型
        public string savetype, filetype, fid, title, fother, fname,fname1;

        //定义文件上传路径目录
        public string filepath, htmlpath, pdfpath, attachpath, delcount;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("ok");
            //Response.End();
            fid = Request.Form["fileid"];//获取文件ID
            fname = Request.Form["filename"];//获取已有文件的名称
            title = Request.Form["filetitle"];//获取文件的标题
            savetype = Request.Form["savetype"];//获取文件另存为格式类型
            filetype = Request.Form["filetype"];//获取当前文件的文件格式
            fother = Request.Form["fileother"];
            filepath = db.getofficepath();
            htmlpath = db.gethtmlpath();
            pdfpath = db.getpdfpath();
            attachpath = db.getattachpath();

            //根据保存类型调用相应处理方法
            switch (savetype)
            {
                case "1":
                    saveoffice();
                    break;
                case "2":
                    savehtml();
                    break;
                case "3":
                    savepdf();
                    break;
                case "4":
                    saveesp();
                    break;
                default:
                    saveoffice();
                    break;
            }
        }

        //保存文档为office
        public void saveoffice()
        {
            string uploadoffiepath = Server.MapPath(db.getofficepath().ToString());//上传文件的路径
            string attpath = Server.MapPath(db.getattachpath().ToString());//上传附件文件路径

            System.Web.HttpFileCollection uploadFiles = Request.Files;
            System.Web.HttpPostedFile theFile;

            bool isNewRecord = false;
            if ((fid.Length == 0) || (fid.Trim().Length == 0))
            {
                isNewRecord = true;
            }
            else
            {
                isNewRecord = false;
            }

            if (uploadFiles.Count == 0)
            {
                Response.Write("没有文件上传!");
                return;
            }
            else
            {
                db.open();
                try
                {
                    for (int i = 0; i < uploadFiles.Count; i++)
                    {
                        theFile = uploadFiles[i];
                        if (uploadFiles.GetKey(i).ToUpper() == "EDITFILE")//上传文档控件中的文档
                        {
                            try
                            {
                                //删除选择的附件
                                System.Collections.Specialized.NameValueCollection formValues = Request.Form;
                                for (int a = 0; a < formValues.Count; a++)
                                {
                                    if (formValues.GetKey(a).ToLower() == "delattach")// 根据选择键名进行删除
                                    {
                                        string attachname = "";
                                        string aid = formValues[a];
                                        string delcmd = "Delete From attachs WHERE aid=" + aid;
                                        string getcmd = "select * from attachs where aid=" + aid;
                                        SqlDataReader att = db.datareader(getcmd);
                                        while (att.Read())
                                        {
                                            attachname = att["aname"].ToString();
                                        }
                                        att.Close();
                                        System.IO.File.Delete(attpath + @"\" + attachname);
                                        System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(delcmd, db.connstr);
                                        delcount += Command.ExecuteNonQuery();
                                    }
                                }
                            }
                            catch (Exception err) { }
                            string strcmd = "";
                            if (isNewRecord) // add new record to database
                            {
                                strcmd = "INSERT INTO files (fname,fsize,ftitle,filetype,ftime,fother,fpath) " +
                                    "Values(@fname, @fsize, @ftitle,@filetype,@ftime,@fother,@fpath) select SCOPE_IDENTITY() ";
                            }
                            else
                            {
                                strcmd = "Update files Set fname=@fname,fsize=@fsize,ftitle=@ftitle,filetype=@filetype,ftime=@ftime,fother=@fother," +
                                    "fpath=@fpath  WHERE fid=" + fid;
                            }
                            //string time = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString();
                            string time = System.DateTime.Now.ToString();
                            if (fname == "" || fname == null)
                            {
                                fname = time + "." + theFile.FileName.Substring(theFile.FileName.LastIndexOf('\\') + 1);
                            }
                            fname = fname.Replace(":", ".");//上传文件到磁盘,文件名中不允许带:符号
                            theFile.SaveAs(uploadoffiepath + @"\" + fname);
                            System.Data.SqlClient.SqlCommand objCommand = new System.Data.SqlClient.SqlCommand(strcmd, db.connstr);
                            objCommand.Parameters.Add("@fname", System.Data.SqlDbType.VarChar).Value = fname;
                            objCommand.Parameters.Add("@fsize", System.Data.SqlDbType.VarChar).Value = theFile.ContentLength;
                            objCommand.Parameters.Add("@ftitle", System.Data.SqlDbType.VarChar).Value = title;
                            objCommand.Parameters.Add("@filetype", System.Data.SqlDbType.VarChar).Value = filetype;
                            objCommand.Parameters.Add("@ftime", System.Data.SqlDbType.VarChar).Value = time;
                            objCommand.Parameters.Add("@fother", System.Data.SqlDbType.VarChar).Value = fother;
                            objCommand.Parameters.Add("@fpath", System.Data.SqlDbType.VarChar).Value = filepath;
                            if (isNewRecord) { fid = objCommand.ExecuteScalar().ToString(); }
                            else { objCommand.ExecuteNonQuery(); }
                            Response.Write("ID:" + fid + "</br>");
                            Response.Write("Files: " + fname + "<br>");
                            Response.Write("Size: " + theFile.ContentLength.ToString() + "	bytes<br>");
                            Response.Write("删除附件:" + delcount + "个!<br/>");
                        }
                        else//其它附件上传
                        {
                            string attcmd = "INSERT INTO attachs (fid,aname,asize,apath) Values(@fid, @aname, @asize, @apath)";
                            fname = theFile.FileName.Substring(theFile.FileName.LastIndexOf('\\') + 1);
                            theFile.SaveAs(attpath + @"\" + fname.Replace(":", "."));//上传附件到磁盘,文件名中不允许带:符号
                            System.Data.SqlClient.SqlCommand objCommand = new System.Data.SqlClient.SqlCommand(attcmd, db.connstr);
                            objCommand.Parameters.Add("@fid", System.Data.SqlDbType.Int).Value = System.Convert.ToInt64(fid);
                            objCommand.Parameters.Add("@aname", System.Data.SqlDbType.VarChar).Value = fname;
                            objCommand.Parameters.Add("@asize", System.Data.SqlDbType.VarChar).Value = theFile.ContentLength.ToString();
                            objCommand.Parameters.Add("@apath", System.Data.SqlDbType.VarChar).Value = attachpath;
                            objCommand.ExecuteNonQuery();

                            Response.Write("上传的附件:	" + fname + "<br>");
                            Response.Write("附件大小: " + theFile.ContentLength.ToString() + "	bytes<br>");
                        }
                    }
                }
                finally
                {
                    db.close();
                }
            }
        }

        //保存文档为html
        public void savehtml()
        {
            string htmlsavepath = Server.MapPath(db.gethtmlpath().ToString());//Html文件路径
            System.Web.HttpFileCollection uploadFiles = Request.Files;
            System.Web.HttpPostedFile theFile;

            bool isNewRecord = false;
            if ((fid.Length == 0) || (fid.Trim().Length == 0))
            {
                isNewRecord = true;
            }
            else
            {
                isNewRecord = false;
            }

            if (uploadFiles.Count == 0)
            {
                Response.Write("没有文件上传!");
                return;
            }
            else
            {
                db.open();
                try
                {
                    for (int i = 0; i < uploadFiles.Count; i++)
                    {
                        theFile = uploadFiles[i];
                        if (uploadFiles.GetKey(i).ToUpper() == "EDITFILE")//上传文档控件中的文档
                        {
                            string strcmd = "";
                            if (isNewRecord) // add new record to database
                            {
                                strcmd = "INSERT INTO htmls (fid,hname,hsize,htitle,htime,hpath) " +
                                    "Values(@fid,@hname, @hsize, @htitle,@htime,@hpath)";
                            }
                            else
                            {
                                string pdfsql = "select * from htmls where fid=" + fid;
                                System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(pdfsql, db.connstr);
                                object count = Command.ExecuteScalar();
                                if (count == null)
                                {
                                    strcmd = "INSERT INTO htmls (fid,hname,hsize,htitle,htime,hpath) " +
                                    "Values(@fid,@hname, @hsize, @htitle,@htime,@hpath)";
                                }
                                else
                                {
                                    strcmd = "Update htmls Set fid=@fid,hname=@hname,hsize=@hsize,htitle=@htitle,htime=@htime," +
                                        "hpath=@hpath  WHERE fid=" + fid;
                                }
                            }
                            string time = System.DateTime.Now.ToString();
                            fname = time + "." + theFile.FileName.Substring(theFile.FileName.LastIndexOf('\\') + 1);
                            fname = fname.Replace(":", ".");//上传文件到磁盘,文件名中不允许带:符号
                            string fname2 = fname;
                            if (fname2.Substring(fname2.LastIndexOf('.') + 1) == "htm")
                            {
                                fname1 = fname;
                                System.IO.Directory.CreateDirectory(htmlsavepath + @"\" + fname);
                                System.Data.SqlClient.SqlCommand objCommand = new System.Data.SqlClient.SqlCommand(strcmd, db.connstr);
                                objCommand.Parameters.Add("@fid", System.Data.SqlDbType.VarChar).Value = fid;
                                objCommand.Parameters.Add("@hname", System.Data.SqlDbType.VarChar).Value = theFile.FileName.Substring(theFile.FileName.LastIndexOf('\\') + 1);
                                objCommand.Parameters.Add("@hsize", System.Data.SqlDbType.VarChar).Value = theFile.ContentLength.ToString();
                                objCommand.Parameters.Add("@htitle", System.Data.SqlDbType.VarChar).Value = title;
                                objCommand.Parameters.Add("@htime", System.Data.SqlDbType.VarChar).Value = time;
                                objCommand.Parameters.Add("@hpath", System.Data.SqlDbType.VarChar).Value = htmlpath + @"\" + fname;
                                objCommand.ExecuteNonQuery();
                            }
                            theFile.SaveAs(htmlsavepath + @"\" + fname1 + @"\" + theFile.FileName.Substring(theFile.FileName.LastIndexOf('\\') + 1));
                            Response.Write("Files: " + fname + "<br>");
                            Response.Write("Size: " + theFile.ContentLength.ToString() + "	bytes<br>");
                        }
                    }
                }
                finally
                {
                    db.close();
                }
            }
        }

        //保存文档为pdf
        public void savepdf()
        {
            string pdfsavepath = Server.MapPath(db.getpdfpath().ToString());//PDF文件路径
            System.Web.HttpFileCollection uploadFiles = Request.Files;
            System.Web.HttpPostedFile theFile;

            bool isNewRecord = false;
            if ((fid.Length == 0) || (fid.Trim().Length == 0))
            {
                isNewRecord = true;
            }
            else
            {
                isNewRecord = false;
            }

            if (uploadFiles.Count == 0)
            {
                Response.Write("没有文件上传!");
                return;
            }
            else
            {
                db.open();
                try
                {
                    for (int i = 0; i < uploadFiles.Count; i++)
                    {
                        theFile = uploadFiles[i];
                        if (uploadFiles.GetKey(i).ToUpper() == "EDITFILE")//上传文档控件中的文档
                        {
                            string strcmd = "";
                            if (isNewRecord) // add new record to database
                            {
                                strcmd = "INSERT INTO pdfs (fid,pname,psize,ptitle,ptime,ppath) " +
                                    "Values(@fid,@pname, @psize, @ptitle,@ptime,@ppath)";
                            }
                            else
                            {
                                fname = fname + ".pdf";
                                string pdfsql = "select * from pdfs where fid=" + fid;
                                System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(pdfsql, db.connstr);
                                object count = Command.ExecuteScalar();
                                if (count == null)
                                {
                                    strcmd = "INSERT INTO pdfs (fid,pname,psize,ptitle,ptime,ppath) " +
                                    "Values(@fid,@pname, @psize, @ptitle,@ptime,@ppath)";
                                }
                                else
                                {
                                    strcmd = "Update pdfs Set fid=@fid,pname=@pname,psize=@psize,ptitle=@ptitle,ptime=@ptime," +
                                        "ppath=@ppath  WHERE fid=" + fid;
                                }
                            }
                            string time = System.DateTime.Now.ToString();
                            if (fname == "" || fname == null)
                            {
                                fname = time + "." + theFile.FileName.Substring(theFile.FileName.LastIndexOf('\\') + 1);
                            }
                            fname = fname.Replace(":", ".");//上传文件到磁盘,文件名中不允许带:符号
                            theFile.SaveAs(pdfsavepath + @"\" + fname);
                            System.Data.SqlClient.SqlCommand objCommand = new System.Data.SqlClient.SqlCommand(strcmd, db.connstr);
                            objCommand.Parameters.Add("@fid", System.Data.SqlDbType.VarChar).Value = fid;
                            objCommand.Parameters.Add("@pname", System.Data.SqlDbType.VarChar).Value = fname;
                            objCommand.Parameters.Add("@psize", System.Data.SqlDbType.VarChar).Value = theFile.ContentLength.ToString();
                            objCommand.Parameters.Add("@ptitle", System.Data.SqlDbType.VarChar).Value = title;
                            objCommand.Parameters.Add("@ptime", System.Data.SqlDbType.VarChar).Value = time;
                            objCommand.Parameters.Add("@ppath", System.Data.SqlDbType.VarChar).Value = pdfpath;
                            objCommand.ExecuteNonQuery();

                            Response.Write("Files: " + fname + "<br>");
                            Response.Write("Size: " + theFile.ContentLength.ToString() + "	bytes<br>");
                        }
                    }
                }
                finally
                {
                    db.close();
                }
            }
        }
        //保存esp印章文件
        public void saveesp()
        {
            string esppath = Server.MapPath("esp").ToString();//上传印章文件的路径

            System.Web.HttpFileCollection uploadFiles = Request.Files;
            System.Web.HttpPostedFile theFile;

            try
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    theFile = uploadFiles[i];
                    fname = fname.Replace(":", ".");//上传文件到磁盘,文件名中不允许带:符号
                    theFile.SaveAs(esppath + @"\" + fname);
                    Response.Write("Files: " + fname + "<br>");
                    Response.Write("Size: " + theFile.ContentLength.ToString() + "	bytes<br>");
                }
            }
            catch (Exception err) { Response.Write(err.Message); }
        }
    }
}

using System;
using System.Web;
using System.Net;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;


namespace ntkoofficedemo_vs2008_
{
    public class ftp_jy
    {
        //private string ftp_url, filepath, filename;
        //FtpWebRequest fwr = null;
        //FtpWebResponse fwrp = null;
        //Stream ftp_stre = null;
        Uri ftp_uri = null;
        //Encoding encode = null;

        public bool ftp_init()
        { ///连接FTP服务器并验证
            ftp_uri = new Uri(geturl());
            return true;
        }

        //public bool get_directory(string src_path, string des_path, string file)
        //{ ///获取服务器目录
        //    //fwr.Method = null;
        //    //fwr.Method = WebRequestMethods.Ftp.ListDirectory;
        //    //fwrp = null;
        //    //fwrp = (FtpWebResponse)fwr.GetResponse();
        //    return true;
        //}
        public bool down_file(string src_path, string des_path, string file)
        { ///从指定路径下载指定文件

            FtpWebRequest reqFTP;
            try
            {

                FileStream outputStream = new FileStream(des_path + file, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(geturl() + src_path + file));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = false;
                reqFTP.Credentials = new NetworkCredential(ftp_usr(), ftp_pas(), ftp_domain());

                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "Download Error --> " + ex.Message);
                return false;
            }

        }
        public string[] GetFileList(string mask)
        {

            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(geturl() + "uploadFile"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftp_usr(), ftp_pas(), ftp_domain());
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.UsePassive = false;

                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (mask.Trim() != string.Empty && mask.Trim() != "*.*")
                    {

                        string mask_ = mask.Substring(0, mask.IndexOf("*"));
                        if (line.Substring(0, mask_.Length) == mask_)
                        {
                            result.Append(line);
                            result.Append("\n");
                        }
                    }
                    else
                    {
                        result.Append(line);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                downloadFiles = null;
                if (ex.Message.Trim() != "远程服务器返回错误: (550) 文件不可用(例如，未找到文件，无法访问文件)。")
                {
                    Insert_Standard_ErrorLog.Insert("FtpWeb", "GetFileList Error --> " + ex.Message.ToString());
                }
                return downloadFiles;
            }
        }

        public bool FileExist(string file_id,string  file_name,string  file_type,string is_hotfile)
        {

            ntko_class db = new ntko_class();//实例ntko_class类
            string RemoteFileName = file_id + file_name;
            string abs_path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + System.Configuration.ConfigurationManager.AppSettings["officePath"].ToString().Trim() + "\\";
            int day = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["save_windows"].Trim());
            long minsize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ftp_cache_minsize"].Trim());
            long maxsize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ftp_cache_maxsize"].Trim());
            try
            {
                if (!File.Exists(abs_path + RemoteFileName))
                {


                    string[] fileList = GetFileList("*.*");

                    foreach (string str in fileList)
                    {
                        if (str.Trim() == RemoteFileName.Trim())
                        {
                            string inst_file_str = "if exists(select * from [dzsw].[dbo].[cache_files] where fl_id='" + file_id.Trim()+ "') begin update [dzsw].[dbo].[cache_files] set last_access_time=getdate(),access_count=1  where fl_id='" + file_id.Trim() + "' end else begin insert into [dzsw].[dbo].[cache_files]  values('" + file_id  + "','" + file_name  + "','" +file_type + "',getdate(),'" + is_hotfile + "','1') end";
                            //这里应该加入下载动作
                            if (down_file(@"uploadfile/", abs_path, RemoteFileName) == false)
                            {
                               //与FTPSERVER更新失败
                                return false;
                            }
                            else
                            {
                                db.execsql(inst_file_str);
                                //休眠几秒等待上一步完成
                                System.Threading.Thread.Sleep(2000);
                                //下载后可能空间超标，触发空间检查动作。

                                cleancache( maxsize ,day-10 );
                                return true;
                            }
                        }
                    }
                    return false;

                }
                else
                {
                    //string upd_file_str = "update  [dzsw].[dbo].[cache_files] set last_access_time=getdate(),access_count= access_count+1 where fl_id="+file_id.Trim();
                    string upd_file_str = "if exists(select * from [dzsw].[dbo].[cache_files] where fl_id='" + file_id.Trim() + "') begin update  [dzsw].[dbo].[cache_files] set last_access_time=getdate(),access_count= access_count+1 where fl_id='" + file_id.Trim()+"' end else begin insert into [dzsw].[dbo].[cache_files]  values('" + file_id + "','" + file_name + "','" + file_type + "',getdate(),'" + is_hotfile + "','1') end";

                    db.execsql(upd_file_str);
                    System.Threading.Thread.Sleep(1000);
                    cleancache(minsize, day);

                    return true;
                }
                


            }
            catch (Exception er)
            {
                //没法将服务器错误带回前台，待修正
                return false;
            }
            }
        public string geturl()
        {
            string url;
            url = "ftp://" + System.Configuration.ConfigurationManager.AppSettings["ftp_srv"].ToString() + ":" + System.Configuration.ConfigurationManager.AppSettings["ftp_port"].ToString() + "/";
            return url;
        }
        public string ftp_usr()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ftp_usr"].ToString().Trim();
        }
        public string ftp_pas()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ftp_pas"].ToString().Trim();
        }
        public string ftp_domain()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ftp_domain"].ToString().Trim();
        }
        public long get_cachesize()
        {
            string abs_path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + System.Configuration.ConfigurationManager.AppSettings["officePath"].ToString().Trim() + "\\";

            if (!Directory.Exists(abs_path))
                return 0;
            long  size=0;
            
           DirectoryInfo di = new DirectoryInfo(abs_path);
            foreach (FileInfo fi in di.GetFiles())
            {
                size+= fi.Length;
            }
            return size/1048576;//1024*1024=1048576 转为MB
        }
        public bool cleancache(long cache_size,int day)
        {
            if (get_cachesize() >cache_size)
            {

                if (deletefile(day)) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }
        public bool deletefile(int day)
        {
            string abs_path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + System.Configuration.ConfigurationManager.AppSettings["officePath"].ToString().Trim() + "\\";
            DataSet ds_fname = new DataSet();
            ntko_class db = new ntko_class();
            ds_fname = db.dataset("select  fl_id,name,type  from [dzsw].[dbo].[cache_files] where last_access_time< dateadd(minute,-"+day+",getdate()) order by last_access_time asc");
            foreach (DataRow dr in ds_fname.Tables[0].Rows)
            {
                if (File.Exists(abs_path + dr[0].ToString().Trim() + dr[1].ToString().Trim()))
                {
                    File.Delete(abs_path + dr[0].ToString().Trim() + dr[1].ToString().Trim());
                    string delsql = "delete from[dzsw].[dbo].[cache_files] where fl_id='" + dr[0].ToString().Trim() + "'";
                    db.execsql(delsql);
                }
            }
            ds_fname.Clear();
            //string delsql = "delete from[dzsw].[dbo].[cache_files] where last_access_time<dateadd(minute,-" +day+ ", getdate())";
            //db.execsql(delsql);
            return true;
        }

        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此模块
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        ////#region IHttpModule Members

        //public void Dispose()
        //{
        //    //此处放置清除代码。
        //}

        //public void Init(HttpApplication context)
        //{
        //    // 下面是如何处理 LogRequest 事件并为其 
        //    // 提供自定义日志记录实现的示例
        //    context.LogRequest += new EventHandler(OnLogRequest);
        //}

        //#endregion

        //public void OnLogRequest(Object source, EventArgs e)
        //{
        //    //可以在此处放置自定义日志记录逻辑
        //}
        public class Insert_Standard_ErrorLog
        {
            public static void Insert(string x, string y)
            {

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomControl
{
    
    //自定义的异常，并写入日志文件
    public class MException : ApplicationException
    {
        public MException(string message) : base(message)
        {

            MessageBox.Show(message);
            WriteLog(this); //写入日志           
        }
        //将错误写入日志
        public static void WriteLog(MException ex)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("*****************************************************************\n");
            msg.AppendFormat(" 异常发生时间： {0} \n", DateTime.Now);
            msg.AppendFormat(" 异常类型： {0} \n", ex.HResult);
            msg.AppendFormat(" 导致当前异常的 Exception 实例： {0} \n", ex.InnerException);
            msg.AppendFormat(" 导致异常的应用程序或对象的名称： {0} \n", ex.Source);
            msg.AppendFormat(" 引发异常的方法： {0} \n", ex.TargetSite);
            msg.AppendFormat(" 异常堆栈信息： {0} \n", ex.StackTrace);
            msg.AppendFormat(" 异常消息： {0} \n", ex.Message);
            msg.Append("*****************************************************************");

            string errorTime = "异常时间：" + DateTime.Now.ToString();
            string errorInfo = "异常信息：" + ex.Message;
            string errorSource = "错误源：" + ex.Source;
            string errorType = "运行类型：" + ex.GetType();
            string errorFunction = "异常函数：" + ex.TargetSite;
            string errorTrace = "堆栈信息：" + ex.StackTrace;
            System.IO.StreamWriter writer = null;
            try
            {
                //写入日志
                string path = string.Empty;
                path = Application.StartupPath + "\\errorLog\\" + DateTime.Now.Year + '-' + DateTime.Now.Month + '-' + DateTime.Now.Day + "_Log.log";
                
                //不存在则创建错误日志文件夹
                writer = !System.IO.File.Exists(path) ? System.IO.File.CreateText(path) : System.IO.File.AppendText(path); //判断文件是否存在，如果不存在则创建，存在则添加
                writer. WriteLine(msg.ToString());


            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="LogAddress">日志文件地址</param>
        public static void WriteLog(MException ex, string LogAddress = "")
        {
            //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
            if (LogAddress == "")
            {
                LogAddress = Environment.CurrentDirectory + "\\errorLog\\" +
                    DateTime.Now.Year + '-' +
                    DateTime.Now.Month + '-' +
                    DateTime.Now.Day + "_Log.log";
            }
            //把异常信息输出到文件，因为异常文件由这几部分组成，这样就不用我们自己复制到文档中了
            System.IO.StreamWriter fs = new System.IO.StreamWriter(LogAddress, true);
            fs.WriteLine("当前时间：" + DateTime.Now.ToString());
            fs.WriteLine("异常信息：" + ex.Message);
            fs.WriteLine("异常对象：" + ex.Source);
            fs.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
            fs.WriteLine("触发方法：" + ex.TargetSite);
            fs.WriteLine();
            fs.Close();
        }
    }

}

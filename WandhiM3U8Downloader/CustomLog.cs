using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WandhiM3U8Downloader
{
    public class CustomLog : ILog
    {
        TextBox txt;
        public CustomLog(TextBox control)
        {
            txt = control;
        }
        public void Error(string info)
        {
            txt.AppendText($"{DateTime.Now}-错误:{info}"+"\r\n");
        }

        public void Info(string info)
        {
            txt.AppendText($"{DateTime.Now}-信息:{info}" + "\r\n");
        }

        public void Waring(string info)
        {
            txt.AppendText($"{DateTime.Now}-警告:{info}" + "\r\n");
        }
    }
}

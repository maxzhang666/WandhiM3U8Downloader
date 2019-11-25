using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WandhiM3U8Downloader
{
   public interface ILog
    {
        void Info(string info);

        void Waring(string info);

        void Error(string info);
    }
}

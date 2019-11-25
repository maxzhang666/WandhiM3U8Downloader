using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WandhiM3U8Downloader
{
    public class M3U8Entity
    {
        /// <summary>
        /// 分段标题
        /// </summary>
        public string Title { set; get; } = "空";
        /// <summary>
        /// 分段地址
        /// </summary>
        public string Url { set; get; }
        /// <summary>
        /// 分段时长
        /// </summary>
        public double Duration { set; get; }
    }
}

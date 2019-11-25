using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WandhiM3U8Downloader
{
    public class M3U8Parse
    {
        public string Url = "";
        public List<M3U8Entity> downloadsUrl = new List<M3U8Entity>();
        private ILog log = null;
        private bool isM3u = false;
        private bool extinf = false;
        private double totalTime = 0;

        public M3U8Parse()
        {

        }
        public M3U8Parse(string url)
        {
            this.Url = url;
        }
        public M3U8Parse(string url, ILog log)
        {
            this.log = log;
            this.Url = url;
        }
        public void parse()
        {
            //获取m3u8文件内容
            log.Info("准备获取地址");
            var M3U8Content = GHttpHelper.Http.Get(Url);
            log.Info("获取m3u8内容成功,长度：" + M3U8Content.Length);
            //解析文件内容
            log.Info("开始解析文件内容");
            using (StringReader reader = new StringReader(M3U8Content))
            {
                var currentLine = "";
                var sb = new StringBuilder();
                //# EXTM3U
                //# EXT-X-VERSION:3
                //# EXT-X-TARGETDURATION:8
                //# EXT-X-MEDIA-SEQUENCE:0
                //# EXTINF:4.000000,
                //2cb056dc5bb000000.ts
                var tempDuration = new M3U8Entity();
                while ((currentLine = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(currentLine))
                    {
                        continue;
                    }
                    if (currentLine.StartsWith(M3U8Constant.ext_m3u))
                    {
                        isM3u = true;
                    }

                    else if (currentLine.StartsWith(M3U8Constant.extinf))
                    {
                        var tempInfo = currentLine.Replace(M3U8Constant.extinf + ":", "").Split(',');
                        //记录分片时间
                        tempDuration.Duration = double.Parse(tempInfo[0]);
                        if (tempInfo.Count() > 1 && !(string.IsNullOrEmpty(tempInfo[1])))
                        {
                            tempDuration.Title = tempInfo[1];
                        }
                        totalTime += tempDuration.Duration;
                        extinf = true;
                    }
                    else if (extinf)
                    {
                        //拼接分片地址
                        tempDuration.Url = CombineUrl(Url, currentLine);
                        downloadsUrl.Add(tempDuration);
                        tempDuration = new M3U8Entity();
                    }
                    else if (currentLine.StartsWith(M3U8Constant.ext_x_endlist))
                    {
                        continue;
                    }
                }
            }
            if (!isM3u)
            {
                log.Info("不是有效的M3U8文件");
            }
            log.Info($"内容解析结束，共解析到{downloadsUrl.Count}个下载链接");
        }

        public string CombineUrl(string baseUrl, string url)
        {
            Uri uri1 = new Uri(baseUrl);  //这里直接传完整的URL即可
            Uri uri2 = new Uri(uri1, url);
            ForceCanonicalPathAndQuery(uri2);  //兼容XP的低版本.Net
            return uri2.ToString();
        }
        private void ForceCanonicalPathAndQuery(Uri uri)
        {
            string paq = uri.PathAndQuery; // need to access PathAndQuery
            System.Reflection.FieldInfo flagsFieldInfo = typeof(Uri).GetField("m_Flags", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            ulong flags = (ulong)flagsFieldInfo.GetValue(uri);
            flags &= ~((ulong)0x30); // Flags.PathNotCanonical|Flags.QueryNotCanonical
            flagsFieldInfo.SetValue(uri, flags);
        }
    }
}

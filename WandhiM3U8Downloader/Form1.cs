using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WandhiM3U8Downloader
{
    public partial class form_Main : Form
    {
        public form_Main()
        {
            InitializeComponent();
        }

        private void Btn_Init_Click(object sender, EventArgs e)
        {
            var p = new M3U8Parse("https://dadi-yun.com/20190305/1826_4d2ec220/800k/hls/index.m3u8", new CustomLog(txt_Log));
            p.parse();
            grid_DownloadInfo.DataSource = p.downloadsUrl;
            
        }

        private void Txt_Url_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

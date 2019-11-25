namespace WandhiM3U8Downloader
{
    partial class form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Init = new System.Windows.Forms.Button();
            this.txt_Url = new System.Windows.Forms.TextBox();
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.grid_DownloadInfo = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_DownloadInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Init
            // 
            this.btn_Init.Location = new System.Drawing.Point(551, 12);
            this.btn_Init.Name = "btn_Init";
            this.btn_Init.Size = new System.Drawing.Size(75, 23);
            this.btn_Init.TabIndex = 0;
            this.btn_Init.Text = "解析";
            this.btn_Init.UseVisualStyleBackColor = true;
            this.btn_Init.Click += new System.EventHandler(this.Btn_Init_Click);
            // 
            // txt_Url
            // 
            this.txt_Url.Location = new System.Drawing.Point(52, 12);
            this.txt_Url.Name = "txt_Url";
            this.txt_Url.Size = new System.Drawing.Size(493, 21);
            this.txt_Url.TabIndex = 1;
            // 
            // txt_Log
            // 
            this.txt_Log.BackColor = System.Drawing.Color.Black;
            this.txt_Log.ForeColor = System.Drawing.Color.Lime;
            this.txt_Log.Location = new System.Drawing.Point(52, 303);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.Size = new System.Drawing.Size(736, 135);
            this.txt_Log.TabIndex = 3;
            // 
            // grid_DownloadInfo
            // 
            this.grid_DownloadInfo.AllowUserToAddRows = false;
            this.grid_DownloadInfo.AllowUserToDeleteRows = false;
            this.grid_DownloadInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid_DownloadInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_DownloadInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Url,
            this.Duration});
            this.grid_DownloadInfo.Location = new System.Drawing.Point(52, 39);
            this.grid_DownloadInfo.Name = "grid_DownloadInfo";
            this.grid_DownloadInfo.ReadOnly = true;
            this.grid_DownloadInfo.RowTemplate.Height = 23;
            this.grid_DownloadInfo.Size = new System.Drawing.Size(736, 258);
            this.grid_DownloadInfo.TabIndex = 4;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "标题";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.HeaderText = "下载地址";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Width = 500;
            // 
            // Duration
            // 
            this.Duration.DataPropertyName = "Duration";
            this.Duration.HeaderText = "时长";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            // 
            // form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grid_DownloadInfo);
            this.Controls.Add(this.txt_Log);
            this.Controls.Add(this.txt_Url);
            this.Controls.Add(this.btn_Init);
            this.Name = "form_Main";
            this.Text = "M3U8解析工具";
            ((System.ComponentModel.ISupportInitialize)(this.grid_DownloadInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Init;
        private System.Windows.Forms.TextBox txt_Url;
        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.DataGridView grid_DownloadInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
    }
}


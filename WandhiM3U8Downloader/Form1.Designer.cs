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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txt_Log = new System.Windows.Forms.TextBox();
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
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(52, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(493, 256);
            this.listBox1.TabIndex = 2;
            // 
            // txt_Log
            // 
            this.txt_Log.BackColor = System.Drawing.Color.Black;
            this.txt_Log.ForeColor = System.Drawing.Color.Lime;
            this.txt_Log.Location = new System.Drawing.Point(52, 303);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.Size = new System.Drawing.Size(493, 135);
            this.txt_Log.TabIndex = 3;
            // 
            // form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_Log);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txt_Url);
            this.Controls.Add(this.btn_Init);
            this.Name = "form_Main";
            this.Text = "M3U8解析工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Init;
        private System.Windows.Forms.TextBox txt_Url;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txt_Log;
    }
}


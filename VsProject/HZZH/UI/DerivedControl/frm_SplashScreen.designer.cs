namespace UI
{
    partial class frm_SplashScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SplashScreen));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxinfo = new System.Windows.Forms.RichTextBox();
            this.Lable_time = new System.Windows.Forms.Label();
            this.timerCount = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(735, 396);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(4, 396);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "正在努力加载程序，请稍后...";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Window;
            this.progressBar1.Location = new System.Drawing.Point(4, 419);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.MarqueeAnimationSpeed = 15;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(725, 29);
            this.progressBar1.Step = 2;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(231, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(583, 44);
            this.label2.TabIndex = 4;
            this.label2.Text = "深圳市XXXXXXX有限公司\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(231, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(583, 44);
            this.label3.TabIndex = 5;
            this.label3.Text = "SHEN ZHEN HONG YUAN MACHINE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBoxinfo
            // 
            this.richTextBoxinfo.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxinfo.Cursor = System.Windows.Forms.Cursors.No;
            this.richTextBoxinfo.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxinfo.Location = new System.Drawing.Point(1, 89);
            this.richTextBoxinfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxinfo.Name = "richTextBoxinfo";
            this.richTextBoxinfo.ReadOnly = true;
            this.richTextBoxinfo.Size = new System.Drawing.Size(809, 305);
            this.richTextBoxinfo.TabIndex = 6;
            this.richTextBoxinfo.Text = "";
            this.richTextBoxinfo.TextChanged += new System.EventHandler(this.richTextBoxinfo_TextChanged);
            // 
            // Lable_time
            // 
            this.Lable_time.BackColor = System.Drawing.Color.Transparent;
            this.Lable_time.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lable_time.ForeColor = System.Drawing.Color.Red;
            this.Lable_time.Location = new System.Drawing.Point(493, 396);
            this.Lable_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lable_time.Name = "Lable_time";
            this.Lable_time.Size = new System.Drawing.Size(231, 21);
            this.Lable_time.TabIndex = 7;
            this.Lable_time.Text = "程序启动耗时:";
            this.Lable_time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerCount
            // 
            this.timerCount.Interval = 1000;
            this.timerCount.Tick += new System.EventHandler(this.timerCount_Tick);
            // 
            // frm_SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(815, 454);
            this.Controls.Add(this.Lable_time);
            this.Controls.Add(this.richTextBoxinfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading......";
            this.Load += new System.EventHandler(this.frm_SplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxinfo;
        private System.Windows.Forms.Label Lable_time;
        private System.Windows.Forms.Timer timerCount;
    }
}
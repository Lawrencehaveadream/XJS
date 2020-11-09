namespace HZZH.UI2
{
    partial class ProductSwitchForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("宋体", 20F);
            label1.Location = new System.Drawing.Point(262, 22);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(151, 34);
            label1.TabIndex = 5;
            label1.Text = "当前使用";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            label3.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label3.Location = new System.Drawing.Point(9, 19);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(181, 40);
            label3.TabIndex = 8;
            label3.Text = "品种切换";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Font = new System.Drawing.Font("宋体", 16F);
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(20, 78);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1076, 516);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 260;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "大小";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "修改日期";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 300;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("黑体", 18F);
            this.button1.Location = new System.Drawing.Point(1115, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 90);
            this.button1.TabIndex = 1;
            this.button1.Text = "调用";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("黑体", 18F);
            this.button2.Location = new System.Drawing.Point(1115, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 90);
            this.button2.TabIndex = 2;
            this.button2.Text = "储存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("黑体", 18F);
            this.button3.Location = new System.Drawing.Point(1115, 408);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 90);
            this.button3.TabIndex = 3;
            this.button3.Text = "覆写";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("黑体", 18F);
            this.button4.Location = new System.Drawing.Point(1115, 506);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 90);
            this.button4.TabIndex = 4;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("宋体", 29F);
            this.label2.Location = new System.Drawing.Point(419, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(585, 49);
            this.label2.TabIndex = 6;
            this.label2.Text = "XXXXXXXXXX";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("黑体", 18F);
            this.button5.Location = new System.Drawing.Point(1115, 9);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 55);
            this.button5.TabIndex = 7;
            this.button5.Tag = "RunForm";
            this.button5.Text = "返回";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 29F);
            this.textBox1.Location = new System.Drawing.Point(419, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(585, 63);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "XXXXXXXXX";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProductSwitchForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1239, 606);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Name = "ProductSwitchForm";
            this.Text = "ProductSwitchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
    }
}
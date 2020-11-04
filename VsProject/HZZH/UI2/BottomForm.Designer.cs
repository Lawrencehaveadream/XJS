namespace HZZH.UI2
{
    partial class BottomForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("黑体", 15F);
            this.button1.Location = new System.Drawing.Point(12, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 67);
            this.button1.TabIndex = 0;
            this.button1.Tag = "RunForm";
            this.button1.Text = "自动页面";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Btn_SwitchSubFrom);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 506);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1239, 100);
            this.panel1.TabIndex = 1;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.Control;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("黑体", 15F);
            this.button8.Location = new System.Drawing.Point(1097, 19);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(129, 67);
            this.button8.TabIndex = 7;
            this.button8.Tag = "VisForm";
            this.button8.Text = "视觉";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.Btn_SwitchSubFrom);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Control;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("黑体", 15F);
            this.button7.Location = new System.Drawing.Point(942, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(129, 67);
            this.button7.TabIndex = 6;
            this.button7.Tag = "ParamForm";
            this.button7.Text = "参数";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.Btn_SwitchSubFrom);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("黑体", 15F);
            this.button6.Location = new System.Drawing.Point(787, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(129, 67);
            this.button6.TabIndex = 5;
            this.button6.Tag = "InputIOForm";
            this.button6.Text = "I/O部分";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Btn_SwitchSubFrom);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("黑体", 15F);
            this.button5.Location = new System.Drawing.Point(632, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 67);
            this.button5.TabIndex = 4;
            this.button5.Tag = "MapForm";
            this.button5.Text = "机械参数";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Btn_SwitchSubFrom);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("黑体", 15F);
            this.button4.Location = new System.Drawing.Point(477, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 67);
            this.button4.TabIndex = 3;
            this.button4.Tag = "位置设置";
            this.button4.Text = "位置设置";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Btn_SwitchSubFrom);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("黑体", 15F);
            this.button3.Location = new System.Drawing.Point(322, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 67);
            this.button3.TabIndex = 2;
            this.button3.Tag = "LayerForm";
            this.button3.Text = "UVW平台";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Btn_SwitchSubFrom);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("黑体", 15F);
            this.button2.Location = new System.Drawing.Point(167, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 67);
            this.button2.TabIndex = 1;
            this.button2.Tag = "LoadingForm";
            this.button2.Text = "上下料";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Btn_SwitchSubFrom);
            // 
            // BottomForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1239, 606);
            this.Controls.Add(this.panel1);
            this.Name = "BottomForm";
            this.Text = "7";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}
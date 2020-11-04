namespace HZZH.UI.DerivedControl
{
    partial class XYZ_Jog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XYZ_Jog));
            this.numericUpDown31 = new System.Windows.Forms.NumericUpDown();
            this.Bt_Y_jogPos = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.Bt_Y_jogNeg = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.Bt_X_jogPos = new System.Windows.Forms.Button();
            this.label112 = new System.Windows.Forms.Label();
            this.Bt_X_jogNeg = new System.Windows.Forms.Button();
            this.Bt_home = new System.Windows.Forms.Button();
            this.Bt_Z_jogPos = new System.Windows.Forms.Button();
            this.Bt_Z_jogNeg = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.X_currPos = new System.Windows.Forms.Label();
            this.Y_currPos = new System.Windows.Forms.Label();
            this.Z_currPos = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.C_currPos = new System.Windows.Forms.Label();
            this.Bt_R_jogPos = new System.Windows.Forms.Button();
            this.Bt_R_jogNeg = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Bt_Z1_jogPos = new System.Windows.Forms.Button();
            this.Bt_Z1_jogNeg = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Bt_R1_jogPos = new System.Windows.Forms.Button();
            this.Bt_R1_jogNeg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown31)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown31
            // 
            this.numericUpDown31.DecimalPlaces = 3;
            this.numericUpDown31.Location = new System.Drawing.Point(553, 165);
            this.numericUpDown31.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown31.Name = "numericUpDown31";
            this.numericUpDown31.Size = new System.Drawing.Size(64, 21);
            this.numericUpDown31.TabIndex = 261;
            this.numericUpDown31.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown31.ValueChanged += new System.EventHandler(this.numericUpDown31_ValueChanged);
            // 
            // Bt_Y_jogPos
            // 
            this.Bt_Y_jogPos.BackColor = System.Drawing.Color.Transparent;
            this.Bt_Y_jogPos.FlatAppearance.BorderSize = 0;
            this.Bt_Y_jogPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Y_jogPos.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_Y_jogPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_Y_jogPos.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Y_jogPos.Image")));
            this.Bt_Y_jogPos.Location = new System.Drawing.Point(75, 59);
            this.Bt_Y_jogPos.Name = "Bt_Y_jogPos";
            this.Bt_Y_jogPos.Size = new System.Drawing.Size(40, 53);
            this.Bt_Y_jogPos.TabIndex = 252;
            this.Bt_Y_jogPos.Tag = "1";
            this.Bt_Y_jogPos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Bt_Y_jogPos.UseVisualStyleBackColor = false;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(500, 166);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(48, 16);
            this.checkBox6.TabIndex = 259;
            this.checkBox6.Text = "点动";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // Bt_Y_jogNeg
            // 
            this.Bt_Y_jogNeg.BackColor = System.Drawing.Color.Transparent;
            this.Bt_Y_jogNeg.FlatAppearance.BorderSize = 0;
            this.Bt_Y_jogNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Y_jogNeg.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_Y_jogNeg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_Y_jogNeg.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Y_jogNeg.Image")));
            this.Bt_Y_jogNeg.Location = new System.Drawing.Point(75, 168);
            this.Bt_Y_jogNeg.Name = "Bt_Y_jogNeg";
            this.Bt_Y_jogNeg.Size = new System.Drawing.Size(40, 53);
            this.Bt_Y_jogNeg.TabIndex = 256;
            this.Bt_Y_jogNeg.Tag = "1";
            this.Bt_Y_jogNeg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Bt_Y_jogNeg.UseVisualStyleBackColor = false;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "X轴",
            "Y轴",
            "Z1",
            "Z2",
            "R1",
            "R2"});
            this.comboBox4.Location = new System.Drawing.Point(496, 117);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(87, 28);
            this.comboBox4.TabIndex = 255;
            // 
            // Bt_X_jogPos
            // 
            this.Bt_X_jogPos.BackColor = System.Drawing.Color.Transparent;
            this.Bt_X_jogPos.FlatAppearance.BorderSize = 0;
            this.Bt_X_jogPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_X_jogPos.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_X_jogPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_X_jogPos.Image = ((System.Drawing.Image)(resources.GetObject("Bt_X_jogPos.Image")));
            this.Bt_X_jogPos.Location = new System.Drawing.Point(130, 114);
            this.Bt_X_jogPos.Name = "Bt_X_jogPos";
            this.Bt_X_jogPos.Size = new System.Drawing.Size(50, 53);
            this.Bt_X_jogPos.TabIndex = 254;
            this.Bt_X_jogPos.Tag = "0";
            this.Bt_X_jogPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bt_X_jogPos.UseVisualStyleBackColor = false;
            // 
            // label112
            // 
            this.label112.BackColor = System.Drawing.Color.Transparent;
            this.label112.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label112.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label112.Location = new System.Drawing.Point(527, 92);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(39, 22);
            this.label112.TabIndex = 253;
            this.label112.Text = "回零";
            this.label112.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Bt_X_jogNeg
            // 
            this.Bt_X_jogNeg.BackColor = System.Drawing.Color.Transparent;
            this.Bt_X_jogNeg.FlatAppearance.BorderSize = 0;
            this.Bt_X_jogNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_X_jogNeg.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_X_jogNeg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_X_jogNeg.Image = ((System.Drawing.Image)(resources.GetObject("Bt_X_jogNeg.Image")));
            this.Bt_X_jogNeg.Location = new System.Drawing.Point(11, 114);
            this.Bt_X_jogNeg.Name = "Bt_X_jogNeg";
            this.Bt_X_jogNeg.Size = new System.Drawing.Size(50, 53);
            this.Bt_X_jogNeg.TabIndex = 257;
            this.Bt_X_jogNeg.Tag = "0";
            this.Bt_X_jogNeg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bt_X_jogNeg.UseVisualStyleBackColor = false;
            // 
            // Bt_home
            // 
            this.Bt_home.BackColor = System.Drawing.SystemColors.Control;
            this.Bt_home.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_home.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_home.Image = ((System.Drawing.Image)(resources.GetObject("Bt_home.Image")));
            this.Bt_home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bt_home.Location = new System.Drawing.Point(589, 112);
            this.Bt_home.Name = "Bt_home";
            this.Bt_home.Size = new System.Drawing.Size(41, 35);
            this.Bt_home.TabIndex = 251;
            this.Bt_home.Tag = "0";
            this.Bt_home.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bt_home.UseVisualStyleBackColor = true;
            // 
            // Bt_Z_jogPos
            // 
            this.Bt_Z_jogPos.FlatAppearance.BorderSize = 0;
            this.Bt_Z_jogPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Z_jogPos.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_Z_jogPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_Z_jogPos.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Z_jogPos.Image")));
            this.Bt_Z_jogPos.Location = new System.Drawing.Point(199, 165);
            this.Bt_Z_jogPos.Name = "Bt_Z_jogPos";
            this.Bt_Z_jogPos.Size = new System.Drawing.Size(40, 58);
            this.Bt_Z_jogPos.TabIndex = 262;
            this.Bt_Z_jogPos.Tag = "2";
            this.Bt_Z_jogPos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Bt_Z_jogPos.UseVisualStyleBackColor = true;
            // 
            // Bt_Z_jogNeg
            // 
            this.Bt_Z_jogNeg.FlatAppearance.BorderSize = 0;
            this.Bt_Z_jogNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Z_jogNeg.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_Z_jogNeg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_Z_jogNeg.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Z_jogNeg.Image")));
            this.Bt_Z_jogNeg.Location = new System.Drawing.Point(199, 59);
            this.Bt_Z_jogNeg.Name = "Bt_Z_jogNeg";
            this.Bt_Z_jogNeg.Size = new System.Drawing.Size(40, 53);
            this.Bt_Z_jogNeg.TabIndex = 260;
            this.Bt_Z_jogNeg.Tag = "2";
            this.Bt_Z_jogNeg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Bt_Z_jogNeg.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // X_currPos
            // 
            this.X_currPos.AutoSize = true;
            this.X_currPos.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.X_currPos.Location = new System.Drawing.Point(87, 122);
            this.X_currPos.Name = "X_currPos";
            this.X_currPos.Size = new System.Drawing.Size(16, 16);
            this.X_currPos.TabIndex = 263;
            this.X_currPos.Text = "X";
            // 
            // Y_currPos
            // 
            this.Y_currPos.AutoSize = true;
            this.Y_currPos.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Y_currPos.Location = new System.Drawing.Point(87, 146);
            this.Y_currPos.Name = "Y_currPos";
            this.Y_currPos.Size = new System.Drawing.Size(16, 16);
            this.Y_currPos.TabIndex = 264;
            this.Y_currPos.Text = "Y";
            // 
            // Z_currPos
            // 
            this.Z_currPos.AutoSize = true;
            this.Z_currPos.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Z_currPos.Location = new System.Drawing.Point(207, 132);
            this.Z_currPos.Name = "Z_currPos";
            this.Z_currPos.Size = new System.Drawing.Size(24, 16);
            this.Z_currPos.TabIndex = 265;
            this.Z_currPos.Text = "Z1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(129, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 40);
            this.button1.TabIndex = 266;
            this.button1.Tag = "8";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(10, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 38);
            this.button2.TabIndex = 267;
            this.button2.Tag = "8";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(346, 235);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 40);
            this.button3.TabIndex = 268;
            this.button3.Tag = "9";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(220, 234);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 38);
            this.button4.TabIndex = 269;
            this.button4.Tag = "9";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(67, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 270;
            this.label1.Text = "皮带1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(284, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 271;
            this.label2.Text = "皮带2";
            this.label2.Visible = false;
            // 
            // C_currPos
            // 
            this.C_currPos.AutoSize = true;
            this.C_currPos.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C_currPos.Location = new System.Drawing.Point(427, 130);
            this.C_currPos.Name = "C_currPos";
            this.C_currPos.Size = new System.Drawing.Size(24, 16);
            this.C_currPos.TabIndex = 274;
            this.C_currPos.Text = "R2";
            // 
            // Bt_R_jogPos
            // 
            this.Bt_R_jogPos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Bt_R_jogPos.BackgroundImage")));
            this.Bt_R_jogPos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_R_jogPos.FlatAppearance.BorderSize = 0;
            this.Bt_R_jogPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_R_jogPos.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_R_jogPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_R_jogPos.Location = new System.Drawing.Point(419, 163);
            this.Bt_R_jogPos.Name = "Bt_R_jogPos";
            this.Bt_R_jogPos.Size = new System.Drawing.Size(40, 58);
            this.Bt_R_jogPos.TabIndex = 273;
            this.Bt_R_jogPos.Tag = "5";
            this.Bt_R_jogPos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Bt_R_jogPos.UseVisualStyleBackColor = true;
            // 
            // Bt_R_jogNeg
            // 
            this.Bt_R_jogNeg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Bt_R_jogNeg.BackgroundImage")));
            this.Bt_R_jogNeg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_R_jogNeg.FlatAppearance.BorderSize = 0;
            this.Bt_R_jogNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_R_jogNeg.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_R_jogNeg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_R_jogNeg.Location = new System.Drawing.Point(419, 57);
            this.Bt_R_jogNeg.Name = "Bt_R_jogNeg";
            this.Bt_R_jogNeg.Size = new System.Drawing.Size(40, 53);
            this.Bt_R_jogNeg.TabIndex = 272;
            this.Bt_R_jogNeg.Tag = "5";
            this.Bt_R_jogNeg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Bt_R_jogNeg.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(284, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 277;
            this.label3.Text = "Z2";
            // 
            // Bt_Z1_jogPos
            // 
            this.Bt_Z1_jogPos.FlatAppearance.BorderSize = 0;
            this.Bt_Z1_jogPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Z1_jogPos.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_Z1_jogPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_Z1_jogPos.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Z1_jogPos.Image")));
            this.Bt_Z1_jogPos.Location = new System.Drawing.Point(276, 165);
            this.Bt_Z1_jogPos.Name = "Bt_Z1_jogPos";
            this.Bt_Z1_jogPos.Size = new System.Drawing.Size(40, 58);
            this.Bt_Z1_jogPos.TabIndex = 276;
            this.Bt_Z1_jogPos.Tag = "3";
            this.Bt_Z1_jogPos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Bt_Z1_jogPos.UseVisualStyleBackColor = true;
            // 
            // Bt_Z1_jogNeg
            // 
            this.Bt_Z1_jogNeg.FlatAppearance.BorderSize = 0;
            this.Bt_Z1_jogNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Z1_jogNeg.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_Z1_jogNeg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_Z1_jogNeg.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Z1_jogNeg.Image")));
            this.Bt_Z1_jogNeg.Location = new System.Drawing.Point(276, 59);
            this.Bt_Z1_jogNeg.Name = "Bt_Z1_jogNeg";
            this.Bt_Z1_jogNeg.Size = new System.Drawing.Size(40, 53);
            this.Bt_Z1_jogNeg.TabIndex = 275;
            this.Bt_Z1_jogNeg.Tag = "3";
            this.Bt_Z1_jogNeg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Bt_Z1_jogNeg.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(504, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 280;
            this.label4.Text = "皮带3";
            this.label4.Visible = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(566, 235);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 40);
            this.button5.TabIndex = 278;
            this.button5.Tag = "10";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(440, 234);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 38);
            this.button6.TabIndex = 279;
            this.button6.Tag = "10";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(355, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 283;
            this.label5.Text = "R1";
            // 
            // Bt_R1_jogPos
            // 
            this.Bt_R1_jogPos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Bt_R1_jogPos.BackgroundImage")));
            this.Bt_R1_jogPos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_R1_jogPos.FlatAppearance.BorderSize = 0;
            this.Bt_R1_jogPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_R1_jogPos.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_R1_jogPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_R1_jogPos.Location = new System.Drawing.Point(347, 166);
            this.Bt_R1_jogPos.Name = "Bt_R1_jogPos";
            this.Bt_R1_jogPos.Size = new System.Drawing.Size(40, 58);
            this.Bt_R1_jogPos.TabIndex = 282;
            this.Bt_R1_jogPos.Tag = "4";
            this.Bt_R1_jogPos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Bt_R1_jogPos.UseVisualStyleBackColor = true;
            // 
            // Bt_R1_jogNeg
            // 
            this.Bt_R1_jogNeg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Bt_R1_jogNeg.BackgroundImage")));
            this.Bt_R1_jogNeg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_R1_jogNeg.FlatAppearance.BorderSize = 0;
            this.Bt_R1_jogNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_R1_jogNeg.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_R1_jogNeg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_R1_jogNeg.Location = new System.Drawing.Point(347, 57);
            this.Bt_R1_jogNeg.Name = "Bt_R1_jogNeg";
            this.Bt_R1_jogNeg.Size = new System.Drawing.Size(40, 53);
            this.Bt_R1_jogNeg.TabIndex = 281;
            this.Bt_R1_jogNeg.Tag = "4";
            this.Bt_R1_jogNeg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Bt_R1_jogNeg.UseVisualStyleBackColor = true;
            // 
            // XYZ_Jog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(676, 295);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Bt_R1_jogPos);
            this.Controls.Add(this.Bt_R1_jogNeg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Bt_Z1_jogPos);
            this.Controls.Add(this.Bt_Z1_jogNeg);
            this.Controls.Add(this.C_currPos);
            this.Controls.Add(this.Bt_R_jogPos);
            this.Controls.Add(this.Bt_R_jogNeg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Z_currPos);
            this.Controls.Add(this.Y_currPos);
            this.Controls.Add(this.X_currPos);
            this.Controls.Add(this.numericUpDown31);
            this.Controls.Add(this.Bt_Y_jogPos);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.Bt_Y_jogNeg);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.Bt_X_jogPos);
            this.Controls.Add(this.label112);
            this.Controls.Add(this.Bt_X_jogNeg);
            this.Controls.Add(this.Bt_home);
            this.Controls.Add(this.Bt_Z_jogPos);
            this.Controls.Add(this.Bt_Z_jogNeg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "XYZ_Jog";
            this.Text = "XYZ_Jog";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown31)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown31;
        private System.Windows.Forms.Button Bt_Y_jogPos;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Button Bt_Y_jogNeg;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button Bt_X_jogPos;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.Button Bt_X_jogNeg;
        private System.Windows.Forms.Button Bt_home;
        private System.Windows.Forms.Button Bt_Z_jogPos;
        private System.Windows.Forms.Button Bt_Z_jogNeg;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label X_currPos;
        private System.Windows.Forms.Label Y_currPos;
        private System.Windows.Forms.Label Z_currPos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label C_currPos;
        private System.Windows.Forms.Button Bt_R_jogPos;
        private System.Windows.Forms.Button Bt_R_jogNeg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Bt_Z1_jogPos;
        private System.Windows.Forms.Button Bt_Z1_jogNeg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Bt_R1_jogPos;
        private System.Windows.Forms.Button Bt_R1_jogNeg;
    }
}
using HzControl.Communal.Controls;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace HZZH.Communal.Control
{
    public partial class MyButton : Button
    {
        public MyButton() : base()
        {
            InitializeComponent();
            base.Font = new System.Drawing.Font("黑体", 24, System.Drawing.FontStyle.Bold);
            base.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            base.AutoSize = false;
            base.Size = new System.Drawing.Size(224, 53);
            base.FlatAppearance.BorderSize = 0;  //设置无边框
            base.BackgroundImage = imageList1.Images["绿按钮.png"];
            base.BackgroundImageLayout = ImageLayout.Stretch;
            base.Visible = false;
            base.Visible = true;
            LongEnable = true;
            DownTime = 3000;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            SelectButton(this);
        }
        private System.Windows.Forms.Timer _MouseDownTimer;
        public void LoadTime()
        {
            if (_MouseDownTimer == null)
            {
                _MouseDownTimer = new System.Windows.Forms.Timer();
                if (DownTime==0)
                {
                    DownTime = 3000;
                }
                _MouseDownTimer.Interval = DownTime;
                _MouseDownTimer.Tick += new EventHandler(OnMouseDownTimer_Tick);
            }
        }
        /// <summary>
        /// 设置按钮、复选框、单选框等控件的无焦点。
        /// </summary>
        /// <param name="button"></param>
        public static void SelectButton(Button button)
        {
            
            MethodInfo methodinfo = button.GetType().GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
            methodinfo.Invoke(button, BindingFlags.NonPublic, null, new object[] { ControlStyles.Selectable, false }, null);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (true)
            {
                LoadTime();
                MouseDown_Enable();
                SelectButton(this);
                if (mevent.Button == MouseButtons.Left)
                {
                    _MouseDownTimer.Start();
                }

            }

        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (true)
            {
                if (mevent.Button == MouseButtons.Left)
                {
                    if (_MouseDownTimer.Enabled) _MouseDownTimer.Stop();
                }

            }


        }

        private System.Windows.Forms.Timer _MouseDownTimer2;
        private void MouseDown_Enable()
        {
            if (_MouseDownTimer2 == null)
            {
                _MouseDownTimer2 = new System.Windows.Forms.Timer();
                _MouseDownTimer2.Interval = 100;
                _MouseDownTimer2.Enabled = true;
                _MouseDownTimer2.Tick += new EventHandler(_MouseDownTimer2_BtnColorChange);
            }
        }

        private void _MouseDownTimer2_BtnColorChange(object sender, EventArgs e)
        {
            if (_MouseDownTimer.Enabled)
            { 
                base.BackgroundImage = imageList1.Images["黄按钮.png"];
            }
            else
            {
                base.BackgroundImage = imageList1.Images["绿按钮.png"];
            }
        }

        public void OnMouseDownTimer_Tick(object sender, EventArgs e)
        {
            _MouseDownTimer.Stop();
            MessageBox.Show("已按下鼠标左键" + DownTime / 1000 + "秒。");
        }

        public MyButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true), Category("自定义属性"), Description("是否开启长按功能"), DefaultValue(true)]
        public bool LongEnable
        {
            get;
            set;
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true), Category("自定义属性"), Description("需按住时间(ms)"), DefaultValue(typeof(Int32), "3000")]
        public int DownTime
        {
            get;
            set;
        }
    }
}

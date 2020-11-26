using HZZH.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.UI2
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

            var va = Product.Inst;

            base.SetStyle(ControlStyles.UserPaint, true);//减少屏幕闪烁
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.UpdateStyles();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FrmMgr.RegisterContainer(this.panel2);
            FrmMgr.Show("RunForm");
            Logic.LogicMain.TaskMain.Init();//任务集合初始化，加入到任务链表
        }

        protected override void WndProc(ref Message m)
        {
            if ((((m.Msg != 0xa1) || (m.WParam.ToInt32() != 2)) && (m.Msg != 0xa3)) && (m.Msg != 20))
            {
                base.WndProc(ref m);
            }
        }
        /// <summary>
        /// 退出软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Product.Inst.Save();

            MessageShowForm2 messageShowForm = new MessageShowForm2();
            messageShowForm.label1.Text = "确认退出软件？";
            if (messageShowForm.ShowDialog(this) == DialogResult.OK)
            {
                this.Close();
            }
        }
        /// <summary>
        /// 窗口最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 清除所有报警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

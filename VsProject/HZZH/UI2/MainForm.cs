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

            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.UpdateStyles();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FrmMgr.RegisterContainer(this.panel2);
            FrmMgr.Show("RunForm");
            Logic.LogicMain.TaskMain.Init();
        }

        protected override void WndProc(ref Message m)
        {
            if ((((m.Msg != 0xa1) || (m.WParam.ToInt32() != 2)) && (m.Msg != 0xa3)) && (m.Msg != 20))
            {
                base.WndProc(ref m);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //protected override System.Windows.Forms.CreateParams CreateParams
        //{
        //    get
        //    {
        //        System.Windows.Forms.CreateParams createParams = base.CreateParams;
        //        createParams.ExStyle |= 0x80000;
        //        return createParams;
        //    }
        //}
    }
}

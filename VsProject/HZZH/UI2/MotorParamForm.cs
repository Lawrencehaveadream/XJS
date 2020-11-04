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
    public partial class MotorParamForm : ParamForm
    {
        public MotorParamForm()
        {
            InitializeComponent();
        }


        private UI.DerivedControl.Frm_MotorParam Frm_Machine;

        private void MotorParamForm_Load(object sender, EventArgs e)
        {
            Frm_Machine = new UI.DerivedControl.Frm_MotorParam();
            Frm_Machine.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            Frm_Machine.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            Frm_Machine.Size = this.panel3.Size;
            Frm_Machine.Parent = this.panel3;//指定子窗体显示的容器
            Frm_Machine.Dock = DockStyle.Fill;
            Frm_Machine.Show();
        }
    }
}

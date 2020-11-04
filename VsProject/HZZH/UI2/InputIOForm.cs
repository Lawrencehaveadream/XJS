using HZZH.Logic.Commmon;
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
    public partial class InputIOForm : BottomForm
    {
        public InputIOForm()
        {
            InitializeComponent();
        }


        private MyControl.InputOutput IOControl;
        private void InputIOForm_Load(object sender, EventArgs e)
        {
            IOControl = new MyControl.InputOutput(DeviceRsDef.MotionCard, "INPUTDEFINE.csv", "OUTPUTDEFINE.csv");
            IOControl.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            IOControl.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            IOControl.Size = panel2.Size;
            IOControl.Parent = panel2;//指定子窗体显示的容器
            IOControl.Dock = DockStyle.Fill;
            IOControl.Show();

        }
    }
}

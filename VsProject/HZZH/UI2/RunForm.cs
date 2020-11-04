using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Logic.Commmon;
using HZZH.Logic.LogicMain;

namespace HZZH.UI2
{
    public partial class RunForm : BaseSubForm
    {
        public RunForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Tag != null)
            {
                FrmMgr.Show(((Button)sender).Tag.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text = TaskManager.Default.FSM.Status.ID.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MachineAlarm.SetAlarm(AlarmLevelEnum.Level1, "启动报警");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MachineAlarm.SetAlarm(AlarmLevelEnum.Level2, "停止报警");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MachineAlarm.ClearAlarm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TaskManager.Show();
        }

        string filePath = Application.StartupPath + "\\程式";

        private void button6_Click(object sender, EventArgs e)
        {
            TaskManager.Default.SaveLogicPara(filePath);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TaskManager.Default.LoadLogicPara(filePath);
        }
    }
}

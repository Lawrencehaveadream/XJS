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
using HZZH.UI2;

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
            label17.Text = testClass.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MachineAlarm.SetAlarm(AlarmLevelEnum.Level1, "启动报警");

            TestClass.SetBinding(label7, "Text", testClass, "Value");
            label7.DataBindings[0].BindingComplete += RunForm_BindingComplete;
            label7.DataBindings[0].Format += RunForm_Format;
            label7.DataBindings[0].Parse += RunForm_Parse;
        }

        private void RunForm_Parse(object sender, ConvertEventArgs e)
        {
            Console.WriteLine(3);
        }

        private void RunForm_Format(object sender, ConvertEventArgs e)
        {
            Console.WriteLine(2);
        }

        private void RunForm_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            Console.WriteLine(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MachineAlarm.SetAlarm(AlarmLevelEnum.Level2, "停止报警");

            label7.Text = new Random().Next().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MachineAlarm.ClearAlarm();
            testClass.Value = new Random().Next().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TaskManager.Show();
        }

        string filePath = Application.StartupPath + "\\程式";

        private void button6_Click(object sender, EventArgs e)
        {
            TaskManager.Default.SaveLogicPara(filePath);
            label7.DataBindings[0].ReadValue();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TaskManager.Default.LoadLogicPara(filePath);
        }

        TestClass testClass = new TestClass();
    }


    public class TestClass
    {
        public string Value { get; set; } = "213";

        public static void SetBinding(Control ctrl, string propertyName, object obj, string name)
        {
            if (ctrl.DataBindings[propertyName] != null) ctrl.DataBindings.Remove(ctrl.DataBindings[propertyName]);
            ctrl.DataBindings.Add(propertyName, obj, name, true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);



        }
    }
}

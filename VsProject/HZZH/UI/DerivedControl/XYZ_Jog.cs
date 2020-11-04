using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HZZH.Logic.Commmon;

namespace HZZH.UI.DerivedControl
{
    public partial class XYZ_Jog : Form
    {
        private Device.MotionCardDef MotionCard;
        public int[] axisID;
        public XYZ_Jog()
        {
            InitializeComponent();
            ContorlBling();
            comboBox4.SelectedIndex = 0;
            this.MotionCard = DeviceRsDef.MotionCard;
            axisID = new int[16];
            //axisID[0] = DeviceRsDef.Axis_X.Index;
            //axisID[1] = DeviceRsDef.Axis_Y.Index;
            //axisID[2] = DeviceRsDef.Axis_Z1.Index;
            //axisID[3] = DeviceRsDef.Axis_Z2.Index;
            //axisID[4] = DeviceRsDef.Axis_R1.Index;
            //axisID[5] = DeviceRsDef.Axis_R2.Index;
            //axisID[6] = DeviceRsDef.Axis_UpAdjust.Index;
            //axisID[7] = DeviceRsDef.Axis_DownAdjust.Index;
            //axisID[8] = DeviceRsDef.Axis_BeltPreFeed.Index;
            //axisID[9] = DeviceRsDef.Axis_BeltFeed.Index;
            //axisID[10] = DeviceRsDef.Axis_BeltUnfeed.Index; 
            // axisID[11] = DeviceRsDef.Axis_BeltDown.Index;
        }

        public void Init(Device.MotionCardDef MotionCard, int xAxisID, int yAxisID, int zAxisID, int M1AxisID, int M2AxisID, int CAxisID)
        {
            this.MotionCard = MotionCard;
            
            axisID = new int[6];
            axisID[0] = xAxisID;
            axisID[1] = yAxisID;
            axisID[2] = zAxisID;
            axisID[3] = M1AxisID;
            axisID[4] = M2AxisID;
            axisID[5] = CAxisID;

            if(xAxisID == 0)
            {
                ConfigJog(Direction.Pos, Bt_X_jogPos);
                ConfigJog(Direction.Neg, Bt_X_jogNeg);
            }
            else
            {
                ConfigJog(Direction.Neg, Bt_X_jogPos);
                ConfigJog(Direction.Pos, Bt_X_jogNeg);
            }
        }
        public void ContorlBling()
        {
            this.MotionCard = DeviceRsDef.MotionCard;

            ConfigJog(Direction.Pos, Bt_X_jogPos);
            ConfigJog(Direction.Neg, Bt_X_jogNeg);

            ConfigJog(Direction.Neg, Bt_Y_jogNeg);
            ConfigJog(Direction.Pos, Bt_Y_jogPos);

            ConfigJog(Direction.Pos, Bt_Z_jogPos);
            ConfigJog(Direction.Neg, Bt_Z_jogNeg);


            ConfigJog(Direction.Pos, Bt_Z1_jogPos);
            ConfigJog(Direction.Neg, Bt_Z1_jogNeg);

            ConfigJog(Direction.Pos, Bt_R_jogPos);
            ConfigJog(Direction.Neg, Bt_R_jogNeg);

            ConfigJog(Direction.Pos, Bt_R1_jogPos);
            ConfigJog(Direction.Neg, Bt_R1_jogNeg);

            ConfigJog(Direction.Pos, button1);
            ConfigJog(Direction.Neg, button2);

            ConfigJog(Direction.Pos, button3);
            ConfigJog(Direction.Neg, button4);
            
            ConfigJog(Direction.Pos, button5);
            ConfigJog(Direction.Neg, button6);

            ConfigJog(Direction.Hom, Bt_home);
        }

        private void numericUpDown31_ValueChanged(object sender, EventArgs e)
        {
            _targetPos = (float)numericUpDown31.Value;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                _mode = 1;
            }
            else
            {
                _mode = 0;
            }
        }


        #region 按键事件
        
        /// <summary>
        /// 移动距离
        /// </summary>
        public float _targetPos = 1;
        /// <summary>
        /// 移动速度
        /// </summary>
        public float _speed = 5;

        public int _mode = 1;

        private void ConfigJog(Direction type, Button _b)
        {
            _b.MouseDown -= btn_JogAxisNeg_MouseDown;
            _b.MouseDown -= btn_JogAxisPos_MouseDown;
            _b.MouseUp -= btn_JogAxis_MouseUp;
            _b.Click -= btn_Home_Click;

            switch (type)
            {
                case Direction.Pos:
                    _b.MouseDown += btn_JogAxisPos_MouseDown;
                    _b.MouseUp += btn_JogAxis_MouseUp;
                    break;
                case Direction.Neg:
                    _b.MouseDown += btn_JogAxisNeg_MouseDown;
                    _b.MouseUp += btn_JogAxis_MouseUp;
                    break;
                case Direction.Hom:
                    _b.Click += btn_Home_Click;
                    break;
            }
        }

        private void btn_JogAxisPos_MouseDown(object sender, MouseEventArgs e)
        {
            Button _btn = sender as Button;
            ushort axis = Convert.ToUInt16(_btn.Tag);
            if (e.Button == MouseButtons.Left)
            {
                _speed = 50;
                    JogAxisPos((ushort)axisID[axis], _mode, _speed, _targetPos);

            }
            if (e.Button == MouseButtons.Right)
            {
                _speed = 10;
                    JogAxisPos((ushort)axisID[axis], _mode, _speed, _targetPos);
            }
        }

        private void btn_JogAxis_MouseUp(object sender, MouseEventArgs e)
        {
            Button _btn = sender as Button;
            ushort axis = Convert.ToUInt16(_btn.Tag);
                JogAxisStop((ushort)axisID[axis], _mode);
        }

        private void btn_JogAxisNeg_MouseDown(object sender, MouseEventArgs e)
        {
            Button _btn = sender as Button;
            ushort axis = Convert.ToUInt16(_btn.Tag);
            if (e.Button == MouseButtons.Left)
            {
                _speed = 50;
                    JogAxisNeg((ushort)axisID[axis], _mode, _speed, _targetPos);
            }
            if (e.Button == MouseButtons.Right)
            {
                _speed = 10;
                    JogAxisNeg((ushort)axisID[axis], _mode, _speed, _targetPos);
            }
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            Button _btn = sender as Button;
            ushort axis = (ushort)comboBox4.SelectedIndex;
            float speed = 100;
                AxisHomeAction((ushort)axisID[axis], speed, comboBox4.Text);
        }

        public void JogAxisNeg(ushort axisNum, int mode, float jogSpeed, float targetPos)
        {
            //判断是走连续，还是走固定步长
            if (mode == 0)
            {
                MotionCard.MotionFun.MC_MoveSpd(axisNum, jogSpeed, -targetPos);
            }

            else
            {
                MotionCard.MotionFun.MC_MoveRel(axisNum, jogSpeed, -targetPos);
            }
        }

        public void JogAxisPos(ushort axisNum, int mode, float jogSpeed, float targetPos)
        {
            //判断是走连续，还是走固定步长
            if (mode == 0)
            {
                MotionCard.MotionFun.MC_MoveSpd(axisNum, jogSpeed, targetPos);
            }

            else
            {
                MotionCard.MotionFun.MC_MoveRel(axisNum, jogSpeed, targetPos);
            }
            //MotionCard.MotionFun.MC_PowerOn
        }

        public void JogAxisStop(ushort axisNum, int mode)
        {
            if (mode == 0)
            {
                MotionCard.MotionFun.MC_StopDec(axisNum);
            }
        }

        public void AxisHomeAction(ushort axisNum, float jogSpeed, string Axis_Name)
        {
            if (MessageBox.Show("确定要执行此轴回零...", Axis_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MotionCard.MotionFun.MC_Home(axisNum);
            }
        }


        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(MotionCard!=null)
            {
                if (MotionCard.netSucceed)
                {
                    X_currPos.Text = "X:" + MotionCard.MotionFun.MC_GetCurrPos(axisID[0]).ToString("0.00");
                    Y_currPos.Text = "Y:" + MotionCard.MotionFun.MC_GetCurrPos(axisID[1]).ToString("0.00");
                    Z_currPos.Text = "Z:" + MotionCard.MotionFun.MC_GetCurrPos(axisID[2]).ToString("0.00");                  
                    label1.Text = "M1:" + MotionCard.MotionFun.MC_GetCurrPos(axisID[3]).ToString("0.00");
                    label2.Text = "M2:" + MotionCard.MotionFun.MC_GetCurrPos(axisID[4]).ToString("0.00");
                    C_currPos.Text = "C:" + MotionCard.MotionFun.MC_GetCurrPos(axisID[5]).ToString("0.00");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }

    public enum Direction : int
    {
        Pos,
        Neg,
        Hom
    }

    public class ComboBoxIndex
    {
        public int index { get; set; }
        public string name { get; set; }
    }

}

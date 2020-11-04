using CommonRs;
using HzControl.Logic;
using HZZH.Logic.Commmon;
using HZZH.Logic.LogicMain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.Logic.SubLogicPrg
{
	public class TrayUnloadDef : LogicTask
	{
		public float Pos_TrayX { get; set; }//载台X位置
		public float Pos_TakeY { get; set; }//取位置Y
		public float Pos_TakeZ { get; set; }//取位置Z
		public float Pos_PutY { get; set; }//放位置Y
		public float Pos_PutZ { get; set; }//放位置Z
		Stopwatch Tm = new Stopwatch();
		public bool OK = false;
		public TrayUnloadDef() : base("Tray盘下料")
		{
		}
		protected override void LogicImpl()
		{
			switch (LG.Step)
			{
				case 1:
					if (TaskMain.StackUnload.GetSta() == 0)//等上次的堆叠定位结束
					{
						if (!TaskMain.StackUnload.Finish)//堆叠还没用完
						{
							DeviceRsDef.Q_TakeClamp.OFF();//上料夹爪张开
							Tm.Restart();//开始计时
							LG.StepNext(2);
						}
						else//堆叠用完
						{
							DeviceRsDef.Ax_TakeZ.MC_MoveAbs(TaskMain.TrayJump.Pos_SafeZ);//取料Z到安全位
							LG.StepNext(0xE0);//到异常结束
						}
					}
					break;

				case 2:
					if (Tm.ElapsedMilliseconds < 1000)//1000ms内检测信号OK
					{
						if (DeviceRsDef.I_TakeClampOFF1.value && //1号夹爪张开到位
							DeviceRsDef.I_TakeClampOFF2.value && //2号夹爪召开到位
							(TaskMain.LogicMain.GroupEn[0] && DeviceRsDef.I_PutInp1.value) &&//1号载台正常
							(TaskMain.LogicMain.GroupEn[1] && DeviceRsDef.I_PutInp2.value))//2号载台正常
						{
							TaskMain.TrayJump.Start(Pos_TrayX, Pos_TakeY, Pos_TakeZ);//取料平台到取料位
							LG.StepNext(3);
						}
					}
					else//1000ms后信号还是不正常
					{
						//载台信号异常
						if ((TaskMain.LogicMain.GroupEn[0] && !DeviceRsDef.I_PutInp1.value) ||
							(TaskMain.LogicMain.GroupEn[1] && !DeviceRsDef.I_PutInp2.value))
						{
							if (MessageBox.Show("载台Tray盘信号丢失\n\r\n\r确定：请人工调整载台Tray盘，继续下料\n\r\n\r取消：人工取走载台Tray盘，结束下料", "警告", MessageBoxButtons.OK) == DialogResult.OK)
							{ 
								//切换到停止状态
								LG.StepNext(1);
							}
						}
						else if(!DeviceRsDef.I_TakeClampOFF1.value ||//1号爪张开未到位
							!DeviceRsDef.I_TakeClampOFF2.value)//2号爪张开未到位
						{
							MessageBox.Show("检测到取Tray盘夹爪张开未到位", "警告");
							LG.End();
						}
					}
					break;

				case 3:
					if (TaskMain.TrayJump.GetSta() == 0)//等待取料平台跳跃完成
					{
						DeviceRsDef.Q_TakeClamp.ON();
						DeviceRsDef.Q_TrayAdjustX.OFF();
						DeviceRsDef.Q_TrayAdjustY.OFF();
						Tm.Restart();//开始计时
						LG.StepNext(4);
					}
					break;

				case 4:
					if (Tm.ElapsedMilliseconds >= 200)//夹紧延时后
					{
						TaskMain.TrayJump.Start(Pos_TrayX, Pos_PutY, Pos_PutZ);//跳到放料位
						LG.StepNext(5);
					}
					break;

				case 5:
					if (TaskMain.TrayJump.GetSta() == 0)//等待跳跃完成
					{
						DeviceRsDef.Q_TakeClamp.OFF();
						Tm.Restart();
						LG.StepNext(6);
					}
					break;

				case 6:
					if (Tm.ElapsedMilliseconds < 1000)
					{
						if (DeviceRsDef.I_TakeClampOFF1.value && //1号夹爪张开到位
							DeviceRsDef.I_TakeClampOFF2.value && //2号夹爪召开到位
							(TaskMain.LogicMain.GroupEn[0] && DeviceRsDef.I_TakeInp1.value) &&//1号Tray盘下料正常
							(TaskMain.LogicMain.GroupEn[1] && DeviceRsDef.I_TakeInp2.value))//2号Tray盘下料正常
						{
							DeviceRsDef.Ax_TakeZ.MC_MoveAbs(TaskMain.TrayJump.Pos_SafeZ);//Z到安全高度
							LG.StepNext(7);
						}
					}
					else
					{
						DeviceRsDef.Ax_TakeZ.MC_MoveAbs(TaskMain.TrayJump.Pos_SafeZ);//Z到安全
						MessageBox.Show("抓取信号丢失，Tray盘掉落");
						LG.StepNext(7);
					}
					break;

				case 7:
					if (!DeviceRsDef.Ax_TakeZ.busy)//等待Z上到位
					{
						OK = true;
						LG.End();
					}
					break;
			}
		}
	}
}

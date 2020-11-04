using CommonRs;
using Device;
using HzControl.Logic;
using HZZH.Common.Tools;
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
	public class TrayLoadDef:LogicTask
	{
		public float Pos_TrayX { get; set; }//载台X位置
		public float Pos_TakeY { get; set; }//取位置Y
		public float Pos_TakeZ { get; set; }//取位置Z
		public float Pos_PutY { get; set; }//放位置Y
		public float Pos_PutZ { get; set; }//放位置Z
		Stopwatch Tm = new Stopwatch();
		public bool OK = false;

		public TrayLoadDef() : base("Tray盘上料")
		{
		}
		protected override void LogicImpl()
		{
			switch (LG.Step)
			{
				case 1:
					if(TaskMain.StackLoad.GetSta() == 0)//等上次的堆叠定位结束
					{
						if (!TaskMain.StackLoad.Finish)//堆叠还没用完
						{
							DeviceRsDef.Q_TakeClamp.OFF();//上料夹爪张开
							DeviceRsDef.Q_TrayAdjustX.OFF();//矫正X张开
							DeviceRsDef.Q_TrayAdjustY.OFF();//矫正Y张开
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
							!DeviceRsDef.I_PutInp1.value &&//1号载台没有障碍物
							!DeviceRsDef.I_PutInp2.value)//2号载台没有障碍物
						{
							TaskMain.TrayJump.Start(Pos_TrayX,Pos_TakeY,Pos_TakeZ);//取料平台到取料位
							LG.StepNext(3);
						}
					}
					else//1000ms后信号还是不正常
					{
						if (!DeviceRsDef.I_TakeClampOFF1.value ||//1号爪张开未到位
							!DeviceRsDef.I_TakeClampOFF2.value)//2号爪张开未到位
						{
							MessageBox.Show("检测到取Tray盘夹爪张开未到位","警告");
						}
						if (DeviceRsDef.I_PutInp1.value ||//1号平台有障碍物
							DeviceRsDef.I_PutInp2.value)//2号平台有障碍物
						{
							MessageBox.Show("检测到载台已有Tray盘，请人工取走","警告");
						}
						//切换到停止状态
						LG.StepNext(0xE0);//到异常结束
					}
					break;

				case 3:
					if (TaskMain.TrayJump.GetSta() == 0)//等待取料平台跳跃完成
					{
						Tm.Restart();//开始计时
						LG.StepNext(4);
					}
					break;

				case 4:
					if (Tm.ElapsedMilliseconds < 200)//延时内信号正常
					{
						if (((TaskMain.LogicMain.GroupEn[0] && DeviceRsDef.I_TakeInp1.value) || (!TaskMain.LogicMain.GroupEn[0] && !DeviceRsDef.I_TakeInp1.value)) && //1号堆叠信号正常
							((TaskMain.LogicMain.GroupEn[1] && DeviceRsDef.I_TakeInp2.value) || (!TaskMain.LogicMain.GroupEn[1] && !DeviceRsDef.I_TakeInp2.value)))//2号堆叠信号正常
						{
							DeviceRsDef.Q_TakeClamp.ON();//夹爪夹紧
							Tm.Restart();//开始计时
							LG.StepNext(5);
						}
					}
					else//延时后信号异常
					{
						if ((!TaskMain.LogicMain.GroupEn[0] && DeviceRsDef.I_TakeInp1.value) || //1号没启用，但是有信号
							(!TaskMain.LogicMain.GroupEn[1] && DeviceRsDef.I_TakeInp2.value) || //2号没启用，但是有信号
							(TaskMain.LogicMain.GroupEn[0] && TaskMain.LogicMain.GroupEn[1] && (DeviceRsDef.I_TakeInp1.value ^ DeviceRsDef.I_TakeInp2.value)))//1、2都启用了，但是只有一边有信号
						{
							DeviceRsDef.Ax_TakeZ.MC_MoveAbs(TaskMain.TrayJump.Pos_SafeZ);//取料Z到安全位
							MessageBox.Show("检测到Tray盘上料堆叠异常，请确保上料堆叠正常");
							LG.StepNext(0xE0);//跳到异常结束
						}
						else
						{
							TaskMain.StackLoad.GoNext();//堆叠到下一层
							LG.StepNext(1);//重新开始流程
						}
					}
					break;

				case 5:
					if (Tm.ElapsedMilliseconds >= 200)//夹紧延时后
					{
						TaskMain.TrayJump.Start(Pos_TrayX,Pos_PutY,Pos_PutZ);//跳到放料位
						LG.StepNext(6);
					}
					break;

				case 6:
					if (TaskMain.TrayJump.GetSta() == 0)//等待跳跃完成
					{
						DeviceRsDef.Q_TakeClamp.OFF();//张开夹爪
						DeviceRsDef.Q_TrayAdjustX.ON();//矫正X夹紧
						DeviceRsDef.Q_TrayAdjustY.ON();//矫正Y夹紧
						Tm.Restart();//开始计时
						LG.StepNext(7);
					}
					break;

				case 7:
					if (Tm.ElapsedMilliseconds < 1000)//1s内检测夹爪张开信号
					{
						if (DeviceRsDef.I_TakeClampOFF1.value && DeviceRsDef.I_TakeClampOFF2.value)//夹爪张开信号正常
						{
							DeviceRsDef.Ax_TakeZ.MC_MoveAbs(TaskMain.TrayJump.Pos_SafeZ);//取料Z上到安全位
							LG.StepNext(8);
						}
					}
					else//1s后信号还是不正常
					{
						if (!DeviceRsDef.I_TakeClampOFF1.value)//1号夹爪张开未到位
						{
							MessageBox.Show("1号上料夹爪张开未到位，请检查气缸张开传感器", "警告");
						}
						if (!DeviceRsDef.I_TakeClampOFF2.value)//2号夹爪张开未到位
						{
							MessageBox.Show("2号上料夹爪张开未到位，请检查气缸张开传感器", "警告");
						}
						Tm.Restart();//重新计时
						//切换到停止状态
					}
					break;

				case 8:
					if (!DeviceRsDef.Ax_TakeZ.busy)//取料Z上到位
					{
						Tm.Restart();//开始计时
						LG.StepNext(9);
					}
					break;

				case 9:
					if(Tm.ElapsedMilliseconds < 100)//100ms内检测载台Tray盘信号
					{
						if ((DeviceRsDef.I_PutInp1.value || !TaskMain.LogicMain.GroupEn[0]) &&//1号载台Tray盘信号正常
							(DeviceRsDef.I_PutInp2.value || !TaskMain.LogicMain.GroupEn[1]))//2号载台Tray盘信号正常
						{
							OK = true;//标志流程完成
							LG.End();
						}
					}
					else//100ms后信号还是不正常
					{
						if (MessageBox.Show("检测到载台Tray盘异常，点击后将继续运行\n\r\n\r是：人工调整或补齐载台Tray盘\n\r\n\r否：取走载台Tray盘，重新上料", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							Tm.Restart();//人工选是后重新计时判断信号
						}
						else
						{
							LG.StepNext(1);//人工选否后重新取Tray盘
						}
					}
					break;

				case 0xe0:
					if (!DeviceRsDef.Ax_TakeZ.busy)
					{
						//切换状态到停止
						OK = false;//标志流程未完成
						LG.End();
					}
					break;
			}
		}
	}
}

using CommonRs;
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

namespace HZZH.Logic.SubLogicPrg
{
	public class PickPutDef : LogicTask
	{
		public float Spd_Slow { get; set; }//慢速速度
		public float Pos_Slow { get; set; }//慢速位置
		public float Pos_Ahead { get; set; }//提前位置
		public int Tim_Put { get; set; }//放晶时间
		public bool VisionSot = false;//视觉触发
		public bool VisionRet = false;//视觉结果
		public bool PutOk;//放晶结果
		public bool TakeDiscard;//标志需要Take执行弃料
		FPointXYZR Pos_Put = new FPointXYZR();//放晶位置
		FPointXY Pos_Check = new FPointXY();//视觉检测位置
		Stopwatch Tm = new Stopwatch();
		LogicTrigger Tr = new LogicTrigger();
		public PickPutDef() : base("拾取固晶") { }
		/// <summary>
		/// 带参数的启动
		/// </summary>
		/// <param name="PosPut">放晶位置</param>
		public void Start(FPointXYZR PosPut,FPointXY PosCheck)
		{
			if (LG.Execute == false && LG.Step == 0)
			{
				this.Pos_Put = PosPut;
				this.Pos_Check = PosCheck;
				Start();
			}
		}
		protected override void LogicImpl()
		{
			//放晶时循环处理提前控制真空和吹气
			if (LG.Execute == true)
			{
				if (Tr.TrigOne(System.Math.Abs(DeviceRsDef.Ax_PickZ.currPos - Pos_Put.Z) <= Pos_Ahead, 0))//当Z位置进入到提前范围内时，执行一次
				{
					DeviceRsDef.Q_PickVacuo.OFF();//关真空
					DeviceRsDef.Q_PickBlow.ON();//开吹气
				}
			}
			switch (LG.Step)
			{
				case 1:
					if (!DeviceRsDef.Q_PickVacuo.Value || !DeviceRsDef.I_PickVacuo.value)//如果没取好片
					{
						TaskMain.PickTake.Start();//执行取片
					}
					LG.StepNext(2);
					break;

				case 2:
					if (DeviceRsDef.Q_PickVacuo.Value && DeviceRsDef.I_PickVacuo.value)//如果取好片了
					{
						FPointXYZR p = Pos_Put.Clone();//取放晶点位置
						p.Z = Pos_Put.Z - Pos_Slow;//Z修改为慢速点
						TaskMain.PickJump.Start(p, true, TaskMain.PickJump.Pos_PreInpZ);//跳跃到放晶点的慢速高度，检测真空，Z带提前量
						LG.StepNext(3);
					}
					else//如果没取好片
					{
						LG.End();//结束流程
					}
					break;

				case 3:
					if (TaskMain.PickJump.GetSta() == 0)//跳跃结束
					{
						if (TaskMain.PickJump.VacuoResult)//真空检测OK
						{
							DeviceRsDef.Ax_PickZ.MC_MoveAbs(Spd_Slow, Pos_Put.Z);//Z慢速到放晶位
							LG.StepNext(4);
						}
						else//真空异常
						{
							//要报警
							PutOk = false;//标志放晶失败
							LG.End();
						}
					}
					break;

				case 4:
					if (!DeviceRsDef.Ax_PickZ.busy)//等待Z到位
					{
						//DeviceRsDef.Q_PickVacuo.OFF();//由提前量控制吹气和真空
						//DeviceRsDef.Q_PickBlow.ON();
						Tm.Restart();//到位开始计时
						LG.StepNext(5);
					}
					break;

				case 5:
					if (Tm.ElapsedMilliseconds >= Tim_Put)//放晶时间到
					{
						DeviceRsDef.Q_PickBlow.OFF();//关闭吹气
						TaskMain.PickTake.Start();//取晶
						TaskMain.TrayDesk.Start(Pos_Check);//相机移动到该点
						LG.StepNext(6);
					}
					break;

				case 6:
					if (TaskMain.TrayDesk.GetSta() == 0 && DeviceRsDef.Ax_PickY.currPos < TaskMain.PickJump.Ready.Y+1)
					{
						VisionSot = true;//触发视觉
						LG.StepNext(7);
					}
					break;

				case 7:
					if (!VisionSot)//等待视觉结束
					{
						PutOk = VisionRet;//标志放晶结果
						LG.End();
					}
					break;
			}
		}
	}
}

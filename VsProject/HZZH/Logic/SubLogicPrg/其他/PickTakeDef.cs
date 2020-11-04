using CCWin.Win32.Const;
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

namespace HZZH.Logic.SubLogicPrg
{
	public class PickTakeDef : LogicTask
	{
		public FPointXYZR Pos_Take { get; set; }//取晶位置
		public float Pos_NeedleUp { get; set; }//顶针上位置
		public float Pos_NeedleDown { get; set; }//顶针下位置
		public float Pos_ReturnZ { get; set; }//取晶Z回退位置
		public float Spd_ReturnZ { get; set; }//取晶Z回退速度
		public int Tim_Take { get; set; }//取晶时间
		Stopwatch Tm = new Stopwatch();
		public PickTakeDef() : base("拾取取晶") 
		{
			Pos_Take = new FPointXYZR();
		}
		protected override void LogicImpl()
		{
			switch (LG.Step)
			{
				case 1:
					if (!TaskMain.WaferSeek.Ok)
					{
						TaskMain.WaferSeek.Start();
					}
					else
					{
						TaskMain.PickJump.Start(TaskMain.PickJump.Ready);
					}
					LG.StepNext(2);
					break;

				case 2:
					if (TaskMain.WaferSeek.GetSta() == 0)
					{
						if (TaskMain.WaferSeek.Ok)
						{
							LG.StepNext(3);
						}
						else
						{
							LG.End();
						}
					}
					break;

				case 3:
					if (TaskMain.PickJump.GetSta() == 0)
					{
						TaskMain.PickJump.Start(Pos_Take);
						LG.StepNext(4);
					}
					break;

				case 4:
					if (DeviceRsDef.Ax_PickY.currPos <= TaskMain.PickJump.Ready.Y)
					{
						DeviceRsDef.Q_PickBlow.OFF();
						DeviceRsDef.Q_PickVacuo.ON();
						LG.StepNext(5);
					}
					break;

				case 5:
					if (TaskMain.PickJump.GetSta() == 0)
					{
						DeviceRsDef.Q_NeedleVacuo.ON();
						DeviceRsDef.Ax_Needle.MC_MoveAbs(Pos_NeedleUp);
						DeviceRsDef.Ax_PickZ.MC_MoveAbs(Spd_ReturnZ, Pos_Take.Z - Pos_ReturnZ);
						LG.StepNext(6);
					}
					break;

				case 6:
					if (!DeviceRsDef.Ax_Needle.busy && !DeviceRsDef.Ax_PickZ.busy)
					{
						Tm.Restart();
						LG.StepNext(7);
					}
					break;

				case 7:
					if (Tm.ElapsedMilliseconds >= TaskMain.PickTake.Tim_Take)
					{
						DeviceRsDef.Ax_Needle.MC_MoveAbs(Pos_NeedleDown);
						DeviceRsDef.Ax_PickZ.MC_MoveAbs(TaskMain.PickJump.Ready.Z);
					}
					break;
			}
		}
	}

}

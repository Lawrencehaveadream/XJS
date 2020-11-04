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
	public class PickDiscardDef : LogicTask
	{
		public FPointXYZR Pos_Discard { get; set; }//弃料位置
		Stopwatch Tm = new Stopwatch();
		public PickDiscardDef() : base("拾取弃料") 
		{
			Pos_Discard = new FPointXYZR();
		}
		protected override void LogicImpl()
		{
			switch (LG.Step)
			{
				case 1:
					TaskMain.PickJump.Start(Pos_Discard);//跳跃到弃料位置
					LG.StepNext(2);
					break;

				case 2:
					if (TaskMain.PickJump.GetSta() == 0)//等待定位结束
					{
						DeviceRsDef.Q_PickVacuo.OFF();//关真空
						DeviceRsDef.Q_PickBlow.ON();//开吹气
						Tm.Restart();//定时器复位
						LG.StepNext(3);
					}
					break;

				case 3:
					if (Tm.ElapsedMilliseconds > 100)//固定弃料吹气100ms
					{
						DeviceRsDef.Q_PickBlow.OFF();//关吹气
						LG.End();
					}
					break;
			}
		}
	}
}

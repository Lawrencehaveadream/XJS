using CommonRs;
using HzControl.Logic;
using HZZH.Logic.Commmon;
using HZZH.Logic.LogicMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.SubLogicPrg
{
	public class TrayJumpDef : LogicTask
	{
		public float Pos_SafeZ { get; set; }//安全高度
		float x;
		float y;
		float z;
		public TrayJumpDef() : base("上料XYZ跳跃")
		{ 
			
		}
		/// <summary>
		/// 上料XYZ跳跃
		/// </summary>
		/// <param name="Pos_Tar">目标位</param>
		public void Start(float x, float y, float z)
		{
			if (LG.Execute == false && LG.Step == 0)
			{
				this.x = x;
				this.y = y;
				this.z = z;
				LG.Start();
			}
		}
		protected override void LogicImpl()
		{
			switch (LG.Step)
			{
				case 1:
					DeviceRsDef.Ax_TakeZ.MC_MoveAbs(Pos_SafeZ);//Z到安全高度
					DeviceRsDef.Ax_PickZ.MC_MoveAbs(TaskMain.PickJump.Ready.Z);//拾取Z到安全高度
					LG.StepNext(2);
					break;

				case 2:
					if (!DeviceRsDef.Ax_TakeZ.busy && !DeviceRsDef.Ax_PickZ.busy)//等待Z到位
					{
						DeviceRsDef.Ax_TrayX.MC_MoveAbs(x);//X到目标位置
						DeviceRsDef.Ax_TakeY.MC_MoveAbs(y);//Y到目标位置
						LG.StepNext(3);
					}
					break;

				case 3:
					if (!DeviceRsDef.Ax_TrayX.busy && !DeviceRsDef.Ax_TakeY.busy)//等待XY到位
					{
						DeviceRsDef.Ax_TakeZ.MC_MoveAbs(z);//Z到目标高度
						LG.StepNext(4);
					}
					break;

				case 4:
					if (!DeviceRsDef.Ax_TakeZ.busy)//等待Z到位
					{
						LG.End();
					}
					break;


			}
		}
	}
}

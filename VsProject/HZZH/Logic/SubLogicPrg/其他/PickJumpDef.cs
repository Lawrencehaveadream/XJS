using CCWin.SkinClass;
using CommonRs;
using HzControl.Logic;
using HZZH.Logic.Commmon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.SubLogicPrg
{
	public class PickJumpDef : LogicTask
	{
		public FPointXYZR Ready { get; set; }//预备位
		public float Pos_PreInpY { get; set; }//Y提前量
		public float Pos_PreInpZ { get; set; }//Z提前量
		FPointXYZR PosTar = new FPointXYZR();//内部用的跳跃目标位置
		bool CheckVacuo = false;//跳跃到目标位置上方时，检测真空
		float PreInpY;//Y轴提前量
		float PreInpZ;//Z轴提前量
		public bool VacuoResult;//真空检测结果
		
		public PickJumpDef() :base("拾取跳跃")
		{
			Ready = new FPointXYZR();
		}
		/// <summary>
		/// 带参数的启动
		/// </summary>
		/// <param name="p">跳跃目标位置</param>
		/// <param name="CheckVacuo">在跳跃到目标位置上方时，检测真空</param>
		/// <param name="PreInpZ">Z轴提前量，平滑处理</param>
		/// <param name="PreInpY">Y轴提前量，平滑处理</param>
		public void Start(FPointXYZR p, bool CheckVacuo = false, float PreInpZ = 0, float PreInpY = 0)
		{
			if (LG.Execute == false && LG.Step == 0)
			{
				this.CheckVacuo = CheckVacuo;
				this.PreInpY = PreInpY;
				this.PreInpZ = PreInpZ;
				this.PosTar = p;
				Start();
			}
		}
		protected override void LogicImpl()
		{
			switch (LG.Step)
			{
				case 1:
					DeviceRsDef.Ax_PickZ.MC_MoveAbs(Ready.Z);//Z到安全高度
					LG.StepNext(2);
					break;

				case 2:
					if (!DeviceRsDef.Ax_PickZ.busy || System.Math.Abs(Ready.Z - DeviceRsDef.Ax_PickZ.currPos) <= PreInpZ)//Z定位结束或到达提前点
					{
						DeviceRsDef.Ax_PickX.MC_MoveAbs(PosTar.X);//定位到目标X
						DeviceRsDef.Ax_PickY.MC_MoveAbs(PosTar.Y);//定位到目标Y
						DeviceRsDef.Ax_PickR.MC_MoveAbs(PosTar.R);//定位到目标R
						LG.StepNext(3);
					}
					break;

				case 3:
					if (!DeviceRsDef.Ax_PickX.busy &&
						(!DeviceRsDef.Ax_PickY.busy || System.Math.Abs(PosTar.Y - DeviceRsDef.Ax_PickY.currPos) < PreInpY) &&//Y轴结束或到达提前点
						!DeviceRsDef.Ax_PickR.busy)//XYZ定位结束
					{
						VacuoResult = (!CheckVacuo || DeviceRsDef.I_PickVacuo.value);
						if (VacuoResult)
						{
							DeviceRsDef.Ax_PickZ.MC_MoveAbs(PosTar.Z);//Z到目标位置
							LG.StepNext(4);
						}
						else
						{
							LG.End();
						}
					}
					break;

				case 4:
					if (!DeviceRsDef.Ax_PickZ.busy)//Z定位结束
					{
						LG.End();
					}
					break;
			}
		}

		public PickJumpParaDef pickJumpParaDef { get; set; } = new PickJumpParaDef();
	}


	public class PickJumpParaDef:IReadWrite
	{
		public FPointXYZR Ready { get; set; }//预备位
		public float Pos_PreInpY { get; set; }//Y提前量
		public float Pos_PreInpZ { get; set; }//Z提前量

	}
}

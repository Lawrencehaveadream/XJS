using HzControl.Logic;
using HZZH.Logic.Commmon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.SubLogicPrg
{
	public class StackLoadDef : LogicTask
	{
		public float Pos_First { get; set; }//第一层位置
		public float Pos_Last { get; set; }//最后一层位置
		public int Num_Level { get; set; }//总层数
		public int CurIdx = 0;//当前层
		public bool Finish = false;//已到达最后层
		public StackLoadDef() : base("上料堆叠下一层") { }
		protected override void LogicImpl()
		{
			if (Num_Level < 2) Num_Level = 2;//数据保护，不允许小于2
			switch (LG.Step)
			{
				case 1:
					if (!DeviceRsDef.Ax_LoadZ.busy)
					{
						DeviceRsDef.Ax_LoadZ.MC_MoveAbs(Pos_First + CurIdx * (Pos_Last - Pos_First) / (Num_Level - 1));
						LG.StepNext(2);
					}
					break;

				case 2:
					if (!DeviceRsDef.Ax_LoadZ.busy)
					{
						LG.End();
					}
					break;
			}
		}

		public bool GoNext()
		{
			CurIdx++;
			if (CurIdx < Num_Level)
			{
				LG.Start();
				return true;
			}
			else
			{
				Finish = true;
				return false;
			}
		}

		public bool GoLast()
		{
			CurIdx--;
			if (CurIdx >= 0)
			{
				LG.Start();
				return true;
			}
			else
			{
				CurIdx = 0;
				return false;
			}
		}
	}
}

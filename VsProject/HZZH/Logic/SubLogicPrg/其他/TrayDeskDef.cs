using CommonRs;
using HzControl.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.SubLogicPrg
{
	public class TrayDeskDef : LogicTask
	{
		FPointXY PosTar = new FPointXY();
		public TrayDeskDef() : base("Tray盘平台移动") { }
		public void Start(FPointXY p)
		{
			if (LG.Execute == false && LG.Step == 0)
			{
				this.PosTar = p;
				Start();
			}
		}
		protected override void LogicImpl()
		{
			throw new NotImplementedException();
		}
	}
}

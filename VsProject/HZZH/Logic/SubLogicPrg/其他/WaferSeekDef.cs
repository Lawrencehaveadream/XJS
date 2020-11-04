using HzControl.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.SubLogicPrg
{
	public class WaferSeekDef : LogicTask
	{
		public bool Ok;
		public WaferSeekDef() : base("寻晶") { }
		protected override void LogicImpl()
		{
			throw new NotImplementedException();
		}
	}
}

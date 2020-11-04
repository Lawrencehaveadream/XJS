using HzControl.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMain
{
    class LogicMainDef : LogicTask
    {
		public bool[] GroupEn { get; set; }
		public LogicMainDef() : base("Main")
		{
		}

        protected override void LogicImpl()
        {
            throw new NotImplementedException();
        }
    }
}

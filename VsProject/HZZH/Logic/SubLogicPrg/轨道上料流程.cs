using HzControl.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.SubLogicPrg
{
    public class 轨道上料流程 : LogicTask
    {
        public 轨道上料流程() : base("轨道上料流程")
        {

        }
        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    LG.ImmediateStepNext(2);
                    break;

                case 2:
                    LG.End();
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Device;
using HzControl.Logic;
using HZZH.Logic.Commmon;

namespace HZZH.Logic.SubLogicPrg
{
    public class 锡膏印刷流程 : LogicTask
    {
        public 锡膏印刷流程() : base("锡膏印刷流程")
        {

        }
        #region 保存数据
        /// <summary>
        /// 刮锡膏开始位置
        /// </summary>
        public float StartPos { get; set; }
        /// <summary>
        /// 刮锡膏结束位置
        /// </summary>
        public float EndPos { get; set; }
        /// <summary>
        /// 刮锡膏气缸动作延时
        /// </summary>
        public uint Delay { get; set; }
        #endregion
        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    DeviceRsDef.Ax_刮锡膏.MC_MoveAbs(StartPos);
                    LG.ImmediateStepNext(2);
                    DeviceRsDef.Q_刮刀1.OFF();
                    DeviceRsDef.Q_刮刀2.OFF();
                    break;

                case 2:
                    if(DeviceRsDef.Ax_刮锡膏.status == AxState.AXSTA_READY)
                    {
                        DeviceRsDef.Q_刮刀1.ON();
                        DeviceRsDef.Q_刮刀2.ON();
                        LG.ImmediateStepNext(3);
                    }
                    break;

                case 3:
                    if(LG.TCnt(Delay))
                    {
                        DeviceRsDef.Ax_刮锡膏.MC_MoveAbs(EndPos);
                        LG.ImmediateStepNext(4);
                    }
                    break;

                case 4:
                    if (DeviceRsDef.Ax_刮锡膏.status == AxState.AXSTA_READY)
                    {
                        DeviceRsDef.Q_刮刀1.OFF();
                        DeviceRsDef.Q_刮刀2.OFF();
                        LG.ImmediateStepNext(5);
                    }
                    break;

                case 5:
                    LG.End();
                    break;
            }
        }
    }
}

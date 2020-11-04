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
   public class UVW对位流程:LogicTask
    {
       public UVW对位流程():base("UVW对位流程")
        {

        }
        /// <summary>
        /// 顶升轴拍照位置
        /// </summary>
        public float RiseSnapPos { get; set; }
        /// <summary>
        /// XY轴拍照位置1
        /// </summary>
        public List<FPointXY> XYSnapPos { get; set; } = new List<FPointXY>();
        /// <summary>
        /// 拍照次数
        /// </summary>
        private int snapCount;
        protected override void LogicImpl()
        {
            switch(LG.Step)
            {
                case 1:
                    DeviceRsDef.Ax_顶升.MC_MoveAbs(RiseSnapPos);
                    LG.ImmediateStepNext(2);
                    snapCount = 0;
                    break;

                case 2:
                    if(DeviceRsDef.Ax_顶升.status == Device.AxState.AXSTA_READY)
                    {
                        DeviceRsDef.Ax_相机X轴.MC_MoveAbs(XYSnapPos[snapCount].X);
                        DeviceRsDef.Ax_相机Y轴.MC_MoveAbs(XYSnapPos[snapCount].Y);
                        LG.ImmediateStepNext(3);
                    }
                    break;

                case 3:
                    if (DeviceRsDef.Ax_相机X轴.status == Device.AxState.AXSTA_READY && DeviceRsDef.Ax_相机Y轴.status == Device.AxState.AXSTA_READY)
                    {
                        LG.ImmediateStepNext(4);
                    }
                    break;

                case 4://相机触发
                    if (LG.TCnt(50))
                    {
                        LG.ImmediateStepNext(5);
                    }
                    break;

                case 5:
                    //相机触发结果
                    LG.ImmediateStepNext(6);
                    break;

                case 6:
              
                    break;
            }
        }
    }
}

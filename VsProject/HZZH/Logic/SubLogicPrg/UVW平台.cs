using CommonRs;
using Device;
using HzControl.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.SubLogicPrg
{
    public class UVW平台
    {
        public FPointXYR CurrPos { get; }
        /// <summary>
        /// UVW状态
        /// </summary>
        public int Status
        {
            get
            {
                if (Ax_X1轴.status == AxState.AXSTA_READY && Ax_X2轴.status == AxState.AXSTA_READY && Ax_Y轴.status == AxState.AXSTA_READY)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        AxisClass Ax_X1轴;
        AxisClass Ax_X2轴;
        AxisClass Ax_Y轴;
        /// <summary>
        /// UVW预备位
        /// </summary>
        private float X1ReadyPos { get; set; }
        private float X2ReadyPos { get; set; }
        private float YReadyPos { get; set; }
        /// <summary>
        /// 虚拟半径
        /// </summary>
        private float Radius { get; set; }
        /// <summary>
        /// UVW平台绝对定位
        /// </summary>
        /// <param name="xTPos"></param>
        /// <param name="yTPos"></param>
        /// <param name="rTpos"></param>
        /// <returns></returns>
        public int MoveABS(float xTPos,float yTPos,float rTpos)
        {
            Ax_X1轴.MC_MoveAbs(xTPos);
            Ax_X2轴.MC_MoveAbs(yTPos);
            Ax_Y轴.MC_MoveAbs(rTpos);
            return 1;
        }
        /// <summary>
        /// UVW平台相对定位
        /// </summary>
        /// <param name="xTPos"></param>
        /// <param name="yTPos"></param>
        /// <param name="rTpos"></param>
        /// <returns></returns>
        public int MoveRel(float xTPos, float yTPos, float rTpos)
        {
            Ax_X1轴.MC_MoveRel(xTPos);
            Ax_X2轴.MC_MoveRel(yTPos);
            Ax_Y轴.MC_MoveRel(rTpos);
            return 1;
        }
        /// <summary>
        /// UVW平台回原点
        /// </summary>
        /// <returns></returns>
       public int Home()
        {
            Ax_X1轴.MC_Home();
            Ax_X2轴.MC_Home();
            Ax_Y轴.MC_Home();
            return 1;
        }
    }
}

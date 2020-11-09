using CommonRs;
using Device;
using HzControl.Logic;
using HZZH.Logic.Commmon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HZZH.Logic.UVWCtrl
{
    public class UVW平台
    {
        public FPointXYR CurrPos { get; }
        public UVWConvertXYR ConvertXYR { get; set; }

        public UVW平台(UVWConvertXYR convertXYR)
        {
            ConvertXYR = convertXYR;
            CurrPos = new FPointXYR();
        }

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

        readonly AxisClass Ax_X1轴 = DeviceRsDef.Ax_UVW平台X1轴;
        readonly AxisClass Ax_X2轴 = DeviceRsDef.Ax_UVW平台X2轴;
        readonly AxisClass Ax_Y轴 = DeviceRsDef.Ax_UVW平台Y轴;

        /// <summary>
        /// 设定于偏移，对应xyr坐标系中的零点
        /// </summary>
        public void SetZeroPos()
        {
            ConvertXYR.X1ReadyPos = Ax_X1轴.currPos;
            ConvertXYR.X2ReadyPos = Ax_X2轴.currPos;
            ConvertXYR.YReadyPos = Ax_Y轴.currPos;
            CurrPos.X = 0;
            CurrPos.Y = 0;
            CurrPos.R = 0;
        }

        /// <summary>
        /// UVW平台绝对定位
        /// </summary>
        /// <param name="xTPos"></param>
        /// <param name="yTPos"></param>
        /// <param name="rTpos"></param>
        /// <returns></returns>
        public int MoveABS(float xTPos,float yTPos,float rTpos)
        {
            return MoveRel(xTPos - CurrPos.X, yTPos - CurrPos.Y, rTpos - CurrPos.R);
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
            // 禁止平台运行时候再次调用
            if (Status == 1)
            {
                return 0;
            }

            float rx1, rx2, ry;
            ConvertXYR.RotateXYR_UnchangedCenter(rTpos, CurrPos.R, out rx1, out rx2, out ry);
            float xx1, xx2, xy;
            ConvertXYR.RelMoveX(xTPos, out xx1, out xx2, out xy);
            float yx1, yx2, yy;
            ConvertXYR.RelMoveY(yTPos, out yx1, out yx2, out yy);

            float x1 = rx1 + xx1 + yx1;
            float x2 = rx2 + xx2 + yx2;
            float y = ry + xy + yy;

            Ax_X1轴.MC_MoveRel(x1);
            Ax_X2轴.MC_MoveRel(x2);
            Ax_Y轴.MC_MoveRel(y);

            while (Status == 1)
            {
                Thread.Sleep(5);
            }

            CurrPos.X += xTPos;
            CurrPos.Y += yTPos;
            CurrPos.R += rTpos;

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

            while (Status == 1)
            {
                Thread.Sleep(5);
            }

            Ax_X1轴.MC_MoveAbs(ConvertXYR.X1ReadyPos);
            Ax_X2轴.MC_MoveAbs(ConvertXYR.X2ReadyPos);
            Ax_Y轴.MC_MoveAbs(ConvertXYR.YReadyPos);

            while (Status == 1)
            {
                Thread.Sleep(5);
            }
            CurrPos.X = 0;
            CurrPos.Y = 0;
            CurrPos.R = 0;

            return 1;
        }
    }
}

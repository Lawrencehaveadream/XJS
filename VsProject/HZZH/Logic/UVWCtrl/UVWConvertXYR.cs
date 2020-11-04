using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.UVWCtrl
{
    public class UVWConvertXYR
    {
        public float X1Theta { get; set; }
        public float X2Theta { get; set; }
        public float YTheta { get; set; }
        public float Rotate { get; set; }


        public UVWConvertXYR(float x1Theta, float x2Theta, float yTheta,float rotate)
        {
            X1Theta = x1Theta;
            X2Theta = x2Theta;
            YTheta = yTheta;
            Rotate = rotate;
        }

        /// <summary>
        /// 相对当前点转动旋转r，各个轴的相对给进量
        /// </summary>
        /// <param name="r">转动角</param>
        /// <param name="r0">当前角度</param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y"></param>
        public void RotateXYR_UnchangedCenter(float r, float r0, out float x1, out float x2, out float y)
        {
            double rad1 = (r + X1Theta + r0) * Math.PI / 180;
            double rad2 = (X1Theta + r0) * Math.PI / 180;
            x1 = (float)(Rotate * Math.Cos(rad1) - Rotate * Math.Cos(rad2));

            rad1 = (r + X2Theta + r0) * Math.PI / 180;
            rad2 = (X2Theta + r0) * Math.PI / 180;
            x2 = (float)(Rotate * Math.Cos(rad1) - Rotate * Math.Cos(rad2));

            rad1 = (r + YTheta + r0) * Math.PI / 180;
            rad2 = (YTheta + r0) * Math.PI / 180;
            y = (float)(Rotate * Math.Sin(rad1) - Rotate * Math.Sin(rad2));
        }

        /// <summary>
        /// 相对当前点移动X，各个轴的相对给进量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y"></param>
        public void RelMoveX(float X, out float x1, out float x2, out float y)
        {
            x1 = X;
            x2 = X;
            y = 0;
        }

        /// <summary>
        /// 相对当前点移动Y，各个轴的相对给进量
        /// </summary>
        /// <param name="Y"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y"></param>
        public void RelMoveY(float Y, out float x1, out float x2, out float y)
        {
            x1 = x2 = 0;
            y = Y;
        }

    }
}

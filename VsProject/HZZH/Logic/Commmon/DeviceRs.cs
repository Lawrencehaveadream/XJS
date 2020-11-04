using CommonRs;
using Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HZZH.Logic.Commmon
{
    public enum InIndex : int   //输入口定义
    {
        X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, X15, X16, X17, X18, X19, X20, X21, X22, X23, X24, X25, X26, X27, X28, X29, X30,
        X31, X32, X33, X34, X35, X36, X37, X38, X39, X40, X41, X42, X43, X44, X45, X46, X47, X48, X49, X50, X51, X52, X53, X54, X55, X56, X57, X58, X59, X60,
    }
    public enum OutIndex : int	//输入口定义
    {
        Y1, Y2, Y3, Y4, Y5, Y6, Y7, Y8, Y9, Y10, Y11, Y12, Y13, Y14, Y15, Y16, Y17, Y18, Y19, Y20, Y21, Y22, Y23, Y24, Y25, Y26, Y27, Y28, Y29, Y30, Y31, Y32,
    }
    public static class DeviceRsDef
    {
        #region 自动生成板卡资源列表
        /// <summary>
        /// 轴列表
        /// </summary>
        public readonly static List<AxisClass> AxisList = new List<AxisClass>();
        /// <summary>
        /// 输入列表
        /// </summary>
        public readonly static List<InputClass> InputList = new List<InputClass>();
        /// <summary>
        /// 输出列表
        /// </summary>
        public readonly static List<OutputClass> OutputList = new List<OutputClass>();

        static DeviceRsDef()
        {
            foreach (var item in typeof(DeviceRsDef).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
            {
                if (item.FieldType == typeof(AxisClass))
                {
                    AxisList.Add((AxisClass)item.GetValue(null));
                }

                if (item.FieldType == typeof(InputClass))
                {
                    InputList.Add((InputClass)item.GetValue(null));
                }

                if (item.FieldType == typeof(OutputClass))
                {
                    OutputList.Add((OutputClass)item.GetValue(null));
                }
            }

        }
        #endregion

        public static MotionCardDef MotionCard = new MotionCardDef("192.168.1.30", 8089);
        #region 轴定义
        public static AxisClass Ax_相机X轴 = new AxisClass(MotionCard,0,"X轴");
        public static AxisClass Ax_相机Y轴 = new AxisClass(MotionCard, 1, "Y轴");
        public static AxisClass Ax_UVW平台X1轴 = new AxisClass(MotionCard, 2, "UVW平台X1轴");
        public static AxisClass Ax_UVW平台X2轴 = new AxisClass(MotionCard, 3, "UVW平台X2轴");
        public static AxisClass Ax_UVW平台Y轴 = new AxisClass(MotionCard, 4, "UVW平台Y轴");
        public static AxisClass Ax_上料皮带 = new AxisClass(MotionCard,5,"上料皮带");
        public static AxisClass Ax_轨道调宽 = new AxisClass(MotionCard,6,"轨道调宽");
        public static AxisClass Ax_刮锡膏 = new AxisClass(MotionCard,7,"刮锡膏");
        public static AxisClass Ax_顶升 = new AxisClass(MotionCard,8,"顶升轴");
        public static AxisClass Ax_吸板轴 = new AxisClass(MotionCard,9, "吸板轴");
        public static AxisClass Ax_轨道送料轴 = new AxisClass(MotionCard, 10, "轨道送料轴");
        #endregion

        #region 输入定义
        public static InputClass I_相机X轴原点 = new InputClass(MotionCard, (int)InIndex.X1, "相机X轴原点");
        public static InputClass I_相机Y轴原点 = new InputClass(MotionCard, (int)InIndex.X2, "相机Y轴原点");
        public static InputClass I_UVW平台X1轴原点 = new InputClass(MotionCard, (int)InIndex.X3, "UVW平台X1轴原点");
        public static InputClass I_UVW平台X2轴原点 = new InputClass(MotionCard, (int)InIndex.X4, "UVW平台X2轴原点");
        public static InputClass I_UVW平台Y轴原点 = new InputClass(MotionCard, (int)InIndex.X5, "UVW平台Y轴原点");
        public static InputClass I_上料皮带原点 = new InputClass(MotionCard, (int)InIndex.X6, "上料皮带原点");
        public static InputClass I_轨道调宽原点 = new InputClass(MotionCard, (int)InIndex.X7, "轨道调宽原点");
        public static InputClass I_刮锡膏原点 = new InputClass(MotionCard, (int)InIndex.X8, "刮锡膏轴原点");
        public static InputClass I_顶升原点 = new InputClass(MotionCard, (int)InIndex.X9, "顶升轴原点");
        public static InputClass I_取料横移原点 = new InputClass(MotionCard, (int)InIndex.X10, "取料横移原点");
        public static InputClass I_Start = new InputClass(MotionCard, (int)InIndex.X13, "启动按钮");
        public static InputClass I_Stop = new InputClass(MotionCard, (int)InIndex.X14, "停止按钮");
        public static InputClass I_Scram = new InputClass(MotionCard, (int)InIndex.X15, "急停按钮");
        public static InputClass I_准备入板 = new InputClass(MotionCard, (int)InIndex.X17, "轨道出料感应");
        public static InputClass I_板到位 = new InputClass(MotionCard, (int)InIndex.X17, "板到位感应");
        public static InputClass I_出板到位 = new InputClass(MotionCard, (int)InIndex.X17, "出板到位感应");
        public static InputClass I_勾板气缸到位 = new InputClass(MotionCard, (int)InIndex.X17, "勾板气缸到位感应");
        public static InputClass I_档板气缸到位 = new InputClass(MotionCard, (int)InIndex.X17, "档板气缸到位感应");
        public static InputClass I_吸板气缸回位 = new InputClass(MotionCard, (int)InIndex.X17, "吸板气缸回位感应");
        public static InputClass I_夹板气缸回位 = new InputClass(MotionCard, (int)InIndex.X17, "轨道出料感应");



        #endregion

        #region 输出定义
        public static OutputClass Q_勾板气缸 = new OutputClass(MotionCard, (int)OutIndex.Y1, "取料吸嘴");
        public static OutputClass Q_档板气缸 = new OutputClass(MotionCard, (int)OutIndex.Y2, "档板气缸");
        public static OutputClass Q_刮刀1 = new OutputClass(MotionCard, (int)OutIndex.Y3, "刮刀1");
        public static OutputClass Q_刮刀2 = new OutputClass(MotionCard, (int)OutIndex.Y4, "刮刀2");
        public static OutputClass Q_夹紧钢网 = new OutputClass(MotionCard, (int)OutIndex.Y5, "夹紧钢网");
        public static OutputClass Q_吸板气缸 = new OutputClass(MotionCard, (int)OutIndex.Y6, "吸板气缸");
        public static OutputClass 夹板气缸 = new OutputClass(MotionCard, (int)OutIndex.Y7, "夹板气缸");
        public static OutputClass Q_Red = new OutputClass(MotionCard, (int)OutIndex.Y9, "红灯");
        public static OutputClass Q_Green = new OutputClass(MotionCard, (int)OutIndex.Y10, "绿灯");
        public static OutputClass Q_Yellow = new OutputClass(MotionCard, (int)OutIndex.Y11, "黄灯");
        public static OutputClass Q_Beep = new OutputClass(MotionCard, (int)OutIndex.Y12, "蜂鸣器");
        #endregion
    }
}

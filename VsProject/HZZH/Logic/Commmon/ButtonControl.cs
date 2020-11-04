using CommonRs;
using HZZH.Common.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.Commmon
{
    /// <summary>
    /// 按钮控制
    /// </summary>
    public class ButtonControlDef
    {
        //private FsmDef FSM;
        //public ButtonControlDef(FsmDef FSM)
        //{
        //    this.FSM = FSM;
        //}
        //public void BtEvent()
        //{
        //    //运行按钮
        //    if (DeviceRsDef.I_Start.value)
        //    {
        //        FSM.Run();
        //    }
        //    if (DeviceRsDef.I_XFarLimit.value)
        //    {
        //        FSM.Scram();
        //        DeviceRsDef.Axis_X.MC_Stop();
        //    }
        //    if (DeviceRsDef.I_YFarLimit.value)
        //    {
        //        FSM.Scram();
        //        DeviceRsDef.Axis_Y.MC_Stop();
        //    }
        //    //停止按钮
        //    if(DeviceRsDef.I_Stop.value)
        //    {
        //        if(FSM.GetStatus != FsmStaDef.RUN)
        //        {
        //            MachineAlarm.ClearAlarm();
        //        }               
        //        FSM.Stop();              
        //    }

        //    //停止按钮
        //    if (DeviceRsDef.I_Reset.value)
        //    {
        //        FSM.Reset();
        //    }

        //    //急停
        //    if (DeviceRsDef.I_Scam.value == false)
        //    {
        //        for(int i=0;i< DeviceRsDef.AxisList.Count;i++)
        //        {
        //            if(DeviceRsDef.AxisList[i].status != Device.AxState.AXSTA_READY)
        //            {
        //                DeviceRsDef.AxisList[i].MC_Stop();
        //            }
        //            DeviceRsDef.AxisList[i].MC_PowerOn();
        //        }

        //        FSM.Scram();
        //    }
        //    else
        //    {
        //        //当松开急停后，状态机恢复到初始态
        //        if (FSM.GetStatus == FsmStaDef.SCRAM)
        //        {
        //            FSM.Init(); 
        //        }
        //        for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
        //        {
        //            DeviceRsDef.AxisList[i].MC_PowerOff();
        //        }
        //    }

        //    if (FSM.GetStatus == FsmStaDef.SCRAM)
        //    {
        //        MachineAlarm.SetAlarm(AlarmLevelEnum.Level3,"急停按下");
        //    }
        // }
    }
}

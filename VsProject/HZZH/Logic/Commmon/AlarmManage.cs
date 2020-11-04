using CommonRs;
using HZZH.Common.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.Commmon
{
    public class AlarmManage
    {
        //private FsmDef FSM;
        //public AlarmManage(FsmDef FSM )
        //{
        //    this.FSM = FSM;
        //}
        //public void AlarmEvent()
        //{
        //    //报警等级为2
        //    if (MachineAlarm.AlarmLever == AlarmLevelEnum.Level2)
        //    {
        //        FSM.AlarmStop();
        //    }
        //    else if (MachineAlarm.AlarmLever > AlarmLevelEnum.Level2)
        //    {
        //        FSM.ErrorStop();
        //    }
        //    if (!DeviceRsDef.MotionCard.netSucceed)
        //    {
        //        MachineAlarm.SetAlarm(AlarmLevelEnum.Level3, "控制器掉线");
        //        for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
        //        {
        //            DeviceRsDef.AxisList[i].MC_Stop();
        //        }
        //    }

        //    for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
        //    {
        //        if (DeviceRsDef.AxisList[i].status == Device.AxState.AXSTA_ERRSTOP)
        //        {
        //            string alarmMessage = DeviceRsDef.AxisList[i].errMesg;
        //            MachineAlarm.SetAlarm(AlarmLevelEnum.Level3, alarmMessage);
        //        }
        //    }
        //}
    }
}

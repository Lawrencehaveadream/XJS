using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Logic.Commmon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMain
{
    class LogicLoopRun : LogicLoop
    {
        public LogicLoopRun() : base("报警等循环扫描")
        {

        }

        protected override void LogicImpl()
        {
            //报警等级为2
            if (MachineAlarm.AlarmLever == AlarmLevelEnum.Level2)
            {
                this.Manager.FSM.Change(FSMStaDef.ALARM);
            }
            else if (MachineAlarm.AlarmLever > AlarmLevelEnum.Level2)
            {
                this.Manager.FSM.Change(FSMStaDef.ERROR);
            }

            for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
            {
                if (DeviceRsDef.AxisList[i].status == Device.AxState.AXSTA_ERRSTOP)
                {
                    string alarmMessage = DeviceRsDef.AxisList[i].errMesg;
                    MachineAlarm.SetAlarm(AlarmLevelEnum.Level3, alarmMessage);
                }
            }
        }
    }
}

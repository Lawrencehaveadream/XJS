using CommonRs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.Commmon
{
    /// <summary>
    /// LED灯柱显示
    /// </summary>
    public class LedLampStandardDef
    {
        //private FsmDef FSM;
        //public LedLampStandardDef(FsmDef FSM)
        //{
        //    this.FSM = FSM;
        //}


        //private TimerClass Timer = new TimerClass();
        //public void Logic()
        //{
        //    switch(FSM.GetStatus)
        //    {
        //        case FsmStaDef.INIT:
        //            DeviceRsDef.Q_GreenLed.Value = false;
        //            DeviceRsDef.Q_YellowLed.Value = false;
        //            DeviceRsDef.Q_RedLed.Value = true;
        //            DeviceRsDef.Q_Buzzle.Value = false;
        //            break;

        //        case FsmStaDef.STOP:
        //            DeviceRsDef.Q_GreenLed.Value = false;
        //            DeviceRsDef.Q_YellowLed.Value = true;
        //            DeviceRsDef.Q_RedLed.Value = false;
        //            DeviceRsDef.Q_Buzzle.Value = false;
        //            break;
        //        case FsmStaDef.PAUSE:
        //            DeviceRsDef.Q_GreenLed.Value = false;
        //            DeviceRsDef.Q_YellowLed.Value = true;
        //            DeviceRsDef.Q_RedLed.Value = false;
        //            DeviceRsDef.Q_Buzzle.Value = false;
        //            break;

        //        case FsmStaDef.RESET:
        //            DeviceRsDef.Q_GreenLed.Value = false;
        //            DeviceRsDef.Q_YellowLed.Value = Timer.Blink(true,1000,1000);
        //            DeviceRsDef.Q_RedLed.Value = false;
        //            DeviceRsDef.Q_Buzzle.Value = false;
        //            break;

        //        case FsmStaDef.RUN:
        //            DeviceRsDef.Q_GreenLed.Value = true;
        //            DeviceRsDef.Q_YellowLed.Value = false;
        //            DeviceRsDef.Q_RedLed.Value = false;
        //            DeviceRsDef.Q_Buzzle.Value = false;
        //            break;

        //        case FsmStaDef.SCRAM:
        //        case FsmStaDef.ALARM:
        //        case FsmStaDef.ERROR:
        //            DeviceRsDef.Q_GreenLed.Value = false;
        //            DeviceRsDef.Q_YellowLed.Value = false;
        //            DeviceRsDef.Q_RedLed.Value = true;
        //            //if (AdminControl.Instance.StopBeer == false)
        //            //DeviceRsDef.Q_Buzzle.Value = Timer.Blink(true, 1000, 1000);
        //            break;

        //    }
        //}
    }
}

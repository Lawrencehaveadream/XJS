using HzControl.Logic;
//using HZZH.Logic.SubLogicPrg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMain
{
    class TaskMain
    {
        public static LogicMainDef LogicMain { get; set; }
        public static ResetLogicDef ResetLogic { get; set; }
        public static LogicLoopRun LogicLoop { get; set; }


       // public static TrayDeskDef TrayDesk { get; set; }
       // public static TrayJumpDef TrayJump { get; set; }
       // public static TrayLoadDef TrayLoad { get; set; }
       //  public static TrayUnloadDef TrayUnload { get; set; }
       //public static StackLoadDef StackLoad { get; set; }
       // public static StackUnloadDef StackUnload { get; set; }
       // public static PickJumpDef PickJump { get; set; }
       // public static PickDetectDef PickDetect { get; set; }
       // public static PickDiscardDef PickDiscard { get; set; }
       // public static PickPutDef PickPut { get; set; }
       // public static PickTakeDef PickTake { get; set; }
       // public static WaferDeskDef WaferDesk { get; set; }
       // public static WaferSeekDef WaferSeek { get; set; }
       // public static RockerDef Rocker { get; set; }

        static TaskMain()
        {
            LogicMain = new LogicMainDef();
            ResetLogic = new ResetLogicDef();
            LogicLoop = new LogicLoopRun();

            //TrayDesk = new TrayDeskDef();
            //TrayJump = new TrayJumpDef();
            //TrayLoad = new TrayLoadDef();
            //TrayUnload = new TrayUnloadDef();
            //StackLoad = new StackLoadDef();
            //StackUnload = new StackUnloadDef();
            //PickJump = new PickJumpDef();
            //PickDetect = new PickDetectDef();
            //PickDiscard = new PickDiscardDef();
            //PickPut = new PickPutDef();
            //PickTake = new PickTakeDef();
            //WaferDesk = new WaferDeskDef();
            //WaferSeek = new WaferSeekDef();
            //Rocker = new RockerDef();
        }

        public static void Init()
        {
            TaskManager.Default.FSM.ChangeState += FSM_ChangeState;

            TaskManager.Default.Add(LogicMain);
            TaskManager.Default.Add(ResetLogic);
            TaskManager.Default.Add(LogicLoop);


            //TaskManager.Default.Add(TrayDesk);
            //TaskManager.Default.Add(TrayJump);
            //TaskManager.Default.Add(TrayLoad);
            //TaskManager.Default.Add(TrayUnload);
            //TaskManager.Default.Add(StackLoad);
            //TaskManager.Default.Add(StackUnload);
            //TaskManager.Default.Add(PickJump);
            //TaskManager.Default.Add(PickDetect);

            //TaskManager.Default.Add(PickDiscard);
            //TaskManager.Default.Add(PickPut);
            //TaskManager.Default.Add(PickTake);
            //TaskManager.Default.Add(WaferDesk);
            //TaskManager.Default.Add(WaferSeek);
            //TaskManager.Default.Add(Rocker);

        }

        private static void FSM_ChangeState(object sender, FSMChangeEventArgs e)
        {
            // 主逻辑运行
            if (e.State.ID == FSMStaDef.RUN)
            {
                //LogicMain.Start();
            }

            // 复位逻辑卷运行
            if (e.State.ID == FSMStaDef.RESET)
            {
                //ResetLogic.Start();
            }

            // 点击停止，部分逻辑可能不能停止，需要继续运行
            if (e.State.ID == FSMStaDef.STOP)
            {
                foreach (var item in TaskManager.Default.LogicTasks)
                {
                    if (item.Name != "")
                    {
                        //item.Stop();
                    }
                }
            }

            // 急停，所有的逻辑全部停止
            if (e.State.ID == FSMStaDef.SCRAM)
            {
                foreach (var item in TaskManager.Default.LogicTasks)
                {
                    item.Stop();
                }
            }
        }
    }
}

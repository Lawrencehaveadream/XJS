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



        static TaskMain()
        {
            LogicMain = new LogicMainDef();
            ResetLogic = new ResetLogicDef();
            LogicLoop = new LogicLoopRun();

        }

        public static void Init()
        {
            TaskManager.Default.FSM.ChangeState += FSM_ChangeState;

            TaskManager.Default.Add(LogicMain);
            TaskManager.Default.Add(ResetLogic);
            TaskManager.Default.Add(LogicLoop);




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

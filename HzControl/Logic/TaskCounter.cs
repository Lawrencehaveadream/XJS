using HzControl.Logic;
using System;

namespace HzControl.Logic
{
    /// <summary>
    /// 任务计步
    /// </summary>
    public class TaskCounter
    {
        private readonly LogicTask logicTask;

        public TaskCounter(LogicTask task)
        {
            logicTask = task;
        }

        private int execute;
        private int step;
        private int done;
        private DateTime start;
        private DateTime end;

        /// <summary>
        /// 任务开始到完成执行的时间
        /// </summary>
        public double Time
        {
            get; private set;
        }

        /// <summary>
        /// 表示完成事件，给到外部方便调用
        /// </summary>
        public event EventHandler Completed;

        /// <summary>
        /// 是否正在执行
        /// </summary>
        public bool Execute
        {
            get
            {
                return execute > 0;
            }
        }

        /// <summary>
        /// 当前步
        /// </summary>
        public int Step
        {
            get
            {
                return step;
            }
        }
        /// <summary>
        /// 完成否
        /// </summary>
        public int Done
        {
            get
            {
                return done;
            }
        }

        /// <summary>
        /// 开始
        /// </summary>
        public void Start()
        {
            if (step == 0 && execute == 0)
            {
                ImmediateStepNext(1);
                execute = 1;
                done = 0;
                start = DateTime.Now;
                end = DateTime.Now;
            }
            else if (step > 0 && execute == 0)
            {
                execute = 1;
            }
        }

        /// <summary>
        /// 停止,并且不会进入执行函数中的扫描
        /// </summary>
        public void Stop()
        {
            execute = 0;
        }

        /// <summary>
        /// 完成
        /// </summary>
        public void End()
        {
            //if (step > 0 && execute > 0)
            {
                ImmediateStepNext(0);
                execute = 0;
                done = 1;
                end = DateTime.Now;
                Time = (end - start).TotalMilliseconds;
                OnCompleted();
            }
        }

        /// <summary>
        /// 到下一步
        /// </summary>
        /// <param name="stepVal"></param>
        /// <param name="fsmStaDef"></param>
        public void StepNext(int stepVal, FSMStaDef fsmStaDef = FSMStaDef.RUN)
        {
            if (execute > 0 && fsmStaDef.HasFlag(logicTask.Manager.FSM.Status.ID))
            {
                ImmediateStepNext(stepVal);
            }
        }

        /// <summary>
        /// 不做任何判断，直接到下一步
        /// </summary>
        /// <param name="stetpVal"></param>
        public void ImmediateStepNext(int stetpVal)
        {
            step = stetpVal;
            stepNextTime = DateTime.Now;
            enableTime = 0;
            TRst();
        }

        /// <summary>
        /// 延时一段时间后进入下一步
        /// </summary>
        /// <param name="stepVal"></param>
        /// <param name="delay"></param>
        /// <param name="fsmStaDef"></param>
        public void StepNext(int stepVal, int delay, FSMStaDef fsmStaDef = FSMStaDef.RUN)
        {
            if (execute > 0 && fsmStaDef.HasFlag(logicTask.Manager.FSM.Status.ID))
            {
                if (stepDelayTime == DateTime.MinValue)
                {
                    stepDelayTime = DateTime.Now;
                }

                if ((DateTime.Now - stepDelayTime).TotalMilliseconds > delay)
                {
                    ImmediateStepNext(stepVal);
                    stepDelayTime = DateTime.MinValue;
                }
            }
        }
        /// <summary>
        /// 用在延后计时，标识多久后进入下一步
        /// </summary>
        private DateTime stepDelayTime = DateTime.MinValue;
        private void OnCompleted()
        {
            EventHandler handler = Completed;
            if (handler != null)
            {
                handler(logicTask, EventArgs.Empty);
            }
        }

        //public T GetEnumStep<T>() where T : Enum
        //{
        //    return (T)Enum.ToObject(typeof(T), step);
        //}


        /// <summary>
        /// 用于步骤跳转后，到下一步逻辑前的延时判断
        /// </summary>
        private DateTime stepNextTime;
        private int enableTime = 0;

        /// <summary>
        /// 在步跳转后，根据使能返回延时的状态
        /// </summary>
        /// <param name="time"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public bool Delay(int time, bool enable = true)
        {
            bool flag = false;
            if (enable == true)
            {
                flag = (DateTime.Now - stepDelayTime).TotalMilliseconds - enableTime > time;
            }
            else
            {
                enableTime = (int)(DateTime.Now - stepDelayTime).TotalMilliseconds;
            }

            return flag;
        }

        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="clk">触发条件</param>
        /// <param name="et_ms">预设时间</param>
        /// <returns></returns>
        public bool Ton(bool clk, int et_ms)
        {
            if (clk)
            {
                TimeSpan singleTimeSpan = System.DateTime.Now.Subtract(et);
                if (singleTimeSpan.TotalMilliseconds >= et_ms)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                et = System.DateTime.Now;
                return false;
            }
        }

        private DateTime et = new DateTime();
        /// <summary>
        /// 定时器复位
        /// </summary>
        public void TonRst()
        {
            et = System.DateTime.Now;
        }


        /// <summary>
        /// 计时器
        /// </summary>
        /// <param name="delay_ms">延时时间</param>
        /// <returns></returns>
        public bool TCnt(uint delay_ms)
        {
            TimeSpan singleTimeSpan = System.DateTime.Now.Subtract(tm);
            if (delay_ms <= (uint)singleTimeSpan.TotalMilliseconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private DateTime tm = new DateTime();
        /// <summary>
        /// 计时器清零
        /// </summary>
        public void TRst()
        {
            tm = System.DateTime.Now;
        }

        private bool trigBuff;
        /// <summary>
        /// 上升沿触发，持续一个扫描周期
        /// </summary>
        /// <param name="clk"></param>
        /// <returns></returns>
        public bool R_Trig(bool clk)
        {
            if (clk != trigBuff)
            {
                trigBuff = clk;
                if (clk)
                    return true;
            }
            return false;
        }
        //
        /// <summary>
        /// 下降沿触发，持续一个扫描周期
        /// </summary>
        /// <param name="clk"></param>
        /// <returns></returns>
        public bool F_Trig(bool clk)
        {
            if (clk != trigBuff)
            {
                trigBuff = clk;
                if (!clk)
                    return true;
            }
            return false;
        }

        private bool trigBuff1;
        private DateTime trigTm = new DateTime();
        /// <summary>
        /// 延时触发，持续一个扫描周期
        /// </summary>
        /// <param name="clk"></param>
        /// <param name="delay_ms"></param>
        /// <returns></returns>
        public bool Trig(bool clk, int delay_ms)
        {
            if (clk)
            {
                if (clk != trigBuff1)
                {
                    TimeSpan singleTimeSpan = System.DateTime.Now.Subtract(trigTm);
                    if (singleTimeSpan.TotalMilliseconds >= delay_ms)
                    {
                        trigBuff1 = clk;
                        return true;
                    }
                }
            }
            else
            {
                trigTm = System.DateTime.Now;
            }
            return false;
        }
    }


 
}
 
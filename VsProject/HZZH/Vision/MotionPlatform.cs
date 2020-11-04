
using HZZH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections;
using Device;
using HZZH.Logic.Commmon;

namespace HZZH.Vision.Logic
{
    //[Serializable]
    //public class MotionPlatform : IPlatformMove
    //{
    //    public MotionCardDef movedriverZm = null;

    //    public int AxisX { get; set; }
    //    public int AxisY { get; set; }

    //    public MotionPlatform(MotionCardDef board, int axX, int axY)
    //    {
    //        movedriverZm = board;
    //        AxisX = axX;
    //        AxisY = axY;
    //    }


    //    public float[] AxisPosition
    //    {
    //        get
    //        {
    //            float[] XYROrigin = new float[3];
    //            XYROrigin[0] = movedriverZm.MotionFun.MC_GetCurrPos(AxisX);
    //            XYROrigin[1] = movedriverZm.MotionFun.MC_GetCurrPos(AxisY);
    //            XYROrigin[2] = 0;

    //            return XYROrigin;
    //        }
    //    }



    //    public void AbsMoving(float x, float y)
    //    {
    //        movedriverZm.MotionFun.MC_MoveAbs(AxisX, 100, x);
    //        movedriverZm.MotionFun.MC_MoveAbs(AxisY, 100, y);


    //        System.Threading.Thread.Sleep(3);

    //        if (CompleteMovedEvent != null)
    //        {
    //            CheckCompleteMove();
    //        }

    //    }

    //    public bool WaitOnCompleteMoving(int outTime = -1)
    //    {
    //        DateTime time = DateTime.Now;
    //        float spendTime = outTime < 0 ? float.PositiveInfinity : outTime;
    //        while (Math.Abs((time - DateTime.Now).TotalMilliseconds) < spendTime)
    //        {
    //            int[] state = GetMotionState();

    //            bool flag = false;
    //            for (int i = 0; i < state.Length; i++)
    //            {
    //                if (state[i] != 0)
    //                {
    //                    flag = true;
    //                    break;
    //                }
    //            }

    //            if (flag == true)
    //            {
    //                System.Threading.Thread.Sleep(10);
    //            }
    //            else
    //            {
    //                return true;
    //            }
    //        }

    //        return false;
    //    }


    //    private int[] GetMotionState()
    //    {
    //        return new int[] {
    //            movedriverZm.MotionFun.MC_AxGetStatus(AxisX),
    //            movedriverZm.MotionFun.MC_AxGetStatus(AxisY) };
    //    }


    //    private void CheckCompleteMove()
    //    {
    //        Action action = (() =>
    //        {
    //            Thread.Sleep(50);
    //            ((IPlatformMove)this).WaitOnCompleteMoving();
    //        });
    //        AsyncCallback callback = ((ar) =>
    //        {
    //            OnCompleteMoved(this, EventArgs.Empty);
    //        });
    //        IAsyncResult result = action.BeginInvoke(callback, null);
    //    }



    //    public event EventHandler CompleteMovedEvent;

    //    protected void OnCompleteMoved(object sender, EventArgs e)
    //    {
    //        EventHandler temp = CompleteMovedEvent;
    //        if (temp != null)
    //        {
    //            temp(this, EventArgs.Empty);
    //        }
    //    }


    //    private MotionPlatform()
    //    {

    //    }




    //    public static MotionPlatform Platform = new MotionPlatform(DeviceRsDef.MotionCard, 0, 1);
    //}







}

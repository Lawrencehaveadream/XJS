using HzControl.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HZZH.Logic.UVWCtrl
{
    class UVW自动标定 : LogicTask
    {
        public UVW自动标定() : base("UVW自动标定")
        { 
        
        }

        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    break;
                     
                case 2:

                    break;
            }
        }
    }
}

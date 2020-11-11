using CommonRs;
using HZZH.Logic.UVWCtrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Database
{
    public partial class Product
    {
        public UVWConvertXYR UVWConvert { get; set; }

        public MachinePos Pos { get; set; }
    }

    [Serializable]
    public class MachinePos : ProductBase
    {
        public FPointXY CamPre { get; set; } = new FPointXY();
        public FPointXY CamPos1 { get; set; } = new FPointXY();
        public FPointXY CamPos2 { get; set; } = new FPointXY();

        public float ScraperStar { get; set; }
        public float ScraperEnd { get; set; }


        public float JackPrePos { get; set; }
        public float JackPhotoPos { get; set; }
        public float JackScrapPos { get; set; }


    }



}

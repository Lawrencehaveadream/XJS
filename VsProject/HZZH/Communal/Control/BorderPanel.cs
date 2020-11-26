using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace HZZH.Communal.Control
{
    public class BorderPanel : Panel
    {
        public BorderPanel() : base()
        {
            BorderLineWidth = 2;
            BorderColor = SystemColors.Control;
            DisplayBorder = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;  
        }


 
        [DefaultValue(4)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public int BorderLineWidth {get;set; }

        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BorderColor { get; set; } 

        [DefaultValue(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right)]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public AnchorStyles DisplayBorder { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            RectangleF[] rectangleF = new RectangleF[4];
            rectangleF[0] = this.ClientRectangle;
            rectangleF[0].Height = BorderLineWidth;

            rectangleF[1] = this.ClientRectangle;
            rectangleF[1].Height = BorderLineWidth;
            rectangleF[1].Y = Height - BorderLineWidth;

            rectangleF[2] = this.ClientRectangle;
            rectangleF[2].Width = BorderLineWidth;

            rectangleF[3] = this.ClientRectangle;
            rectangleF[3].Width = BorderLineWidth;
            rectangleF[3].X = Width - BorderLineWidth;


            using (SolidBrush solidBrush = new SolidBrush(BorderColor))
            {
                if (DisplayBorder.HasFlag(AnchorStyles.Top))
                {
                    e.Graphics.FillRectangle(solidBrush, rectangleF[0]);
                }
                if (DisplayBorder.HasFlag(AnchorStyles.Bottom))
                {
                    e.Graphics.FillRectangle(solidBrush, rectangleF[1]);
                }
                if (DisplayBorder.HasFlag(AnchorStyles.Left))
                {
                    e.Graphics.FillRectangle(solidBrush, rectangleF[2]);
                }
                if (DisplayBorder.HasFlag(AnchorStyles.Right))
                {
                    e.Graphics.FillRectangle(solidBrush, rectangleF[3]);
                }
            }


        }

    

    }

    //public class MyCustomControlDesigner : ControlDesigner
    //{
    //    protected override void PostFilterProperties(System.Collections.IDictionary properties)
    //    {
    //        base.PostFilterProperties(properties);
    //        properties.Remove("Modifiers");
    //        properties.Remove("GenerateMember");
    //    }
    //}
}

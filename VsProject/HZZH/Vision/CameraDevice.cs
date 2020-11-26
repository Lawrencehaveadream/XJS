using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HZZH.Vision
{
    class CameraDevice : IDisposable
    {
        private AxSDK_2000Lib.AxSDK_2000 axSDK_20001;

        public void SetDevice(AxSDK_2000Lib.AxSDK_2000 axSDK)
        {
            axSDK_20001 = axSDK;
            axSDK_20001.Connect(false);
            ImageWidth = axSDK_20001.GetPreviewWidth();
            ImageHeight = axSDK_20001.GetPreviewHeight();
            _camImage = new Bitmap(ImageWidth, ImageHeight);
            axSDK_20001.Run();
        }

        private int ImageWidth, ImageHeight;

        public bool Connected()
        {
            return axSDK_20001.IsVideoSignalLocked();
        }

        public void 通道选择()
        {
            axSDK_20001.DlgVideoSource();
        }



        Image _camImage = null;

        private Image CaptureImg()
        {
            Image image = null;
            if (axSDK_20001.EditCopy())
            {
                if (Clipboard.ContainsImage())
                {
                    image = Clipboard.GetImage();
                    Clipboard.Clear();
                }
            }
            return image;
        }
        public void Dispose()
        {
            if (axSDK_20001 != null)
            {
                axSDK_20001.Disconnect();
            }
        }
    }
}

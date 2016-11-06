using Emgu.CV;
using System.Drawing;

namespace CaptureService
{
    public class Capturer
    {
        public Bitmap CaptureImage()
        {
            Capture capturer = new Capture(Emgu.CV.CvEnum.CaptureType.Any);
            Mat mat = capturer.QueryFrame();
            capturer.Dispose();

            return mat.Bitmap;
        }
    }
}

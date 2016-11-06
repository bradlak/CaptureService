using System;
using System.Configuration;
using System.Drawing.Imaging;
using System.Timers;

namespace CaptureService
{
    public class CaptureService
    {
        public void InitializeTimer()
        {
            var timer = new Timer();
            timer.Interval = Convert.ToDouble(ConfigurationManager.AppSettings["interval"]);
            timer.Elapsed += (s, e) => GetAndSaveImage();
            timer.Start();
        }

        public void GetAndSaveImage()
        {
            Capturer capturer = new Capturer();
            var bitmap = capturer.CaptureImage();
            string name = Guid.NewGuid().ToString().Replace("-", "") + ".png";

            string fullPath = ConfigurationManager.AppSettings["imgDirectory"] + name;
            bitmap.Save(fullPath, ImageFormat.Png);
        }

        public void Start()
        {
            InitializeTimer();
        }

        public void Stop()
        {
            // stop method required.
        }
    }
}

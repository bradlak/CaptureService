using System;
using System.ServiceProcess;

namespace CaptureService
{
    public class ServiceInstaller
    {
        public void Install()
        {
            bool exist = false;
            var services = ServiceController.GetServices();

            foreach (var service in services)
            {
                if (service.ServiceName == Constants.ServiceName)
                {
                    exist = true;
                    if (service.Status == ServiceControllerStatus.Stopped || service.Status == ServiceControllerStatus.Paused) service.Start();
                }
            }

            if (!exist)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C CaptureService.exe install";
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                var servicess = ServiceController.GetServices();

                foreach (var item in servicess)
                {
                    if (item.ServiceName == Constants.ServiceName)
                    {
                        if (item.Status == ServiceControllerStatus.Stopped || item.Status == ServiceControllerStatus.Paused) item.Start();
                    }
                }
                Environment.Exit(1);
            }
            else
            {
                if (Environment.UserInteractive)
                {
                    Environment.Exit(1);
                }
            }
        }
    }
}

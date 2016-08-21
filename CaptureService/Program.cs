using System.Configuration;
using Topshelf;

namespace CaptureService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<CaptureService>(s =>
                {
                    s.ConstructUsing<CaptureService>(cs => new CaptureService());
                    s.WhenStarted(cs => cs.Start());
                    s.WhenStopped(cs => cs.Stop());
                    s.BeforeStartingService(() =>
                    {
                        new DirectoryCreator().CreateDirectories(ConfigurationManager.AppSettings["imgDirectory"]);
                        new ServiceInstaller().Install(); });
                });

                x.RunAsLocalSystem();
                x.StartAutomatically();
            });
        }
    }
}




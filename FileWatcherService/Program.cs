using BradyCodeChallenge.Infrastructure.Interfaces;
using System.Configuration;
using System.ServiceProcess;

namespace BradyCodeChallenge.FileWatcherService
{
    static class Program
    {
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new global::BradyCodeChallenge.FileWatcherService.FolderWatcherService(
                    new FileWatcher())
            };

            ServiceBase.Run(servicesToRun);
        }
    }
}

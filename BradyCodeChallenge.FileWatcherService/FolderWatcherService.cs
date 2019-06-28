using System.ServiceProcess;
using System.Threading;
using BradyCodeChallenge.Common.Logger;
using BradyCodeChallenge.Infrastructure.Interfaces;

namespace BradyCodeChallenge.FileWatcherService
{
    public partial class FolderWatcherService : ServiceBase
    {
        private readonly IWatcher _fileWatcher;

        public FolderWatcherService(IWatcher fileWatcher)
        {
            InitializeComponent();
            _fileWatcher = fileWatcher;
        }

        protected override void OnStart(string[] args)
        {
            Logger.Info("Thread Start");
            var thread = new Thread(_fileWatcher.Start);
            thread.Start();
        }

        protected override void OnStop()
        {
             Logger.Info("Thread Stop");
            _fileWatcher.Stop();
            Thread.Sleep(1000);
        }
    }
}

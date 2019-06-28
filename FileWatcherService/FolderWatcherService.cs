using System.ServiceProcess;
using System.Threading;
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
            var thread = new Thread(_fileWatcher.Start);
            thread.Start();
        }

        protected override void OnStop()
        {
            _fileWatcher.Stop();
            Thread.Sleep(1000);
        }
    }
}

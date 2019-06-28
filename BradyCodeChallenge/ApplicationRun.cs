using BradyCodeChallenge.FileWatcherService;
using BradyCodeChallenge.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace BradyCodeChallenge
{
    public class ApplicationRun
    {
        private readonly IWatcher _watcher;
        private readonly ICalculateData _calculateData;

        public ApplicationRun(IWatcher watcher, ICalculateData calculateData)
        {
            _watcher = watcher;
            _calculateData = calculateData;
        }

        // Application starting point
        public void Run()
        {
            // Run service
            HostFactory.Run(x =>
            {
                x.Service<FileWatcher>(s =>
                {
                    s.ConstructUsing(name =>
                        new FileWatcher(_calculateData));

                    s.WhenStarted(fw => fw.Start());
                    s.WhenStopped(fw => fw.Stop());
                });

                x.RunAsLocalSystem();
            });
        }
    }
}

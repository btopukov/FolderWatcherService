using BradyCodeChallenge.FileWatcherService;
using BradyCodeChallenge.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BradyCodeChallenge.Common.Logger;
using Topshelf;

namespace BradyCodeChallenge
{
    public class ApplicationRun
    {
        private readonly ICalculateData _calculateData;

        public ApplicationRun(ICalculateData calculateData)
        {
            _calculateData = calculateData;
        }

        // Application starting point
        public void Run()
        {
            // Run service
            HostFactory.Run(x =>
            {
                x.Service<IWatcher>(s =>
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

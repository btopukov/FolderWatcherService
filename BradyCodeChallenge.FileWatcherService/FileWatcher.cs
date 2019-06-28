﻿using System;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using BradyCodeChallenge.Common.Serializer;
using BradyCodeChallenge.Infrastructure.Interfaces;
using BradyCodeChallenge.Infrastructure.Models.Input;
using BradyCodeChallenge.Infrastructure.Models.Output;
using BradyCodeChallenge.Service;
using BradyCodeChallenge.Service.StaticData;

namespace BradyCodeChallenge.FileWatcherService
{
    public class FileWatcher : IWatcher
    {
        private readonly FileSystemWatcher _watcher;
        private readonly ICalculateData _calculateData;
        private bool _enabled = true;
        private readonly string _outputPath = ConfigurationManager.AppSettings["FolderForOutput"];
        private readonly string _inputPath = ConfigurationManager.AppSettings["FolderToWatch"];

        public FileWatcher()
        {

        }

        public FileWatcher(ICalculateData calculateData)
        {
            _watcher = new FileSystemWatcher(_inputPath);
            _calculateData = calculateData;
            _watcher.Created += WatcherOnCreated;
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;

            while (_enabled)
            { 
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
            _enabled = false;
        }

        private void WatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            _calculateData.CalculateGenerationOutput(fileSystemEventArgs, ConfigurationManager.AppSettings["ReferenceData"], _outputPath);
        }
    }
}

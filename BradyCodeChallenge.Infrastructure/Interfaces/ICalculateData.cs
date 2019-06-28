using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BradyCodeChallenge.Infrastructure.Models.Input;
using BradyCodeChallenge.Infrastructure.Models.Output;

namespace BradyCodeChallenge.Infrastructure.Interfaces
{
    public interface ICalculateData
    {
        void CalculateGenerationOutput(FileSystemEventArgs fileSystemEventArgs, string referenceDataPath, string outputPath);
    }
}

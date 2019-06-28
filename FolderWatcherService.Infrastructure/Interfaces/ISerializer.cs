using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BradyCodeChallenge.Infrastructure.Interfaces
{
    public interface ISerializer
    {
         T Deserialize<T> (string input);

         string Serialize<T>(T objectToSerialize);

        void SerializeToFile<T>(T objectToSerialize, string outputPath);
    }
}

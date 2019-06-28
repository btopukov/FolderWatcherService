using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BradyCodeChallenge.Infrastructure.Models.Output
{
    [Serializable]
    public class Generator
    {
        public string Name { get; set; }

        public decimal Total { get; set; }
    }
}

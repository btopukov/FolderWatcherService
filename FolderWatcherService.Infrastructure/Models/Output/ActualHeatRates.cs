using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BradyCodeChallenge.Infrastructure.Models.Output
{
    [Serializable]
    public class ActualHeatRates
    {
        public string Name { get; set; }

        public decimal HeatRate { get; set; }
    }
}

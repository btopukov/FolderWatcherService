using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BradyCodeChallenge.Infrastructure.Models.ReferenceData
{
    [Serializable]
    public class EmissionsFactor
    {
        public decimal High { get; set; }

        public decimal Medium { get; set; }

        public decimal Low { get; set; }
    }
}

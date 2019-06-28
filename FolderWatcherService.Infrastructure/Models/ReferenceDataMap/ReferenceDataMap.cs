using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BradyCodeChallenge.Infrastructure.Models.ReferenceDataMap
{
    public class ReferenceDataMap
    {
        public string GeneratorType { get; set; }

        public EmissionFactor EmissionFactor { get; set; }

        public ValueFactor ValueFactor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BradyCodeChallenge.Infrastructure.Models.Input;

namespace BradyCodeChallenge.Infrastructure.Models.ReferenceData
{
    [Serializable]
    public class Factors
    {
        public Factors()
        {
            ValueFactor = new ValueFactor();
            EmissionsFactor = new EmissionsFactor();
        }

        [XmlElement("ValueFactor")]
        public ValueFactor ValueFactor { get; set; }

        [XmlElement("EmissionsFactor")]
        public EmissionsFactor EmissionsFactor { get; set; }
    }
}

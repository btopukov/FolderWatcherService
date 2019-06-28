using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BradyCodeChallenge.Infrastructure.Models.Input
{
    [Serializable]
    public class Coal
    {
        public Coal()
        {
            CoalGenerator = new List<CoalGenerator>();
        }

        [XmlElement("CoalGenerator")]
        public List<CoalGenerator> CoalGenerator { get; set; }
    }
}

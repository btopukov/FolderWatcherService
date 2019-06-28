using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BradyCodeChallenge.Infrastructure.Models.Input
{
    [Serializable]
    public class Gas
    {
        public Gas()
        {
            GasGenerator = new List<GasGenerator>();
        }

        [XmlElement("GasGenerator")]
        public List<GasGenerator> GasGenerator { get; set; }
    }
}

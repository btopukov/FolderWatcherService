using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BradyCodeChallenge.Infrastructure.Models.Input
{
    [Serializable]
    public class GasGenerator
    {
        public GasGenerator()
        {
            Generation = new Generation();
        }
        
        public string Name { get; set; }
        
        public decimal EmissionsRating { get; set; }

        [XmlElement("Generation")]
        public Generation Generation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BradyCodeChallenge.Infrastructure.Models.Input
{
    [Serializable]
    public class WindGenerator
    {
        public WindGenerator()
        {
           Generation = new Generation();
        }
        
        public string Name { get; set; }
        
        public string Location { get; set; }

        [XmlElement("Generation")]
        public Generation Generation { get; set; }
    }
}

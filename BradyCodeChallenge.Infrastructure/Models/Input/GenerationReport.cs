using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BradyCodeChallenge.Infrastructure.Models.Input
{
    [Serializable]
    [XmlRoot("GenerationReport")]
    public class GenerationReport
    {
        public GenerationReport()
        {
            Wind = new Wind();
            Gas = new Gas();
            Coal = new Coal();
        }

        [XmlElement("Wind")]
        public Wind Wind { get; set; }

        [XmlElement("Gas")]
        public Gas Gas { get; set; }

        [XmlElement("Coal")]
        public Coal Coal { get; set; }
    }
}

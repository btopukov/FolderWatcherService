using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BradyCodeChallenge.Infrastructure.Models.Input
{
    [Serializable]
    public class Wind
    {
        public Wind()
        {
            WindGenerator = new List<WindGenerator>();
        }

        [XmlElement("WindGenerator")]
        public List<WindGenerator> WindGenerator { get; set; }   
    }
}

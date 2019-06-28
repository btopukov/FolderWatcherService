using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BradyCodeChallenge.Infrastructure.Models.Input
{
    [Serializable]
    public class Generation
    {
        public Generation()
        {
            Day = new List<Day>();
        }

        [XmlElement("Day")]
        public List<Day> Day { get; set; }
    }
}

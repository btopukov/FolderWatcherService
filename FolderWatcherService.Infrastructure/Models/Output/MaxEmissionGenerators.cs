using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BradyCodeChallenge.Infrastructure.Models.Output
{
    [Serializable]
    public class MaxEmissionGenerators
    {
        public MaxEmissionGenerators()
        {
            Day = new List<Day>();
        }

        [XmlElement("Day")]
        public List<Day> Day { get; set; }
    }
}

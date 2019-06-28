using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BradyCodeChallenge.Infrastructure.Models.ReferenceData
{
    [Serializable]
    [XmlRoot("ReferenceData")]
    public class ReferenceData
    {
        public ReferenceData()
        {
            Factors = new Factors();
        }

        [XmlElement("Factors")]
        public Factors Factors { get; set; }
    }
}

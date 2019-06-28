using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BradyCodeChallenge.Infrastructure.Models.Output
{
    [Serializable]
    public class Totals
    {
        public Totals()
        {
            Generator = new List<Generator>();
        }

        [XmlElement("Generator")]
        public List<Generator> Generator { get; set; }
    }
}

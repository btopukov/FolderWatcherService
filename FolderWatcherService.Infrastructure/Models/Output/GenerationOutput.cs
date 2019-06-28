using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BradyCodeChallenge.Infrastructure.Models.Input;

namespace BradyCodeChallenge.Infrastructure.Models.Output
{
    [Serializable]
    [XmlRoot("GenerationOutput")]
    public class GenerationOutput
    {
        public GenerationOutput()
        {
            Totals = new Totals();
            MaxEmissionGenerators = new MaxEmissionGenerators();
            ActualHeatRates = new List<ActualHeatRates>();
        }

        [XmlElement("Totals")]
        public Totals Totals { get; set; }

        [XmlElement("MaxEmissionGenerators")]
        public MaxEmissionGenerators MaxEmissionGenerators { get; set; }

        [XmlElement("ActualHeatRates")]
        public List<ActualHeatRates> ActualHeatRates { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BradyCodeChallenge.Infrastructure.Models.ReferenceDataMap;

namespace BradyCodeChallenge.Service.StaticData
{
    public static class PopulateStaticData
    {

        //TODO refactor - put this in config file, xml file or database
        public static List<ReferenceDataMap> GeneratorTypesMapData()
        {
            List<ReferenceDataMap> referenceDataMaps = new List<ReferenceDataMap>();

            ReferenceDataMap offshoreWind = new ReferenceDataMap()
            {
                GeneratorType = "Wind[Offshore]",
                ValueFactor = ValueFactor.Low,
                EmissionFactor = EmissionFactor.NA
            };
            referenceDataMaps.Add(offshoreWind);

            ReferenceDataMap onshoreWind = new ReferenceDataMap()
            {
                GeneratorType = "Wind[Onshore]",
                ValueFactor = ValueFactor.High,
                EmissionFactor = EmissionFactor.NA
            };
            referenceDataMaps.Add(onshoreWind);

            ReferenceDataMap gasReferenceDataMap = new ReferenceDataMap()
            {
                GeneratorType = "Gas[1]",
                ValueFactor = ValueFactor.Medium,
                EmissionFactor = EmissionFactor.Medium
            };
            referenceDataMaps.Add(gasReferenceDataMap);

            ReferenceDataMap coalReferenceDataMap = new ReferenceDataMap()
            {
                GeneratorType = "Coal[1]",
                ValueFactor = ValueFactor.Medium,
                EmissionFactor = EmissionFactor.High
            };
            referenceDataMaps.Add(coalReferenceDataMap);

            return referenceDataMaps;
        }
    }
}

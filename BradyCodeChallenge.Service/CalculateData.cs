using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BradyCodeChallenge.Common.Serializer;
using BradyCodeChallenge.Infrastructure.Interfaces;
using BradyCodeChallenge.Infrastructure.Models.Input;
using BradyCodeChallenge.Infrastructure.Models.Output;
using BradyCodeChallenge.Infrastructure.Models.ReferenceData;
using BradyCodeChallenge.Infrastructure.Models.ReferenceDataMap;
using BradyCodeChallenge.Service.StaticData;
using Day = BradyCodeChallenge.Infrastructure.Models.Output.Day;
using ValueFactor = BradyCodeChallenge.Infrastructure.Models.ReferenceDataMap.ValueFactor;

namespace BradyCodeChallenge.Service
{
    public class CalculateData : ICalculateData
    {
        private const string FileName = "GenerationOutput";
        private const string Extension = ".xml";
        private readonly ISerializer _serializer;
        internal static List<Day> MaxEmissionsDays = new List<Day>();

        public CalculateData(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public void CalculateGenerationOutput(FileSystemEventArgs fileSystemEventArgs, string referenceDataPath, string outputPath)
        {
            try
            {
                var xmlInputData = File.ReadAllText(fileSystemEventArgs.FullPath);
                GenerationReport generationReport = _serializer.Deserialize<GenerationReport>(xmlInputData);

                var xmlReferenceData = File.ReadAllText(referenceDataPath);
                ReferenceData referenceData = _serializer.Deserialize<ReferenceData>(xmlReferenceData);

                var generationOutput = CalculateGenerationData(generationReport, referenceData);
                SaveOutputInFile(generationOutput, outputPath);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred when processing your request: {ex.Message}");
            }
        }

        private static GenerationOutput CalculateGenerationData(GenerationReport generationReport, ReferenceData referenceData)
        {
            Totals totals = new Totals();
            List<ActualHeatRates> actualHeatRates = new List<ActualHeatRates>();
            MaxEmissionGenerators maxEmissionGenerators = new MaxEmissionGenerators();

            foreach (var windGenerator in generationReport.Wind.WindGenerator)
            {
                var generator = new Generator
                {
                    Name = windGenerator.Name,
                    Total = CalculateTotalGenerationValue(windGenerator.Generation, windGenerator.Name, referenceData, null)
                };

                totals.Generator.Add(generator);
            }

            foreach (var coalGenerator in generationReport.Coal.CoalGenerator)
            {
                var generator = new Generator
                {
                    Name = coalGenerator.Name,
                    Total = CalculateTotalGenerationValue(coalGenerator.Generation, coalGenerator.Name, referenceData, coalGenerator.EmissionsRating)
                };

                var actualHeatRate = new ActualHeatRates
                {
                     Name = coalGenerator.Name,
                     HeatRate = coalGenerator.TotalHeatInput / coalGenerator.ActualNetGeneration
                };

                totals.Generator.Add(generator);
                actualHeatRates.Add(actualHeatRate);
            }

            foreach (var gasGenerator in generationReport.Gas.GasGenerator)
            {
                var generator = new Generator
                {
                    Name = gasGenerator.Name,
                    Total = CalculateTotalGenerationValue(gasGenerator.Generation, gasGenerator.Name, referenceData, gasGenerator.EmissionsRating)
                };

                totals.Generator.Add(generator);
            }
            
            maxEmissionGenerators.Day = MaxEmissionsDays.OrderByDescending(x => x.Emission).GroupBy(x => x.Date).Select(b => b.First()).ToList(); 

            return new GenerationOutput() {Totals = totals, ActualHeatRates = actualHeatRates, MaxEmissionGenerators = maxEmissionGenerators };
        }

        private static decimal CalculateTotalGenerationValue(Generation generation, string generationType, ReferenceData referenceData, decimal? emissions)
        {
            //TODO check if there are days
            List<ReferenceDataMap> referenceDataMap = PopulateStaticData.GeneratorTypesMapData();
            decimal calcForGeneration = 0;
            foreach (var day in generation.Day)
            {
                calcForGeneration += day.Energy * day.Price * GetValueFactor(generationType, referenceData, referenceDataMap);
                var dayForMaxEmission = new Day
                {
                    Date = day.Date,
                    Name = generationType,
                    Emission = CalculateEmission(day, generationType, referenceData, referenceDataMap, emissions) //TODO refactor this
                };

                MaxEmissionsDays.Add(dayForMaxEmission);
            }

            return calcForGeneration;
        }

        private static decimal CalculateEmission(Infrastructure.Models.Input.Day day, string generationType, ReferenceData referenceData, List<ReferenceDataMap> referenceDataMap, decimal? emissions)
        {
            decimal calcEmissions = 0;
            if (emissions.HasValue)
            {
                calcEmissions = day.Energy * GetEmissionFactor(generationType, referenceData, referenceDataMap) * emissions.Value;
            }

            return calcEmissions;
        }

        private static decimal GetEmissionFactor(string generationType, ReferenceData referenceData, List<ReferenceDataMap> referenceDataMap)
        {
            var emissionFactorMap = referenceDataMap.Where(x => x.GeneratorType == generationType).Select(a => a.EmissionFactor).FirstOrDefault();

            decimal emissionFactor = 0;

            if (emissionFactorMap == EmissionFactor.High)
            {
                emissionFactor = referenceData.Factors.ValueFactor.High;
            }
            else if (emissionFactorMap == EmissionFactor.Medium)
            {
                emissionFactor = referenceData.Factors.ValueFactor.Medium;
            }
            else if (emissionFactorMap == EmissionFactor.Low)
            {
                emissionFactor = referenceData.Factors.ValueFactor.Low;
            }

            //TODO complete this for NA

            return emissionFactor;
        }

        private static decimal GetValueFactor(string generationType, ReferenceData referenceData, List<ReferenceDataMap> referenceDataMap)
        {
            var valueFactorMap = referenceDataMap.Where(x => x.GeneratorType == generationType).Select(a => a.ValueFactor).FirstOrDefault();

            decimal valueFactor = 0;

            if (valueFactorMap == ValueFactor.High)
            {
                valueFactor = referenceData.Factors.ValueFactor.High;
            }
            else if(valueFactorMap == ValueFactor.Medium)
            {
                valueFactor = referenceData.Factors.ValueFactor.Medium;
            }
            else if (valueFactorMap == ValueFactor.Low)
            {
                valueFactor = referenceData.Factors.ValueFactor.Low;
            }

            //TODO complete this for NA

            return valueFactor;
        }

        private void SaveOutputInFile(GenerationOutput output, string outputPath)
        {
            var date = DateTime.Now;

            var outputPathName = $"{outputPath}{FileName}{date.ToShortDateString()}{date:HH.mm.ss}{Extension}";
            _serializer.SerializeToFile<GenerationOutput>(output, outputPathName);
        }
    }
} 

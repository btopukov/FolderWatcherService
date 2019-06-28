using System;

namespace BradyCodeChallenge.Infrastructure.Models.Output
{
    [Serializable]
    public class Day
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }
        
        public decimal Emission { get; set; }
    }
}

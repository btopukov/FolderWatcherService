using System;

namespace BradyCodeChallenge.Infrastructure.Models.Input
{
    [Serializable]
    public class Day
    {
        public DateTime Date { get; set; }
        
        public decimal Energy { get; set; }
        
        public decimal Price { get; set; }
    }
}

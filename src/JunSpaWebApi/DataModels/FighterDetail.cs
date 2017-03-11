using System.Collections.Generic;
using Newtonsoft.Json;

namespace JunSpaWebApi.DataModels
{
    public class FighterDetail
    {
        public double Striking { get; set; }
        public double Submissions { get; set; }
        public double Takedowns { get; set; }

        public string From { get; set; }
        public string FightsOutOf { get; set; }
        public int? Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string WeightClass { get; set; }

        //public IEnumerable<FightHistory> FightHistoryList { get; set; }
    }
}

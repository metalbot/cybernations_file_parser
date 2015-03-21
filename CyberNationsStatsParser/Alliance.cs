using System;
using System.Collections.Generic;

namespace CyberNationsStatsParser
{
    public class Alliance : CNBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Updated { get; set; }
        public int TotalNations { get; set; }
        public int ActiveNations { get; set; }
        public float PercentActive { get; set; }
        public float Strength { get; set; }
        public float AverageStrength { get; set; }
        public float Score { get; set; }
        public float Land { get; set; }
        public float Infrastructure { get; set; }
        public float Technology { get; set; }
        public int War { get; set; }
        public int Peace { get; set; }
        public int Soldiers { get; set; }
        public int Tanks { get; set; }
        public int Cruise { get; set; }
        public int Nukes { get; set; }
        public int Aircraft { get; set; }
        public int Navy { get; set; }
        public int Anarchy { get; set; }


        // Maps from CN Export column name to internal name
        public override Dictionary<string,string> CNColumnMapper()
        {
            return new Dictionary<string, string>
            {
                { "AllianceID", "Id"},
                { "Alliance", "Name" }
            };
        }
    }
}

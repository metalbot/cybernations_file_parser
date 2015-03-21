using System;
using System.Collections.Generic;

namespace CyberNationsStatsParser
{

    public class NationRecord : CNBase
    {
        public int Id { get; set; }
        public string RulerName { get; set; }
        public string NationName { get; set; }
        public string Alliance { get; set; }
        public int AllianceId { get; set; }
        public DateTime AllianceDate { get; set; }
        public string AllianceStatus { get; set; }
        public string GovernmentType { get; set; }
        public string Religion { get; set; }
        public string Team { get; set; }
        public DateTime Created { get; set; }
        public float Technology { get; set; }
        public float Infrastructure { get; set; }
        public float BaseLand { get; set; }
        public string WarStatus { get; set; }
        public string Resource1 { get; set; }
        public string Resource2 { get; set; }
        public int Votes { get; set; }
        public float Strength { get; set; }
        public int DEFCON { get; set; }
        public int BaseSoldiers { get; set; }
        public int Tanks { get; set; }
        public int Cruise { get; set; }
        public int Nukes { get; set; }

        public override Dictionary<string, string> CNColumnMapper()
        {
            return new Dictionary<string, string>
            {
                { "NationID", "Id"},
                { "AllianceID", "AllianceId" }
            };
        }
    }
}

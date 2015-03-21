using System;
using System.Collections.Generic;

namespace CyberNationsStatsParser
{
    class War : CNBase
    {
        public int Id { get; set; }
        public int DeclaringId { get; set; }
        public string DeclaringRuler { get; set; }
        public string DeclaringNation { get; set; }
        public string DeclaringAlliance { get; set; }
        public int DeclaringAllianceId { get; set; }
        public string DeclaringTeam { get; set; }
        public int ReceivingId { get; set; }
        public string ReceivingRuler { get; set; }
        public string ReceivingNation { get; set; }
        public string ReceivingAlliance { get; set; }
        public int ReceivingAllianceId { get; set; }
        public string ReceivingTeam { get; set; }
        public string WarStatus { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public float Destruction { get; set; }
        public int AttackPercent { get; set; }
        public int DefendPercent { get; set; }


        // Maps from CN Export column name to internal name
        public override Dictionary<string, string> CNColumnMapper()
        {
            return new Dictionary<string, string>
            {
                { "DeclaringID", "DeclaringId"},
                { "DeclaringAllianceID", "DeclaringAllianceId" },
                { "ReceivingID", "ReceivingId"},
                { "ReceivingAllianceID", "ReceivingAllianceId" },
                { "WarID", "Id"}
            };
        }

    }
}

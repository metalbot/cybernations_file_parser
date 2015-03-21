using System;
using System.Collections.Generic;

namespace CyberNationsStatsParser
{
    class ForeignAid : CNBase
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
        public string Status { get; set; }
        public int Money { get; set; }
        public int Technology { get; set; }
        public int Soldiers { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }


        // Maps from CN Export column name to internal name
        public override Dictionary<string, string> CNColumnMapper()
        {
            return new Dictionary<string, string>
            {
                { "DeclaringID", "DeclaringId"},
                { "DeclaringAllianceID", "DeclaringAllianceId" },
                { "ReceivingID", "ReceivingId"},
                { "ReceivingAllianceID", "ReceivingAllianceId" },
                { "AidID", "Id"}
            };
        }
    }
}

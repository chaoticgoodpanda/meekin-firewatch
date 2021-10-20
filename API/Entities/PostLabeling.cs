using System;

namespace DefaultNamespace
{
    public class PostLabeling
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        
        // country for Rabat analysis
        public string RabatCountry { get; set; }
        
        // speaker status for Rabat analysis
        public string RabatSpeakerStatus { get; set; }
        
        // content of speech for Rabat analysis
        public string RabatContentandForm { get; set; }
        
        // virality for Rabat analysis
        public long RabatVirality { get; set; }
        
        // Rabat intent
        public string RabatIntent { get; set; }

        // Rabat likelihood of harm
        public string RabatLikelihoodHarm { get; set; }
        public string Language { get; set; }
        
        // boolean for whether user has marked speech as offensive or not
        public bool OffensiveContent { get; set; }
        
        // whether or not human target to speech
        public bool HumanTarget { get; set; }
        public string FacebookDecision { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DecisionDate { get; set; }
        public DateTime? AccessTime { get; set; }
        
        
        

        public string AnalysisReport { get; set; }
        public string SummaryAnalysis { get; set; }
        public DateTime? AnalysisDate { get; set; }
    }
}
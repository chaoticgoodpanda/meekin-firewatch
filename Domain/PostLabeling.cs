using System;
using Domain.PostAggregate;

namespace Domain
{
    public class PostLabeling
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        
        // country for Rabat analysis
        public RabatCountry Country { get; set; }
        
        // speaker status for Rabat analysis
        public RabatSpeaker Speaker { get; set; }
        
        // content of speech for Rabat analysis
        public RabatOffensive Offensive { get; set; }

        // content that is dangerous and increases likelihood of violence against target
        // needs to be included with other Rabat factors in analysis
        public bool? IsDangerous {get; set;}

        // argument put forth by content as to why to engage in violence
        public RabatJustifications? Justifications {get; set;}
        
        // virality for Rabat analysis
        public long RabatVirality { get; set; }
        
        // Rabat intent
        public RabatIntent? Intent { get; set; }

        // Rabat likelihood of harm, probably a double ranging from -1 to 1, or -100 to 100, or 1 to 10
        public double RabatLikelihoodHarm { get; set; }
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
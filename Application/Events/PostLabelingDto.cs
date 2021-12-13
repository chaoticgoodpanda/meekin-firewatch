using System;
using System.Collections.Generic;
using Application.Profiles;
using Domain.PostAggregate;

namespace Application.Events
{
    public class PostLabelingDto
    {
        public Guid Id { get; set; }
        public string OrganizationId { get; set; }
        public string UserId { get; set; }
        // the Facebook post ID matching the report (or other platform ID, such as Twitter or TikTok)
        public string platformId { get; set; }
        
        // the GUID of the Facebook post matching the report
        public Guid FacebookGuid { get; set; }
        
        // country for Rabat analysis
        public string Country { get; set; }
        
        // speaker status for Rabat analysis
        public string Speaker { get; set; }
        
        // content of speech for Rabat analysis
        public string SpeechContent { get; set; }

        // argument put forth by content as to why to engage in violence
        public string[] Justifications {get; set;}

        // Rabat intent
        public RabatIntent? Intent { get; set; }

        // danger score is deduced from this value
        // Rabat likelihood of harm, probably a double ranging from -1 to 1, or -100 to 100, or 1 to 10
        public double RabatLikelihoodHarm { get; set; }
        public string Language { get; set; }

        // whether or not human target to speech
        public bool HumanTarget { get; set; }
        public string FacebookDecision { get; set; }
        public string CreatedDate { get; set; }
        public string DecisionDate { get; set; }




        public string AnalysisReport { get; set; }
        public string SummaryAnalysis { get; set; }
        public string AnalysisDate { get; set; }
        
        public string OriginalPostUrl { get; set; }
        
        public string AuthorUsername { get; set; }
        
        public ICollection<Profile> Reporters { get; set; }
    }
}
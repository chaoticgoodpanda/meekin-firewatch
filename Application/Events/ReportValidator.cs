using Domain;
using FluentValidation;

namespace Application.Events
{
    public class ReportValidator : AbstractValidator<PostLabeling>
    {
        public ReportValidator()
        {
            RuleFor(x => x.SummaryAnalysis).NotEmpty();
            RuleFor(x => x.AnalysisDate).NotEmpty();
            RuleFor(x => x.AnalysisReport).NotEmpty();
            // RuleFor(x => x.HumanTarget).NotEmpty();
        }
    }
}
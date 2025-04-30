using DigiLean.Api.Model.Common;

namespace DigiLean.Api.Model.V1.Improvements
{
    public class ImprovementsPagedValues : PagedValues<Improvement>
    {
    }

    public class Improvement
    {
        public int Id { get; set; }
        public ImprovementStatus Status { get; set; }
        public int PriorityStatus { get; set; }
        public int? GroupId { get; set; }
        public string? Group { get; set; }
        public string? Text { get; set; }
        public string? Title { get; set; }
        public int? CategoryId { get; set; }
        public string? Category { get; set; }
        public int? ProjectId { get; set; }
        public string? Project { get; set; }
        
        public DateTime LastModified { get; set; }
        public string? SuggestedByUserId { get; set; }
        public string? SuggestedBy { get; set; }
        public DateTime? SuggestionDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PlannedDate { get; set; }
        public DateTime? InProgressDate { get; set; }
        public DateTime? ImplementedDate { get; set; }
        public DateTime? EvaluatedDate { get; set; }
        public DateTime? ArchivedDate { get; set; }

        public string? ResponsibleUserId { get; set; }
        public string? ResponsibleUser { get; set; }
        public string? ResponsibleDisplayName { get; set; }

        public int AttachmentCount { get; set; }
        public int ActionListCount { get; set; }
        
        public int CommentCount { get; set; }
        public int LikeCount { get; set; }
        public string? ExternalId { get; set; }

        public double? CostOfInvestment { get; set; }
        public double? GainOfInvestment { get; set; }
        public double? CostOfInvestmentHours { get; set; }
        public double? GainOfInvestmentHours { get; set; }
        public double? EstimatedCostOfInvestment { get; set; }
        public double? EstimatedGainOfInvestment { get; set; }
        public double? EstimatedCostOfInvestmentHours { get; set; }
        public double? EstimatedGainOfInvestmentHours { get; set; }

        public ImprovementEvaluation? EvaluationStatus { get; set; }
        public string? EvaluationText { get; set; }
    }
}

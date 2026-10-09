
using System.ComponentModel.DataAnnotations;

namespace SmartWorkflowAutomation.API.Models
{
    public class CreateAutomationRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(TaskSubmitted)$",
            ErrorMessage = "TriggerType must be TaskSubmitted.")]
        public string TriggerType { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(Priority|Category)$",
            ErrorMessage = "ConditionField must be Priority or Category.")]
        public string ConditionField { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(Equals|NotEquals)$",
            ErrorMessage = "Operator must be Equals or NotEquals.")]
        public string Operator { get; set; } = string.Empty;

        [Required]
        public string ConditionValue { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(SetUrgent|RequireReview|SendEmail)$",
            ErrorMessage = "ActionType is not supported.")]
        public string ActionType { get; set; } = string.Empty;
    }
}

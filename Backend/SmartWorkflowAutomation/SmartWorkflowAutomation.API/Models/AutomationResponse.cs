
namespace SmartWorkflowAutomation.API.Models
{
    public class AutomationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TriggerType { get; set; } = string.Empty;
        public string ConditionField { get; set; } = string.Empty;
        public string Operator { get; set; } = string.Empty;
        public string ConditionValue { get; set; } = string.Empty;
        public string ActionType { get; set; } = string.Empty;
        public bool IsEnabled { get; set; }
    }
}

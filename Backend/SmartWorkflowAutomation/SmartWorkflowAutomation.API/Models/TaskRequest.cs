
using System.ComponentModel.DataAnnotations;

namespace SmartWorkflowAutomation.API.Models
{
    public class TaskRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Priority { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;
    }
}

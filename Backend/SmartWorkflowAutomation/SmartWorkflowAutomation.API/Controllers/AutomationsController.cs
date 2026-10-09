using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartWorkflowAutomation.API.Models;
using System.Xml.Linq;

namespace SmartWorkflowAutomation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomationsController : ControllerBase
    {

        private static readonly List<AutomationResponse> automations =
            new List<AutomationResponse>()
        {
    new AutomationResponse
    {
        Id = Guid.NewGuid(),
        Name = "Urgent High Priority Tasks",
        TriggerType = "TaskSubmitted",
        ConditionField = "Priority",
        Operator = "Equals",
        ConditionValue = "High",
        ActionType = "SetUrgent",
        IsEnabled = true
    },

    new AutomationResponse
    {
        Id = Guid.NewGuid(),
        Name = "Review Finance Tasks",
        TriggerType = "TaskSubmitted",
        ConditionField = "Category",
        Operator = "Equals",
        ConditionValue = "Finance",
        ActionType = "RequireReview",
        IsEnabled = true
    }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(automations);
        }
        [HttpPost]
        public IActionResult Post([FromBody] CreateAutomationRequest request)
        {
            var automation = new AutomationResponse
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                TriggerType = request.TriggerType,
                ConditionField = request.ConditionField,
                Operator = request.Operator,
                ConditionValue = request.ConditionValue,
                ActionType = request.ActionType,
                IsEnabled = true
            };
            automations.Add(automation);
            return StatusCode(201, automation);
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var response = automations.FirstOrDefault(x => x.Id == id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost("evaluate")]
        public IActionResult EvaluateTask([FromBody] TaskRequest request)
        {
            var matchingAutomations = automations
                .Where(a => a.IsEnabled)
                .Where(a =>
                    a.TriggerType == "TaskSubmitted" &&
                    (
                        (a.ConditionField == "Priority" &&
                         (a.Operator == "Equals" ? a.ConditionValue == request.Priority: a.ConditionValue != request.Priority))
                        ||
                        (a.ConditionField == "Category" &&
                         (a.Operator == "Equals" ? a.ConditionValue == request.Category : a.ConditionValue != request.Category))
                    ))
                .Select(a => new {a.Id, a.Name, a.ActionType}).ToList();

            return Ok(new { TaskTitle = request.Title,MatchingAutomations = matchingAutomations});
        }

    }
}

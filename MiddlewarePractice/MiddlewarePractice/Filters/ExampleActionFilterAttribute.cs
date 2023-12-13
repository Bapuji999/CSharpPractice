using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MiddlewarePractice.Filters
{
    public class ExampleActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var startTimeMessage = $"Execution started at {DateTime.Now} This Message is from OnActionExecuting";
            var newContent = startTimeMessage;
            context.ActionArguments["newContent"] = newContent;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var originalContent = (context.Result as ObjectResult)?.Value?.ToString();
            var timeNow = DateTime.Now;
            while(DateTime.Now < timeNow.AddSeconds(1)) { }
            var newContent = $"{originalContent} \nIt's a {context.HttpContext.Request.Method} Method for Example of OnActionExecuted. {DateTime.Now}";
            context.Result = new OkObjectResult(newContent);
        }
    }
}

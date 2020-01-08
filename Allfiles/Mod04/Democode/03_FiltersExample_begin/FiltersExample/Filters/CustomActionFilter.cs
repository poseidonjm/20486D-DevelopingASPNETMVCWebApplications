using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersExample.Filters
{
    public class CustomActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string action = context.ActionDescriptor.RouteValues["action"];
            Debug.WriteLine(">> "+action+ " started, OnActionExecuting");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string action = context.ActionDescriptor.RouteValues["action"];
            Debug.WriteLine(">> " + action + " finished, OnActionExecuted");
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            string action = context.ActionDescriptor.RouteValues["action"];
            Debug.WriteLine(">> " + action + " before result, OnResultExecuting");
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            string action = context.ActionDescriptor.RouteValues["action"];
            ContentResult result = (ContentResult)context.Result;
            Debug.WriteLine(">> " + action + " after result: "+result.Content+", OnResultExecuted");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WorldJourney.Filters
{
    public class LogActionFilterAttribute: ActionFilterAttribute
    {
        private IHostingEnvironment _environment;
        private string _contentRootPath;
        private string _logPath;
        private string _fileName;
        private string _fullPath;

        public LogActionFilterAttribute(IHostingEnvironment environment)
        {
            _environment = environment;
            _contentRootPath = _environment.ContentRootPath;
            _logPath = _contentRootPath + "\\LogFile\\";
            _fileName = $"log {DateTime.Now.ToString("MM-dd-yyyy-H-mm")}.txt";
            _fullPath = _logPath + _fileName;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Directory.CreateDirectory(_logPath);
            string action = context.ActionDescriptor.RouteValues["action"];
            string controller = context.ActionDescriptor.RouteValues["controller"];
            using (FileStream f = new FileStream(_fullPath, FileMode.Create))
            {
                using (StreamWriter s = new StreamWriter(f))
                {
                    s.WriteLine($"Action {action} in {controller}, OnActionExecuting");
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string action = context.ActionDescriptor.RouteValues["action"];
            string controller = context.ActionDescriptor.RouteValues["controller"];
            using (FileStream f = new FileStream(_fullPath, FileMode.Append))
            {
                using (StreamWriter s = new StreamWriter(f))
                {
                    s.WriteLine($"Action {action} in {controller}, OnActionExecuted");
                }
            }

        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            string action = context.ActionDescriptor.RouteValues["action"];
            string controller = context.ActionDescriptor.RouteValues["controller"];
            ViewResult result = (ViewResult)context.Result;
            using (FileStream f = new FileStream(_fullPath, FileMode.Append))
            {
                using (StreamWriter s = new StreamWriter(f))
                {
                    s.WriteLine($"Action {action} in {controller}, result {result.ViewData.Values.FirstOrDefault()}, OnResultExecuted");
                }
            }
        }

    }
}

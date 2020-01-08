using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoutesExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id = 50)
        {
            return Content("Home with default param: "+id);
        }

        [Route("Hello/{firstName}/{lastName}")]
        public IActionResult Greeting(string firstName, string lastName)
        {
            return Content($"Hello {firstName} {lastName} from Home");
        }
    }
}
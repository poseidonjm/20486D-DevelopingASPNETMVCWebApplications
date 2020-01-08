using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using WorldJourney.Models;
using WorldJourney.Filters;

namespace WorldJourney.Controllers
{
    public class CityController : Controller
    {
        private IData _data;
        private IHostingEnvironment _environment;

        public CityController(IData data, IHostingEnvironment environment)
        {
            _data = data;
            _environment = environment;
            _data.CityInitializeData();
        }

        [ServiceFilter(typeof(LogActionFilterAttribute))]
        [Route("WorldJourney")]
        public IActionResult Index()
        {
            ViewData["Page"] = "Search City";
            return View();
        }

        [Route("CityDetails/{id?}")]
        public IActionResult Details(int? id)
        {
            ViewData["Page"] = "Selected City";
            City city = _data.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewBag.Title = city.CityName;
            return View(city);
        }

        public IActionResult GetImage(int? cityId)
        {
            ViewData["Message"] = "Display image";
            City city = _data.GetCityById(cityId);
            if (city != null)
            {
                string webRoot = _environment.WebRootPath;
                string folder = "\\images\\";
                string fullPath = webRoot + folder + city.ImageName;
                FileStream file = new FileStream(fullPath, FileMode.Open);
                byte[] bytes;
                using (BinaryReader b = new BinaryReader(file))
                {
                    bytes = b.ReadBytes((int)file.Length);
                }
                return File(bytes, city.ImageMimeType);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
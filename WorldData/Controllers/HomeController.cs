using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace WorldData.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            
            List<City> cityList = City.GetAll();
            return View(cityList);
        }
    }
}

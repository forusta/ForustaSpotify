using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForustaSpotify.Api.Controllers.Mvc.Main
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

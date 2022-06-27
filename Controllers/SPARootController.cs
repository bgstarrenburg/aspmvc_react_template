using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace web_react_mvc.Controllers
{
    public class SPARootController : Controller
    {

        public SPARootController() { }

        public IActionResult Index()
        {
            ViewData["Title"] = "My SPA App";
            return View();
        }
    }
}

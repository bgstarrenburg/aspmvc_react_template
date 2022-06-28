using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace aspmvc_react.Controllers
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

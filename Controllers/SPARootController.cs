using Microsoft.AspNetCore.Mvc;

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

using aspmvc_react.Models;
using aspmvc_react.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace aspmvc_react.Controllers
{
  [Route("api/user")]
  public class UserController : Controller
  {
    private DBContextModel context { get; set; }
    private UserService userService { get; }
    public UserController(DBContextModel context, UserService userService)
    {
      this.context = context;
      this.userService = userService;
    }

    // [ValidateAntiForgeryToken]
    [HttpPost("registration")]
    public async Task<IActionResult> Registration([FromBody] RegistrationRequest request)
    {
      try
      {
        if (!ModelState.IsValid) return BadRequest();

        var createdUser = await userService.CreateUser(request);
        if (createdUser != null) return BadRequest();
        return Ok(createdUser);
      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        return BadRequest();
      }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
      try
      {
        if (!ModelState.IsValid) return BadRequest();

        var loginUser = userService.LoginUser(request);
        if (loginUser == null) return BadRequest();
        return Ok(loginUser);
      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        return BadRequest();
      }
    }
  }
}

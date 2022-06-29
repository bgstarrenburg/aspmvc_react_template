using aspmvc_react.Models;
using aspmvc_react.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace aspmvc_react.Controllers
{
  [ValidateAntiForgeryToken]
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

    [HttpPost("registration")]
    public async Task<IActionResult> Registration([FromBody] RegistrationRequest request)
    {
      try
      {
        if (!ModelState.IsValid) return BadRequest();

        var user = await userService.CreateUser(request);
        if (user == null) return BadRequest();
        return Ok(new UserResponse() { Id = user.Id, EmailAdress = user.EmailAdress, UserName = user.UserName });
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

        var user = userService.LoginUser(request);
        if (user == null) return BadRequest();
        return Ok(new UserResponse() { Id = user.Id, EmailAdress = user.EmailAdress, UserName = user.UserName });
      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        return BadRequest();
      }
    }
  }
}

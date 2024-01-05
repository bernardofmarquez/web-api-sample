using Microsoft.AspNetCore.Mvc;
using WebApiSample.Service;
using WebApiSample.ViewModel;
using WebApiSample.Model;

namespace WebApiSample.Controller {
  [ApiController]
  [Route("api/v1/auth")]
  public class AuthController : ControllerBase {

    private readonly AuthService _authService;

    public AuthController(AuthService autService) {
      _authService = autService ?? throw new ArgumentNullException();
    }

    [HttpPost]
    public IActionResult SignIn(UserView userView) {
      try {
        User user = _authService.AuthenticateUser(userView);
        return Ok(user);
      } catch (UserDoesNotExist ex) {
        return NotFound(ex.Message);
      } catch (IncorrectPassword ex) {
        return Unauthorized(ex.Message);
      }
    }

    [HttpPost]
    public IActionResult SignUp(UserView userView) {
      try {
        _authService.RegisterUser(userView);
        return Ok();
      } catch (UserAlreadyExists ex) {
        return Conflict(ex.Message);
      }
    }

  }
}
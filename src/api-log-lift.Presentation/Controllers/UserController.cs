using api_log_lift.Application.Commands;
using api_log_lift.Presentation.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Controllers;

[ApiController]
[Route("auth")]
public class UserController : ControllerBase, IUserController
{
  private readonly ISender _sender;

  public UserController(ISender sender)
  {
    _sender = sender;
  }

  [HttpPost("login")]
  public async Task<ActionResult> Login(UserLoginCommand command)
  {
    await _sender.Send(command);
    return Ok("user logged successfully");
  }

  [HttpPost("register")]
  public async Task<ActionResult> Register(UserRegisterCommand command)
  {
    await _sender.Send(command);
    return Ok("user registered successfully");
  }
}
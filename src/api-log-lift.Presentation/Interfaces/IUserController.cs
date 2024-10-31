using api_log_lift.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Interfaces;

public interface IUserController
{
  Task<ActionResult> Login(UserLoginCommand command);
  Task<ActionResult> Register(UserRegisterCommand command);
}
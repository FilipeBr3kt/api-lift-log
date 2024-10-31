using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Exceptions;
using api_log_lift.Domain.Interfaces;
using MediatR;

namespace api_log_lift.Application.Commands;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, bool>
{
  private readonly IUserRepository _repository;

  public UserLoginCommandHandler(IUserRepository repository)
  {
    _repository = repository;
  }

  public async Task<bool> Handle(UserLoginCommand request, CancellationToken cancellationToken)
  {
    var user = new User(request.Username, request.Password);
    var userExists = await _repository.FindUserByName(user.Username, cancellationToken);

    if (userExists == null)
    {
      throw new NotFoundException("User not found");
    }

    var isValidPassword = user.VerifyPassword(user.Password, userExists.Password);
    if (isValidPassword is false)
    {
      throw new InvalidCredentialsException("Invalid password");
    }

    return true;
  }
}
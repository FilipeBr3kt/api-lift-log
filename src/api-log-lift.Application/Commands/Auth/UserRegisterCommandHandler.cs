using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Exceptions;
using api_log_lift.Domain.Interfaces;
using MediatR;

namespace api_log_lift.Application.Commands;

public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, bool>
{
  private readonly IUserRepository _repository;

  public UserRegisterCommandHandler(IUserRepository repository)
  {
    _repository = repository;
  }

  public async Task<bool> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
  {
    var userExist = await _repository.FindUserByName(request.Name, cancellationToken);

    if (userExist is not null)
    {
      throw new ConflictException("User already exists");
    }

    var user = new User(request.Name, request.Password, request.ConfirmPassword);

    return await _repository.SaveUser(user, cancellationToken);
  }
}
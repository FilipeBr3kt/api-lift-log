using MediatR;

namespace api_log_lift.Application.Commands;

public record UserRegisterCommand(string Name, string Password, string ConfirmPassword) : IRequest<bool>;
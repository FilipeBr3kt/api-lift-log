using api_log_lift.Domain.Entities;
using MediatR;

namespace api_log_lift.Application.Commands;

public record UserLoginCommand(string Username, string Password) : IRequest<bool>;
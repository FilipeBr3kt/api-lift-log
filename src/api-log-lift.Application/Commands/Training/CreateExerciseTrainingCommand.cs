using MediatR;

namespace api_log_lift.Application.Commands;

public record CreateTrainingCommand(string Name, int UserId) : IRequest<bool>;
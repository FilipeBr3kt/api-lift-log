using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;
using MediatR;

namespace api_log_lift.Application.Queries;

public record GetTrainingByIdQuery(int Id) : IRequest<TrainingResponse>;
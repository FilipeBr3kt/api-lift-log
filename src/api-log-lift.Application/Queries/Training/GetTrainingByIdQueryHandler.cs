using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Exceptions;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Domain.Responses;
using MediatR;

namespace api_log_lift.Application.Queries;

public class GetTrainingByIdQueryHandler : IRequestHandler<GetTrainingByIdQuery, TrainingResponse>
{
  private readonly ITrainingRepository _repository;

  public GetTrainingByIdQueryHandler(ITrainingRepository repository)
  {
    _repository = repository;
  }

  public async Task<TrainingResponse> Handle(GetTrainingByIdQuery request, CancellationToken cancellationToken)
  {
    var trainingExist = await _repository.GetTrainingById(request.Id, cancellationToken)
      ?? throw new NotFoundException("Training not found");

    return new TrainingResponse
    (
      trainingExist.Id,
      trainingExist.Name,
      trainingExist.DateRegister,
      trainingExist.UserId
    );
  }
}
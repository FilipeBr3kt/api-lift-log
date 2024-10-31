using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Exceptions;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Domain.Responses;
using MediatR;

namespace api_log_lift.Application.Queries;

public class GetTrainingExerciseByTrainingIdQueryHandler : IRequestHandler<GetTrainingExerciseByTrainingIdQuery, IEnumerable<TrainingExerciseResponse>>
{
  private readonly ITrainingExerciseRepository _repository;

  public GetTrainingExerciseByTrainingIdQueryHandler(ITrainingExerciseRepository repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<TrainingExerciseResponse>> Handle(GetTrainingExerciseByTrainingIdQuery request, CancellationToken cancellationToken)
  {
    var response = await _repository.GetByTrainingId(request.TrainingId, cancellationToken)
      ?? throw new NotFoundException("Exercises not found");

    return response!;
  }
}
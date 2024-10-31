using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Domain.Responses;
using MediatR;

namespace api_log_lift.Application.Queries;

public class GetExerciseByMuscleGroupIdQueryHandler : IRequestHandler<GetExerciseByMuscleGroupIdQuery, IEnumerable<ExerciseResponse>>
{
  private readonly IExerciseRepository _repository;

  public GetExerciseByMuscleGroupIdQueryHandler(IExerciseRepository repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<ExerciseResponse>> Handle(GetExerciseByMuscleGroupIdQuery request, CancellationToken cancellationToken)
  {
    return await _repository.GetExerciseByMuscleId(request.MuscleGroupId, cancellationToken);
  }
}
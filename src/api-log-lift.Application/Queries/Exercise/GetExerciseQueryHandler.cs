using api_log_lift.Domain.Interfaces;
using api_log_lift.Domain.Responses;
using MediatR;

namespace api_log_lift.Application.Queries;

public class GetExerciseQueryHandler : IRequestHandler<GetExerciseQuery, IEnumerable<ExerciseResponse>>
{
  private readonly IExerciseRepository _exerciseRepository;

  public GetExerciseQueryHandler(IExerciseRepository exerciseRepository)
  {
    _exerciseRepository = exerciseRepository;
  }

  public async Task<IEnumerable<ExerciseResponse>> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
  {
    var result = await _exerciseRepository.GetAllExercises(cancellationToken);

    return result.Select(exercise => new ExerciseResponse
    (
      exercise.Id,
      exercise.Name,
      exercise.MuscleId,
      exercise.Muscle.Name
    ));
  }
}
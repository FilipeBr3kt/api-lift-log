using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;

namespace api_log_lift.Domain.Interfaces;

public interface IExerciseRepository
{
  Task<IEnumerable<ExerciseResponse>> GetAllExercises(CancellationToken cancellationToken);
  Task<ExerciseResponse?> GetExerciseById(int id, CancellationToken cancellationToken);
  Task<IEnumerable<ExerciseResponse>> GetExerciseByMuscleId(int muscleGroupId, CancellationToken cancellationToken);
}
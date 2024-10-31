using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;

namespace api_log_lift.Domain.Interfaces;

public interface IExerciseRepository
{
  Task<IEnumerable<Exercise>> GetAllExercises(CancellationToken cancellationToken);
  Task<Exercise?> GetExerciseById(int id, CancellationToken cancellationToken);
  Task<IEnumerable<Exercise>> GetExerciseByMuscleId(int muscleGroupId, CancellationToken cancellationToken);
}
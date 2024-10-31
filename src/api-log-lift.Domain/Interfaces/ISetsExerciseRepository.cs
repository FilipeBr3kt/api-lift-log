using api_log_lift.Domain.Entities;

namespace api_log_lift.Domain.Interfaces;

public interface ISetsExerciseRepository
{
  Task<bool> Save(SetsExercise setsExercise, CancellationToken cancellationToken);
  Task<SetsExercise?> GetById(int id, CancellationToken cancellationToken);
}
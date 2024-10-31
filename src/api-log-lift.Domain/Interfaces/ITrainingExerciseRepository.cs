using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;

namespace api_log_lift.Domain.Interfaces;

public interface ITrainingExerciseRepository
{
  Task<IEnumerable<TrainingExerciseResponse?>> GetByTrainingId(int trainingId, CancellationToken cancellationToken);
  Task<bool> Save(TrainingExercise trainingExercise, CancellationToken cancellationToken);
}
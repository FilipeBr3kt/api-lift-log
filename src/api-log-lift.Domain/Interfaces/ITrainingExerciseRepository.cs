using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;

namespace api_log_lift.Domain.Interfaces;

public interface ITrainingExerciseRepository
{
  Task<IEnumerable<TrainingExercise?>> GetByTrainingId(int trainingId, CancellationToken cancellationToken);
  Task<IEnumerable<TrainingExercise?>> GetById(int id, CancellationToken cancellationToken);
  Task<bool> Save(TrainingExercise trainingExercise, CancellationToken cancellationToken);
}
using api_log_lift.Domain.Entities;

namespace api_log_lift.Domain.Interfaces;

public interface ITrainingRepository
{
  Task<bool> SaveTraining(Training training, CancellationToken cancellationToken);
  Task<IEnumerable<Training>> GetTrainingsByUserId(int userId, CancellationToken cancellationToken);
  Task<Training?> GetTrainingById(int id, CancellationToken cancellationToken);
  Task<Training?> FindTrainingInUserId(string name, int userId, CancellationToken cancellationToken);
}
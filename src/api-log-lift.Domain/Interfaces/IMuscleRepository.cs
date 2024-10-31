using api_log_lift.Domain.Entities;

namespace api_log_lift.Domain.Interfaces;

public interface IMuscleRepository
{
  Task<IEnumerable<Muscle>> GetAll(CancellationToken cancellationToken);
  Task<Muscle?> GetById(int id, CancellationToken cancellationToken);
}
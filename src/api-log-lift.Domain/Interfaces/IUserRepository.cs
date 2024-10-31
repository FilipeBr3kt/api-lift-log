using api_log_lift.Domain.Entities;

namespace api_log_lift.Domain.Interfaces;

public interface IUserRepository
{
  Task<bool> SaveUser(User user, CancellationToken cancellationToken);
  Task<User?> FindUserByName(string name, CancellationToken cancellationToken);
  Task<User?> FindUserById(int id, CancellationToken cancellationToken);
  // Task<bool> DeleteUserAsync(User user, CancellationToken cancellationToken);
}
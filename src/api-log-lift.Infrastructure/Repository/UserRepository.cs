using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Exceptions;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace api_log_lift.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
  private readonly DatabaseContext _context;

  public UserRepository(DatabaseContext context)
  {
    _context = context;
  }

  public async Task<User?> FindUserById(int id, CancellationToken cancellationToken)
  {
    return await _context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
  }

  public async Task<User?> FindUserByName(string name, CancellationToken cancellationToken)
  {
    var result = await _context.Users.FirstOrDefaultAsync(u => u.Username == name, cancellationToken);
    return result;
  }

  public async Task<bool> SaveUser(User user, CancellationToken cancellationToken)
  {
    await _context.Users.AddAsync(user, cancellationToken);
    return await _context.SaveChangesAsync(cancellationToken) > 0;
  }
}
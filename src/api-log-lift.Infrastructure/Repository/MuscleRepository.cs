using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Exceptions;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace api_log_lift.Infrastructure.Repository;

public class MuscleRepository : IMuscleRepository
{
  private readonly DatabaseContext _dbContext;

  public MuscleRepository(DatabaseContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<IEnumerable<Muscle>> GetAll(CancellationToken cancellationToken)
  {
    return await _dbContext.Muscles.ToListAsync(cancellationToken);
  }

  public async Task<Muscle?> GetById(int id, CancellationToken cancellationToken)
  {
    return await _dbContext.Muscles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
  }
}
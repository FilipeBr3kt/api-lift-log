using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace api_log_lift.Infrastructure.Repository;

public class TrainingRepository : ITrainingRepository
{
  private readonly DatabaseContext _context;

  public TrainingRepository(DatabaseContext context)
  {
    _context = context;
  }

  public async Task<Training?> FindTrainingInUserId(string name, int userId, CancellationToken cancellationToken)
  {
    return await _context.Training.FirstOrDefaultAsync(t => t.Name == name && t.UserId == userId, cancellationToken);
  }

  public async Task<Training?> GetTrainingById(int id, CancellationToken cancellationToken)
  {
    return await _context.Training.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
  }

  public async Task<IEnumerable<Training>> GetTrainingsByUserId(int userId, CancellationToken cancellationToken)
  {
    return await _context.Training.Where(t => t.UserId == userId).ToListAsync(cancellationToken);
  }

  public async Task<bool> SaveTraining(Training training, CancellationToken cancellationToken)
  {
    await _context.Training.AddAsync(training, cancellationToken);
    return await _context.SaveChangesAsync(cancellationToken) > 0;
  }
}
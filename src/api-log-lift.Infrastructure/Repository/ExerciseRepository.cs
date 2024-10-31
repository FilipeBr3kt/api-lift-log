using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace api_log_lift.Infrastructure.Repository;

public class ExerciseRepository : IExerciseRepository
{
  private readonly DatabaseContext _context;

  public ExerciseRepository(DatabaseContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Exercise>> GetAllExercises(CancellationToken cancellationToken)
  {
    return await _context.Exercises
      .AsNoTracking()
      .Include(g => g.Muscle)
      .ToListAsync(cancellationToken);
  }

  public async Task<Exercise?> GetExerciseById(int id, CancellationToken cancellationToken)
  {
    return await _context.Exercises
      .AsNoTracking()
      .Include(p => p.Muscle)
      .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
  }

  public async Task<IEnumerable<Exercise>> GetExerciseByMuscleId(int muscleGroupId, CancellationToken cancellationToken)
  {
    return await _context.Exercises
    .AsNoTracking()
    .Where(e => e.MuscleId == muscleGroupId)
    .Include(g => g.Muscle)
    .ToListAsync(cancellationToken);
  }
}
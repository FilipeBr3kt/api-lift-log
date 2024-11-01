using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace api_log_lift.Infrastructure.Repository;

public class TrainingExerciseRepository : ITrainingExerciseRepository
{
  private readonly DatabaseContext _context;

  public TrainingExerciseRepository(DatabaseContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<TrainingExercise?>> GetByTrainingId(int trainingId, CancellationToken cancellationToken)
  {
    return await _context.TrainingExercises.AsNoTracking().Where(x => x.TrainingId == trainingId).Include(g => g.Exercise).Include(g => g.SetsExercises).ToListAsync(cancellationToken);
  }

  public async Task<IEnumerable<TrainingExercise?>> GetById(int id, CancellationToken cancellationToken)
  {
    return await _context.TrainingExercises.AsNoTracking().Where(x => x.Id == id).Include(g => g.Training).ToListAsync(cancellationToken);
  }

  public async Task<bool> Save(TrainingExercise trainingExercise, CancellationToken cancellationToken)
  {
    await _context.TrainingExercises.AddAsync(trainingExercise, cancellationToken);
    return await _context.SaveChangesAsync(cancellationToken) > 0;
  }
}
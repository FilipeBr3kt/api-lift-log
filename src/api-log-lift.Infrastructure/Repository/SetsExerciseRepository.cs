using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace api_log_lift.Infrastructure.Repository;

public class SetsExerciseRepository : ISetsExerciseRepository
{
  private readonly DatabaseContext _context;

  public SetsExerciseRepository(DatabaseContext context)
  {
    _context = context;
  }

  public async Task<SetsExercise?> GetById(int id, CancellationToken cancellationToken)
  {
    return await _context.SetsExercises.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
  }

  public async Task<bool> Save(SetsExercise setsExercise, CancellationToken cancellationToken)
  {
    await _context.SetsExercises.AddAsync(setsExercise, cancellationToken);
    return await _context.SaveChangesAsync(cancellationToken) > 0;
  }
}
using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Exceptions;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Domain.Responses;
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

  public async Task<IEnumerable<ExerciseResponse>> GetAllExercises(CancellationToken cancellationToken)
  {
    return await _context.Exercises
      .AsNoTracking()
      .Join(
        _context.Muscles,
        exercise => exercise.MuscleId,
        muscle => muscle.Id,
        (exercise, muscle) => new ExerciseResponse
        {
          Id = exercise.Id,
          Name = exercise.Name,
          MuscleId = exercise.MuscleId,
          MuscleName = muscle.Name
        }
      )
      .ToListAsync(cancellationToken);
  }

  public async Task<ExerciseResponse?> GetExerciseById(int id, CancellationToken cancellationToken)
  {
    return await _context.Exercises
      .AsNoTracking()
      .Where(e => e.Id == id)
      .Join(
        _context.Muscles,
        exercise => exercise.MuscleId,
        muscle => muscle.Id,
        (exercise, muscle) => new ExerciseResponse
        {
          Id = exercise.Id,
          Name = exercise.Name,
          MuscleId = exercise.MuscleId,
          MuscleName = muscle.Name
        }
      )
      .FirstOrDefaultAsync(cancellationToken);
  }

  public async Task<IEnumerable<ExerciseResponse>> GetExerciseByMuscleId(int muscleGroupId, CancellationToken cancellationToken)
  {
    var exercise = await _context.Exercises.Where(e => e.MuscleId == muscleGroupId).ToListAsync(cancellationToken);
    return await _context.Exercises
      .AsNoTracking()
      .Where(e => e.MuscleId == muscleGroupId)
      .Join(
        _context.Muscles,
        exercise => exercise.MuscleId,
        muscle => muscle.Id,
        (exercise, muscle) => new ExerciseResponse
        {
          Id = exercise.Id,
          Name = exercise.Name,
          MuscleId = exercise.MuscleId,
          MuscleName = muscle.Name
        }
      )
      .ToListAsync(cancellationToken);
  }
}
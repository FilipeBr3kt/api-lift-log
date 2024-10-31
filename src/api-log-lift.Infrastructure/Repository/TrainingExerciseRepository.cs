using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Domain.Responses;
using api_log_lift.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace api_log_lift.Infrastructure.Repository;

public class TrainingExerciseRepository : ITrainingExerciseRepository
{
  private readonly DatabaseContext _context;

  public TrainingExerciseRepository(DatabaseContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<TrainingExerciseResponse?>> GetByTrainingId(int trainingId, CancellationToken cancellationToken)
  {
    var result = await _context.TrainingExercises
      .Where(x => x.TrainingId == trainingId)
      .Join(
        _context.Exercises,
        trainingExercise => trainingExercise.ExerciseId,
        exercise => exercise.Id,
        (trainingExercise, exercise) => new TrainingExerciseResponse(
          trainingExercise.Id,
          trainingExercise.TrainingId,
          trainingExercise.ExerciseId,
          exercise.Name,
          trainingExercise.DateRegister
        )
      )
      .ToListAsync(cancellationToken);


    return result;
  }

  public async Task<bool> Save(TrainingExercise trainingExercise, CancellationToken cancellationToken)
  {
    await _context.TrainingExercises.AddAsync(trainingExercise, cancellationToken);
    return await _context.SaveChangesAsync(cancellationToken) > 0;
  }
}
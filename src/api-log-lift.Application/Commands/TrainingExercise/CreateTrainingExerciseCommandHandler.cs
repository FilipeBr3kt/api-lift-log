using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Exceptions;
using api_log_lift.Domain.Interfaces;
using MediatR;

namespace api_log_lift.Application.Commands;

public class CreateTrainingExerciseCommandHandler : IRequestHandler<CreateTrainingExerciseCommand, bool>
{
  private readonly ITrainingExerciseRepository _repository;
  private readonly ITrainingRepository _trainingRepository;
  private readonly IExerciseRepository _exerciseRepository;

  public CreateTrainingExerciseCommandHandler(ITrainingExerciseRepository repository, ITrainingRepository trainingRepository, IExerciseRepository exerciseRepository)
  {
    _repository = repository;
    _trainingRepository = trainingRepository;
    _exerciseRepository = exerciseRepository;
  }

  public async Task<bool> Handle(CreateTrainingExerciseCommand request, CancellationToken cancellationToken)
  {
    var training = await _trainingRepository.GetTrainingById(request.TrainingId, cancellationToken)
        ?? throw new NotFoundException("Training not found");

    var exerciseEntity = await _exerciseRepository.GetExerciseById(request.ExerciseId, cancellationToken)
        ?? throw new NotFoundException("Exercise not found");

    var exercise = new TrainingExercise(training.Id, exerciseEntity.Id);

    var saved = await _repository.Save(exercise, cancellationToken);
    if (saved is false) throw new SaveDatabaseException("Failed to save exercise");

    return saved;
  }
}
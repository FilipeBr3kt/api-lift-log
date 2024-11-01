using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Exceptions;
using api_log_lift.Domain.Interfaces;
using MediatR;

namespace api_log_lift.Application.Commands;

public class CreateSetsExerciseCommandHandler : IRequestHandler<CreateSetsExerciseCommand, bool>
{
  private readonly ISetsExerciseRepository _repository;
  private readonly ITrainingExerciseRepository _trainingExerciseRepository;

  public CreateSetsExerciseCommandHandler(ISetsExerciseRepository repository, ITrainingExerciseRepository trainingExerciseRepository)
  {
    _repository = repository;
    _trainingExerciseRepository = trainingExerciseRepository;
  }

  public async Task<bool> Handle(CreateSetsExerciseCommand request, CancellationToken cancellationToken)
  {
    var data = new SetsExercise(request.TrainingExerciseId, request.Reps, request.Weight);

    var trainingExercise = await _trainingExerciseRepository.GetById(request.TrainingExerciseId, cancellationToken)
      ?? throw new NotFoundException("Training exercise not found");

    return await _repository.Save(data, cancellationToken);
  }
}
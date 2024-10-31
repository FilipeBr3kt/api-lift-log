using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Exceptions;
using api_log_lift.Domain.Interfaces;
using MediatR;

namespace api_log_lift.Application.Commands;

public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, bool>
{
  private readonly ITrainingRepository _repository;
  private readonly IUserRepository _userRepository;

  public CreateTrainingCommandHandler(ITrainingRepository repository, IUserRepository userRepository)
  {
    _repository = repository;
    _userRepository = userRepository;
  }

  public async Task<bool> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
  {
    var training = new Training(request.Name, request.UserId);

    if (await _userRepository.FindUserById(training.UserId, cancellationToken) == null)
    {
      throw new NotFoundException("This user does not exist");
    }

    if (await _repository.FindTrainingInUserId(training.Name, training.UserId, cancellationToken) != null)
    {
      throw new ConflictException("Training already exists");
    }

    if (!await _repository.SaveTraining(training, cancellationToken))
    {
      throw new SaveDatabaseException("Error saving training");
    }

    return true;
  }
}
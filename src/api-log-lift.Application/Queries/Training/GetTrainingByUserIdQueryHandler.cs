using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Domain.Responses;
using MediatR;

namespace api_log_lift.Application.Queries;

public class GetTrainingByUserIdQueryHandler : IRequestHandler<GetTrainingByUserIdQuery, IEnumerable<TrainingResponse>>
{
  private readonly ITrainingRepository _repository;

  public GetTrainingByUserIdQueryHandler(ITrainingRepository repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<TrainingResponse>> Handle(GetTrainingByUserIdQuery request, CancellationToken cancellationToken)
  {
    var result = await _repository.GetTrainingsByUserId(request.UserId, cancellationToken);
    return new List<TrainingResponse>(result.Select(t => new TrainingResponse
    {
      Id = t.Id,
      Name = t.Name,
      DateRegister = t.DateRegister,
      UserId = t.UserId,
    }));
  }
}
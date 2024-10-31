using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Domain.Responses;
using MediatR;


namespace api_log_lift.Application.Queries;

public class GetMuscleQueryHandler : IRequestHandler<GetMuscleQuery, IEnumerable<MuscleResponse>>
{
  private readonly IMuscleRepository _repository;

  public GetMuscleQueryHandler(IMuscleRepository repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<MuscleResponse>> Handle(GetMuscleQuery request, CancellationToken cancellationToken)
  {
    var result = await _repository.GetAll(cancellationToken);
    return result.Select(m => new MuscleResponse
    {
      Id = m.Id,
      Name = m.Name
    });
  }
}
using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Exceptions;
using api_log_lift.Domain.Interfaces;
using api_log_lift.Domain.Responses;
using MediatR;

namespace api_log_lift.Application.Queries;

public class GetExerciseByIdQueryHandler : IRequestHandler<GetExerciseByIdQuery, ExerciseResponse>
{
  private readonly IExerciseRepository _exerciseRepository;

  public GetExerciseByIdQueryHandler(IExerciseRepository exerciseRepository)
  {
    _exerciseRepository = exerciseRepository;
  }

  public async Task<ExerciseResponse> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
  {
    var exerciseExist = await _exerciseRepository.GetExerciseById(request.Id, cancellationToken)
            ?? throw new NotFoundException("Exercise not found");

    return exerciseExist;
  }
}
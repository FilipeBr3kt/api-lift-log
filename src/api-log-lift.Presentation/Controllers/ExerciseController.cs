using api_log_lift.Application.Queries;
using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;
using api_log_lift.Presentation.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Controllers;

[ApiController]
[Route("exercise")]
public class ExerciseController : ControllerBase, IExerciseController
{
  private readonly IMediator _mediator;

  public ExerciseController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<ExerciseResponse>>> GetAllExercises()
  {
    var query = new GetExerciseQuery();
    var result = await _mediator.Send(query);
    return Ok(result);
  }


  [HttpGet("{id}")]
  public async Task<ActionResult<ExerciseResponse>> GetExerciseById(int id)
  {
    var query = new GetExerciseByIdQuery(id);
    var result = await _mediator.Send(query);
    return Ok(result);
  }

  [HttpGet("muscle/{muscleGroupId}")]
  public async Task<ActionResult<IEnumerable<ExerciseResponse>>> GetExercisesByMuscleGroupId(int muscleGroupId)
  {
    var query = new GetExerciseByMuscleGroupIdQuery(muscleGroupId);
    var result = await _mediator.Send(query);
    return Ok(result);
  }
}
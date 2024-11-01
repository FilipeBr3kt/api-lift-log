using api_log_lift.Application.Commands;
using api_log_lift.Domain.Entities;
using api_log_lift.Presentation.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Controllers;

[ApiController]
[Route("exercise/sets")]
public class SetsExerciseController : ControllerBase, ISetsExerciseController
{
  private readonly ISender _sender;

  public SetsExerciseController(ISender sender)
  {
    _sender = sender;
  }

  [HttpPost]
  public async Task<ActionResult> CreateSets(CreateSetsExerciseCommand command)
  {
    await _sender.Send(command);
    return Ok("Set added successfully");
  }

  [HttpGet("{trainingExerciseId}")]
  public Task<ActionResult<IEnumerable<SetsExercise>>> GetByTrainingExerciseId(int trainingExerciseId)
  {
    throw new NotImplementedException();
  }
}
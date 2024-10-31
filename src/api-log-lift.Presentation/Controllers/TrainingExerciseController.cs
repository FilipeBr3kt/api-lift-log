using api_log_lift.Application.Commands;
using api_log_lift.Application.Queries;
using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;
using api_log_lift.Presentation.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Controllers;

[ApiController]
[Route("training/exercise")]
public class TrainingExerciseController : ControllerBase, ITrainingExerciseController
{
  private readonly ISender _sender;

  public TrainingExerciseController(ISender sender)
  {
    _sender = sender;
  }

  [HttpPost]
  public async Task<ActionResult> CreateExercise(CreateTrainingExerciseCommand command)
  {
    await _sender.Send(command);
    return Ok("Exercise added successfully");
  }

  [HttpGet("{trainingId}")]
  public async Task<ActionResult<IEnumerable<TrainingExerciseResponse>>> GetByTrainingId(int trainingId)
  {
    var command = new GetTrainingExerciseByTrainingIdQuery(trainingId);
    var result = await _sender.Send(command);
    return Ok(result);
  }
}
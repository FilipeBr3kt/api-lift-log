using api_log_lift.Application.Commands;
using api_log_lift.Application.Queries;
using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;
using api_log_lift.Presentation.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Controllers;

[ApiController]
[Route("training")]
public class TrainingController : ControllerBase, ITrainingController
{
  private readonly ISender _sender;

  public TrainingController(ISender sender)
  {
    _sender = sender;
  }

  [HttpPost]
  public async Task<ActionResult> CreateTraining(CreateTrainingCommand command)
  {
    await _sender.Send(command);
    return Ok("Training created successfully");
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<TrainingResponse>> GetById(int id)
  {
    var command = new GetTrainingByIdQuery(id);
    var result = await _sender.Send(command);
    return Ok(result);
  }

  [HttpGet("user/{userId}")]
  public async Task<ActionResult<IEnumerable<TrainingResponse>>> GetByUserId(int userId)
  {
    var command = new GetTrainingByUserIdQuery(userId);
    var result = await _sender.Send(command);
    return Ok(result);
  }
}
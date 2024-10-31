using api_log_lift.Application.Queries;
using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;
using api_log_lift.Presentation.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Controllers;

[ApiController]
[Route("muscle")]
public class MuscleController : ControllerBase, IMuscleController
{
  private readonly IMediator _mediator;

  public MuscleController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<MuscleResponse>>> GetAllMuscles()
  {
    var query = new GetMuscleQuery();
    var muscles = await _mediator.Send(query);
    return Ok(muscles);
  }

}
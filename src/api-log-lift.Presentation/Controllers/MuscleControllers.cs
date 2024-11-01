using System.Text.Json;
using api_log_lift.Application.Queries;
using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;
using api_log_lift.Presentation.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace api_log_lift.Presentation.Controllers;

[ApiController]
[Route("muscle")]
public class MuscleController : ControllerBase, IMuscleController
{
  private readonly IMediator _mediator;
  private readonly IDistributedCache _cache;

  public MuscleController(IMediator mediator, IDistributedCache cache)
  {
    _mediator = mediator;
    _cache = cache;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<MuscleResponse>>> GetAllMuscles()
  {
    string cacheKey = "GetAllMuscles";
    var cachedValue = await _cache.GetStringAsync(cacheKey);

    if (!string.IsNullOrEmpty(cachedValue))
    {
      var exercises = JsonSerializer.Deserialize<IEnumerable<MuscleResponse>>(cachedValue);
      if (exercises is not null)
      {
        return Ok(exercises);
      }
    }

    var query = new GetMuscleQuery();
    var muscles = await _mediator.Send(query);

    await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(muscles), new DistributedCacheEntryOptions
    {
      AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
    });

    return Ok(muscles);
  }

}
using System.Text.Json;
using api_log_lift.Application.Queries;
using api_log_lift.Domain.Responses;
using api_log_lift.Presentation.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace api_log_lift.Presentation.Controllers;

[ApiController]
[Route("exercise")]
public class ExerciseController : ControllerBase, IExerciseController
{
  private readonly IMediator _mediator;
  private readonly IDistributedCache _cache;

  public ExerciseController(IMediator mediator, IDistributedCache cache)
  {
    _mediator = mediator;
    _cache = cache;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<ExerciseResponse>>> GetAllExercises()
  {
    string key = "exercises";
    var cachedValue = await _cache.GetStringAsync(key);

    if (!string.IsNullOrEmpty(cachedValue))
    {
      var exercises = JsonSerializer.Deserialize<IEnumerable<ExerciseResponse>>(cachedValue);
      if (exercises is not null)
      {
        return Ok(exercises);
      }
    }

    var query = new GetExerciseQuery();
    var result = await _mediator.Send(query);

    await _cache.SetStringAsync(key, JsonSerializer.Serialize(result), new DistributedCacheEntryOptions
    {
      AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
    });

    return Ok(result);
  }


  [HttpGet("{id}")]
  public async Task<ActionResult<ExerciseResponse>> GetExerciseById(int id)
  {
    string key = $"exercises-{id}";
    var cachedValue = await _cache.GetStringAsync(key);

    ExerciseResponse? exercise;
    if (!string.IsNullOrEmpty(cachedValue))
    {
      exercise = JsonSerializer.Deserialize<ExerciseResponse>(cachedValue);

      if (exercise is not null)
      {
        return Ok(exercise);
      }
    }

    var query = new GetExerciseByIdQuery(id);
    var result = await _mediator.Send(query);

    await _cache.SetStringAsync(key, JsonSerializer.Serialize(result), new DistributedCacheEntryOptions
    {
      AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
    });

    return Ok(result);
  }

  [HttpGet("muscle/{muscleGroupId}")]
  public async Task<ActionResult<IEnumerable<ExerciseResponse>>> GetExercisesByMuscleGroupId(int muscleGroupId)
  {
    string key = $"exercises-muscle-{muscleGroupId}";
    var cachedValue = await _cache.GetStringAsync(key);

    ExerciseResponse? exerciseResponse;
    if (!string.IsNullOrEmpty(cachedValue))
    {
      exerciseResponse = JsonSerializer.Deserialize<ExerciseResponse>(cachedValue);

      if (exerciseResponse is not null)
      {
        return Ok(exerciseResponse);
      }
    }

    var query = new GetExerciseByMuscleGroupIdQuery(muscleGroupId);
    var result = await _mediator.Send(query);

    await _cache.SetStringAsync(key, JsonSerializer.Serialize(result), new DistributedCacheEntryOptions
    {
      AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
    });

    return Ok(result);
  }
}
using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Interfaces;

public interface IMuscleController
{
  Task<ActionResult<IEnumerable<MuscleResponse>>> GetAllMuscles();
}
using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Interfaces;

public interface IExerciseController
{
  Task<ActionResult<IEnumerable<ExerciseResponse>>> GetAllExercises();
  Task<ActionResult<IEnumerable<ExerciseResponse>>> GetExercisesByMuscleGroupId(int muscleGroupId);
  Task<ActionResult<ExerciseResponse>> GetExerciseById(int id);
}
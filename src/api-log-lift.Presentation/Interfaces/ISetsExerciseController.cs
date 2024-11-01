using api_log_lift.Application.Commands;
using api_log_lift.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Interfaces;

public interface ISetsExerciseController
{
  Task<ActionResult<IEnumerable<SetsExercise>>> GetByTrainingExerciseId(int trainingExerciseId);
  Task<ActionResult> CreateSets(CreateSetsExerciseCommand command);
}
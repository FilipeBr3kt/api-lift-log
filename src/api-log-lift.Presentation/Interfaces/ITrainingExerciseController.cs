using api_log_lift.Application.Commands;
using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Interfaces;

public interface ITrainingExerciseController
{
  Task<ActionResult<IEnumerable<TrainingExerciseResponse>>> GetByTrainingId(int trainingId);
  Task<ActionResult> CreateExercise(CreateTrainingExerciseCommand command);
}
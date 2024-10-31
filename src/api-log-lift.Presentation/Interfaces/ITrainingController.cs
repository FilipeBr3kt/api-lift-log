using api_log_lift.Application.Commands;
using api_log_lift.Domain.Entities;
using api_log_lift.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Interfaces;

public interface ITrainingController
{
  Task<ActionResult<IEnumerable<TrainingResponse>>> GetByUserId(int userId);
  Task<ActionResult<TrainingResponse>> GetById(int id);
  Task<ActionResult> CreateTraining(CreateTrainingCommand command);
}
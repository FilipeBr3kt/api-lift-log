using api_log_lift.Domain.Entities;

namespace api_log_lift.Domain.Responses;

public record TrainingExerciseResponse(int Id, int TrainingId, int ExerciseId, string ExerciseName, DateTime DateRegister) { };
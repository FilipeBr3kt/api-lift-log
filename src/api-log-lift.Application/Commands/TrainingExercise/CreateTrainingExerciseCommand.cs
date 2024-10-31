using MediatR;

namespace api_log_lift.Application.Commands;

public record CreateTrainingExerciseCommand(int TrainingId, int ExerciseId) : IRequest<bool>;
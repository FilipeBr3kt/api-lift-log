using MediatR;

namespace api_log_lift.Application.Commands;

public record CreateSetsExerciseCommand(int TrainingExerciseId, int Reps, decimal Weight) : IRequest<bool>;
using System;
using System.Collections.Generic;

namespace api_log_lift.Domain.Entities;

public partial class SetsExercise
{
    public int Id { get; private set; }

    public int TrainingExerciseId { get; private set; }

    public int Reps { get; private set; }

    public decimal Weight { get; private set; }

    public virtual TrainingExercise TrainingExercise { get; private set; } = null!;

    public SetsExercise()
    {
    }

    public SetsExercise(int trainingExerciseId, int reps, decimal weight)
    {
        TrainingExerciseId = trainingExerciseId;
        Reps = reps;
        Weight = weight;
    }
}
